using Inventory_Models;
using SharedUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_DAL
{


    public class clsEmployeesDAL : BaseDAL
    {

    
        public static DataTable GetAllEmployeesAsDataTable()
        {
            string Query = "SELECT * FROM EmployeesData;";
            return ExecuteDataTable(Query);
        }



        public static bool GetEmployeeById(int employeeId, out EmployeeDto employeeData,
                                         [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {

            //return GetEntityById("Employees", employeeId,
            //new List<string>
            //{"PersonID", "Designation", "Department", "Salary", "Notes", "IsActive", "CreationDate", "ModifiedDate"},
            //out employeeData);

            employeeData = null;

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_GetEmployeeByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employeeData = new EmployeeDto
                            {
                                EmployeeID = employeeId,
                                PersonID = Convert.ToInt32(reader["PersonID"]),
                                Designation = reader["Designation"]?.ToString(),
                                Department = reader["Department"]?.ToString(),
                                Salary = Convert.ToDecimal(reader["Salary"]),
                                Notes = reader["Notes"]?.ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                                ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"])
                            };

                            LogHelper.LogInfo($"Employee data retrieved successfully. ID: {employeeId}", methodName, filePath);
                            return true;
                        }
                        else
                        {
                            LogHelper.LogWarning($"No employee found with ID: {employeeId}", methodName, filePath);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogError($"Error retrieving employee with ID: {employeeId}", ex, methodName, filePath);
                    throw;
                }
            }
        }



        public static bool UpdateEmployee(EmployeeDto dto,
                                  [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {

            //return UpdateEntity("Employees", employeeId, new Dictionary<string, object> { { "Designation", designation }, { "Department", department }, { "Salary", salary }, { "Notes", notes }, { "IsActive", isActive }, { "CreationDate", CreationDate }, { "ModifiedDate", modifiedDate } });


            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_UpdateEmployee", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", dto.EmployeeID);
                cmd.Parameters.AddWithValue("@Designation", dto.Designation);
                cmd.Parameters.AddWithValue("@Department", dto.Department);
                cmd.Parameters.AddWithValue("@Salary", dto.Salary);
                cmd.Parameters.AddWithValue("@Notes", dto.Notes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", dto.IsActive);

                try
                {
                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        LogHelper.LogInfo($"Employee updated successfully. ID: {dto.EmployeeID}", methodName, filePath);
                        return true;
                    }
                    else
                    {
                        LogHelper.LogWarning($"No update occurred for employee ID: {dto.EmployeeID}", methodName, filePath);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogError($"Error updating employee ID: {dto.EmployeeID}", ex, methodName, filePath);
                    throw;
                }
            }
        }



        public static int AddEmployee(EmployeeDto dto,
                              [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {


            //return AddEntity("Employees", new Dictionary<string, object>
            //{
            //    { "PersonID", personId },
            //    { "Designation", designation },
            //    { "Department", department },
            //    { "Salary", salary },
            //    { "Notes", notes },
            //    { "IsActive", isActive }
            //});

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_AddEmployee", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PersonID", dto.PersonID);
                cmd.Parameters.AddWithValue("@Designation", dto.Designation);
                cmd.Parameters.AddWithValue("@Department", dto.Department);
                cmd.Parameters.AddWithValue("@Salary", dto.Salary);
                cmd.Parameters.AddWithValue("@Notes", dto.Notes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IsActive", dto.IsActive);

                try
                {
                    object result = cmd.ExecuteScalar();
                    int insertedId = Convert.ToInt32(result);

                    LogHelper.LogInfo($"Employee inserted successfully. ID: {insertedId}", methodName, filePath);
                    return insertedId;
                }
                catch (Exception ex)
                {
                    LogHelper.LogError("Error inserting new employee.", ex, methodName, filePath);
                    throw;
                }
            }
        }




        public static bool DeleteEmployee(int employeeId,
            [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {

            //return DeleteEntity("Employees", employeeId);

            using (SqlConnection conn = GetConnection())

            using (SqlCommand cmd = new SqlCommand("usp_DeleteEmployee", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                var successParam = new SqlParameter("@Success", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(successParam);

                try
                {
                    cmd.ExecuteNonQuery();
                    return (bool)successParam.Value;
                }
                catch (Exception ex)
                {
                    LogHelper.LogError("Error Deleting employee.", ex, methodName, filePath);
                    return false;
                }
            }

        }





    }
}
