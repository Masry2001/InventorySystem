using Inventory_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Business
{
    public class clsEmployeeManager
    {

        // Additional Fields for Employees


        // id, name, phone, email, address
        public int EmployeeID { get; set; } 
        public int PersonID { get; set; } 
        public string Designation { get; set; }
        public string Department { get; set; }
        public float Salary { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Derived property to get a formatted "Active" status
        public string ActiveStatus => IsActive ? "Active" : "Inactive";
        // Constructor
        public clsEmployeeManager() : base()
        {
            // Initialize with default values if necessary
        }

        // Parameterized Constructor
        public clsEmployeeManager(int employeeId, int personId, string name, string phone, string email, string address, string designation, string department, float salary, string notes, bool isActive, DateTime createdDate, DateTime modifiedDate)
            : base(personId, name, phone, email, address)
        {
            EmployeeID = employeeId;
            PersonID = personId;
            Designation = designation;
            Department = department;
            Salary = salary;
            Notes = notes;
            IsActive = isActive;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;

        }

     

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Status: {ActiveStatus}, Designation: {Designation}, Department: {Department}, Salary: {Salary}";
        }

        public static DataTable GetAllEmployeesAsDataTable()
        {
            return clsEmployeesDAL.GetAllEmployeesAsDataTable();
        }


        public static int GetPersonIdByEmployeeId(int employeeId)
        {
            return clsEmployeesDAL.GetPersonIdByEmployeeId(employeeId);
        }

        public static bool GetEmployee(int employeeId, out Dictionary<string, object> EmployeeData)
        {
            return clsEmployeesDAL.GetEmployeeById(employeeId, out EmployeeData);

        }

        //public static clsEmployeeManager GetEmployee(int employeeId)
        //{
        //    Dictionary<string, object> employeeData;

        //    // Fetch data from DAL
        //    bool isFound = clsEmployeesDAL.GetEmployeeById(employeeId, out employeeData);

        //    if (!isFound || employeeData == null)
        //        return null; // Employee not found

        //    // Map the dictionary data to a clsEmployee object
        //    return new clsEmployeeManager(
        //        (int)employeeData["EmployeeID"],
        //        (int)employeeData["PersonID"],
        //        employeeData["Designation"].ToString(),
        //        employeeData["Department"].ToString(),
        //        Convert.ToDecimal(employeeData["Salary"]),
        //        employeeData["Notes"] != DBNull.Value ? employeeData["Notes"].ToString() : "",
        //        (bool)employeeData["IsActive"],
        //        (DateTime)employeeData["CreatedDate"],
        //        (DateTime)employeeData["ModifiedDate"]
        //    );
        //}





    }
}
