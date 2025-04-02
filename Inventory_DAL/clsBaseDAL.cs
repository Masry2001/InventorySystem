using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using SharedUtilities;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Linq;

namespace Inventory_DAL
{
    public abstract class BaseDAL
    {
        // Get the connection string from SharedUtilities
        //If you want a constant-like behavior but initialized at runtime, use static readonly
        protected static readonly string ConnectionString;

        static BaseDAL()
        {
            ConnectionString = ConfigHelper.GetConnectionString("InventoryDB");
        }

        // Utility to create and open a database connection
        protected static SqlConnection GetConnection(bool Open = true)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            if (Open)
            {
                Connection.Open(); 
            }
            return Connection;
        }



        protected static DataTable ExecuteDataTable(string Query, Dictionary<string, object> Parameters = null,
            [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = GetConnection()) // Connection is already opened in GetConnection()
                {
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        // Add parameters if provided
                        if (Parameters != null)
                        {
                            foreach (var param in Parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader); // Load the DataReader's content into the DataTable
                            }
                        }
                    }
                }
                LogHelper.LogInfo($"Query executed successfully in {filePath}, Method: {methodName}");
            }
            catch (Exception ex)
            {
                LogHelper.LogError("An error occurred while executing the query.", ex, methodName, filePath);
                throw; // Rethrow the exception to propagate it to a higher layer
            }
            return dataTable;
        }



        protected static bool GetEntityById(string tableName, int ID, List<string> columns, out Dictionary<string, object> result,
                                    [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {
            bool isFound = false;
            result = new Dictionary<string, object>();

            using (SqlConnection connection = GetConnection())
            {
                // Define the correct primary key for each table
                Dictionary<string, string> primaryKeyMap = new Dictionary<string, string>
                {
                    { "People", "PersonID" },
                    { "Employees", "EmployeeID" },
                    { "Customers", "CustomerID" },
                    { "Suppliers", "SupplierID" }
                };

                // Ensure the table name exists in the dictionary
                if (!primaryKeyMap.TryGetValue(tableName, out string primaryKey))
                {
                    throw new ArgumentException($"Invalid table name: {tableName}");
                }

                // Construct the query dynamically based on requested columns
                string selectedColumns = string.Join(", ", columns);
                string query = $"SELECT {selectedColumns} FROM {tableName} WHERE {primaryKey} = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                foreach (var column in columns)
                                {
                                    result[column] = GetDbValueOrNull(reader[column]);
                                }
                            }
                        }

                        LogHelper.LogInfo($"Query executed successfully in {filePath}, Method: {methodName}");
                    }
                    catch (Exception ex)
                    {
                        LogHelper.LogError("An error occurred while executing the query.", ex, methodName, filePath);
                        throw; // Propagate exception
                    }
                }
            }

            return isFound;
        }


        protected static bool UpdateEntity(string tableName, int ID, Dictionary<string, object> columnsToUpdate,
                                     [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {
            if (columnsToUpdate == null || columnsToUpdate.Count == 0)
            {
                throw new ArgumentException("No columns provided for update.");
            }

            using (SqlConnection connection = GetConnection())
            {

                // Define the correct primary key for each table
                Dictionary<string, string> primaryKeyMap = new Dictionary<string, string>
                {
                    { "People", "PersonID" },
                    { "Employees", "EmployeeID" },
                    { "Customers", "CustomerID" },
                    { "Suppliers", "SupplierID" }
                };

                // Ensure the table name exists in the dictionary
                if (!primaryKeyMap.TryGetValue(tableName, out string primaryKey))
                {
                    throw new ArgumentException($"Invalid table name: {tableName}");
                }

                // Constructing update query dynamically
                string setClause = string.Join(", ", columnsToUpdate.Keys.Select(col => $"{col} = @{col}"));
                string query = $"UPDATE {tableName} SET {setClause} WHERE {primaryKey} = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add column parameters
                    foreach (var column in columnsToUpdate)
                    {
                        command.Parameters.AddWithValue($"@{column.Key}", column.Value ?? DBNull.Value);
                    }

                    // Add ID parameter
                    command.Parameters.AddWithValue("@ID", ID);

                    int rowsAffected = 0;   
                    try
                    {
                        rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            LogHelper.LogInfo($"Update successful in {filePath}, Method: {methodName}");
                            return true;
                        }
                        else
                        {
                            LogHelper.LogWarning($"No rows were updated in {filePath}, Method: {methodName}");
                            return false; // Explicitly return false when no update occurs
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.LogError($"An error occurred while updating table '{tableName}'.", ex, methodName, filePath);
                        throw; // Rethrow exception
                    }
                }
            }
        }


        protected static bool DeleteEntity(string tableName, int ID,
                                         [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {
            using (SqlConnection connection = GetConnection())
            {
                Dictionary<string, string> primaryKeyMap = new Dictionary<string, string>
                {
                    { "People", "PersonID" },
                    { "Employees", "EmployeeID" },
                    { "Customers", "CustomerID" },
                    { "Suppliers", "SupplierID" }
                };

                if (!primaryKeyMap.TryGetValue(tableName, out string primaryKey))
                {
                    LogHelper.LogError($"Invalid table name: {tableName}", null, methodName, filePath);
                    return false;
                }

                string query = $"DELETE FROM {tableName} WHERE {primaryKey} = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            LogHelper.LogInfo($"Delete successful in {filePath}, Method: {methodName}");
                            return true;
                        }
                        else
                        {
                            LogHelper.LogWarning($"No rows were deleted in {filePath}, Method: {methodName}");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.LogError($"An error occurred while deleting from table '{tableName}'.", ex, methodName, filePath);
                        return false;
                    }
                }
            }
        }


        protected static int GetPersonIdByEntityId(string tableName, string idColumnName, int entityId,
                                           [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {
            int personId = -1; // Default value if not found

            using (SqlConnection connection = GetConnection())
            {
                string query = $"SELECT PersonID FROM {tableName} WHERE {idColumnName} = @EntityID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EntityID", entityId);

                    try
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            personId = Convert.ToInt32(result);
                        }

                        LogHelper.LogInfo($"Query executed successfully in {filePath}, Method: {methodName}");
                    }
                    catch (Exception ex)
                    {
                        LogHelper.LogError("Error fetching PersonID", ex, methodName, filePath);
                        throw;
                    }
                }
            }

            return personId;
        }



        //Purpose: Handles database values that might be DBNull
        // This Method Will Be Used Only In DAL
        public static object GetDbValueOrNull(object value)
        {
            return value == DBNull.Value ? null : value;
        }




    }
}
