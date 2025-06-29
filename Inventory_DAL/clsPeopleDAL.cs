﻿using Inventory_Models;
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



        public static bool GetPersonById(int personID, out PersonDto personData,
                                 [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {
            //return GetEntityById("People", PersonID, new List<string> { "Name", "Phone", "Email", "Address" }, out personData);
            //return GetEntityById("Customers", customerId,
            //new List<string> { "PersonID", "Notes", "IsActive", "CreationDate", "ModifiedDate" }, out customerData);
            //return GetEntityById("Suppliers", supplierId,
            //new List<string> { "PersonID", "Notes", "IsActive", "CreationDate", "ModifiedDate" }, out supplierData);


            personData = null;

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand("usp_GetPersonByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", personID);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            personData = new PersonDto
                            {
                                PersonID = personID,
                                Name = reader["Name"]?.ToString(),
                                Phone = reader["Phone"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                Address = reader["Address"]?.ToString(),
                                IsDeleted = reader["IsDeleted"] != DBNull.Value && Convert.ToBoolean(reader["IsDeleted"]),
                                DeletedDate = 
                                reader["DeletedDate"] != DBNull.Value ? Convert.ToDateTime(reader["DeletedDate"]) : (DateTime?)null
                            };

                            LogHelper.LogInfo($"Person retrieved successfully. ID: {personID}", methodName, filePath);
                            return true;
                        }
                        else
                        {
                            LogHelper.LogWarning($"No person found with ID: {personID}", methodName, filePath);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.LogError($"Error retrieving person with ID: {personID}", ex, methodName, filePath);
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
