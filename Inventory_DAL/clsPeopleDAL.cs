using SharedUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_DAL
{
    public class clsPeopleDAL : BaseDAL
    {


        public static bool GetPersonById(int PersonID, out Dictionary<string, object> personData,
                                 [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {

            //return GetEntityById("People", PersonID, new List<string> { "Name", "Phone", "Email", "Address" }, out personData);
            //return GetEntityById("Customers", customerId,
            //new List<string> { "PersonID", "Notes", "IsActive", "CreationDate", "ModifiedDate" }, out customerData);
            //return GetEntityById("Suppliers", supplierId,
            //new List<string> { "PersonID", "Notes", "IsActive", "CreationDate", "ModifiedDate" }, out supplierData);



            personData = new Dictionary<string, object>();

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_GetPersonByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", PersonID);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personData["Name"] = GetDbValueOrNull(reader["Name"]);
                            personData["Phone"] = GetDbValueOrNull(reader["Phone"]);
                            personData["Email"] = GetDbValueOrNull(reader["Email"]);
                            personData["Address"] = GetDbValueOrNull(reader["Address"]);

                            LogHelper.LogInfo($"Person retrieved successfully. ID: {PersonID}", methodName, filePath);
                            return true;
                        }
                        else
                        {
                            LogHelper.LogWarning($"No person found with ID: {PersonID}", methodName, filePath);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogError($"An error occurred while retrieving person with ID: {PersonID}.", ex, methodName, filePath);
                    throw;
                }
            }
        }




        public static bool UpdatePerson(int personID, string name, string phone, string email, string address,
                                [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {


            //return UpdateEntity("People", PersonID, new Dictionary<string, object>
            //{ 
            //    { "Name", name },
            //    { "Phone", phone },
            //    { "Email", email },
            //    { "Address", address }
            //});


            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_UpdatePerson", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", personID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        LogHelper.LogInfo($"Person updated successfully. ID: {personID}", methodName, filePath);
                        return true;
                    }
                    else
                    {
                        LogHelper.LogWarning($"No person was updated. ID may not exist: {personID}", methodName, filePath);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogError("An error occurred while updating the person.", ex, methodName, filePath);
                    throw;
                }
            }
        }


        public static int AddNewPerson(string name, string phone, string email, string address,
                               [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {


            //return AddEntity("People", new Dictionary<string, object>
            //{
            //    { "Name", name },
            //    { "Phone", phone },
            //    { "Email", email },
            //    { "Address", address }
            //});

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_AddPerson", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);

                try
                {
                    object result = cmd.ExecuteScalar();
                    int insertedId = Convert.ToInt32(result);

                    LogHelper.LogInfo($"Person inserted successfully. ID: {insertedId}", methodName, filePath);
                    return insertedId;
                }
                catch (Exception ex)
                {
                    LogHelper.LogError("An error occurred while inserting a new person.", ex, methodName, filePath);
                    throw;
                }
            }
        }



        public static bool DeletePerson(int personID,
                                [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {
            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_DeletePerson", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", personID);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        LogHelper.LogInfo($"Person deleted successfully. ID: {personID}", methodName, filePath);
                        return true;
                    }
                    else
                    {
                        LogHelper.LogWarning($"No person found to delete. ID: {personID}", methodName, filePath);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogError($"An error occurred while deleting person with ID: {personID}.", ex, methodName, filePath);
                    throw;
                }
            }
        }







    }
}
