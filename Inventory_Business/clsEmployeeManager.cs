using Inventory_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessUtilities;

namespace Inventory_Business
{
    public class clsEmployeeManager
    {

        // Additional Fields for Employees


        // id, name, phone, email, address
        // Composition (Employee "has a" Person(rather than "is a" Person, which would be inheritance))

        // Automatic property
        public int EmployeeID { get; set; } 
        public int PersonID { get; set; } 
        public clsPersonManager PersonInfo { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        // Derived property to get a formatted "Active" status
        //// Expression-bodied read-only property
        public string ActiveStatus => IsActive ? "Active" : "Inactive";
        // Constructor
        public clsEmployeeManager()
        {
            // Initialize with default values if necessary
        }

        // Parameterized Constructor
        public clsEmployeeManager(int employeeId, int personId, string designation, string department, decimal salary, string notes, bool isActive, DateTime createdDate, DateTime modifiedDate)
        {
            EmployeeID = employeeId;
            PersonID = personId;
            PersonInfo = clsPersonManager.GetPerson(personId);
            Designation = designation;
            Department = department;
            Salary = salary;
            Notes = notes;
            IsActive = isActive;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
        }
        public string GetInfo()
        {
            return $"{PersonInfo.GetInfo()}, Status: {ActiveStatus}, Designation: {Designation}, Department: {Department}, Salary: {Salary}";
        }

        public static DataTable GetAllEmployeesAsDataTable()
        {
            return clsEmployeesDAL.GetAllEmployeesAsDataTable();
        }


        // No Need For This Method
        public static int GetPersonIdByEmployeeId(int employeeId)
        {
            return clsEmployeesDAL.GetPersonIdByEmployeeId(employeeId);
        }



        public static clsEmployeeManager GetEmployee(int employeeId)
        {
            Dictionary<string, object> employeeData;

            // Fetch data from DAL
            bool isFound = clsEmployeesDAL.GetEmployeeById(employeeId, out employeeData);

            if (!isFound || employeeData == null)
                return null; // Employee not found

            // Map the dictionary data to a clsEmployee object
            return new clsEmployeeManager(
                employeeId,
                (int)employeeData["PersonID"],
                employeeData["Designation"].ToString(),
                employeeData["Department"].ToString(),
                (decimal)employeeData["Salary"],
                BusinessUtil.GetValueOrDefault(employeeData["Notes"].ToString()),
                (bool)employeeData["IsActive"],
                (DateTime)employeeData["CreatedDate"],
                (DateTime)employeeData["ModifiedDate"]
            );
        }





    }
}
