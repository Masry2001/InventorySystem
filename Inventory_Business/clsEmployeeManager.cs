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

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        // Constructor
        public clsEmployeeManager()
        {
            // Initialize with default values if necessary
            EmployeeID = -1;
            PersonID = -1;
            PersonInfo = new clsPersonManager();
            Designation = "";
            Department = "";
            Salary = 0;
            Notes = "";
            IsActive = true;
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Mode = enMode.AddNew;

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
            Mode = enMode.Update;
        }
        public string GetInfo()
        {
            return $"{PersonInfo.GetInfo()}, Status: {ActiveStatus}, Designation: {Designation}, Department: {Department}, Salary: {Salary}";
        }

        public static DataTable GetAllEmployeesAsDataTable()
        {
            return clsEmployeesDAL.GetAllEmployeesAsDataTable();
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


        private bool _AddNewEmployee()
        {
            //call DataAccess Layer 

            //this.PersonID = clsPeopleDAL.AddNewPerson(
            //    this.FirstName, this.SecondName, this.ThirdName,
            //    this.LastName, this.NationalNo,
            //    this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
            //    this.NationalityCountryID, this.ImagePath);

            //return (this.PersonID != -1);
            return false;
        }

        private bool _UpdateEmployee()
        {
            //call DataAccess Layer 



            return clsEmployeesDAL.UpdateEmployee(
                this.EmployeeID, this.PersonID, this.Designation, this.Department, this.Salary, this.Notes, this.IsActive, this.CreatedDate, this.ModifiedDate);
        }


        public bool SaveEmployee()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmployee())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateEmployee();

            }

            return false;
        }



    }
}
