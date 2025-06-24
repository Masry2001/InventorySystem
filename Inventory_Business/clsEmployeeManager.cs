using BusinessUtilities;
using Inventory_DAL;
using Inventory_Models;
using SharedUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BusinessUtilities.BusinessValidationHelper;

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
        public DateTime CreationDate { get; set; }
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
            CreationDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            Mode = enMode.AddNew;

        }

        // Parameterized Constructor
        public clsEmployeeManager(int employeeId, int personId, string designation, string department, decimal salary, string notes, bool isActive, DateTime CreationDate, DateTime modifiedDate)
        {
            EmployeeID = employeeId;
            PersonID = personId;
            PersonInfo = clsPersonManager.GetPerson(personId);
            Designation = designation;
            Department = department;
            Salary = salary;
            Notes = notes;
            IsActive = isActive;
            this.CreationDate = CreationDate;
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
            EmployeeDto dto;

            // Get the DTO from DAL
            bool isFound = clsEmployeesDAL.GetEmployeeById(employeeId, out dto);

            if (!isFound || dto == null)
                return null;

            // Use the DTO to build the business object
            return new clsEmployeeManager(
                dto.EmployeeID,
                dto.PersonID,
                dto.Designation,
                dto.Department,
                dto.Salary,
                BusinessUtil.GetValueOrDefault(dto.Notes),
                dto.IsActive,
                dto.CreationDate,
                dto.ModifiedDate
            );
        }



        private bool _AddNewEmployee()
        {
            //call DataAccess Layer
            // we have the person ID from the clsPersonmManager class


            this.EmployeeID = clsEmployeesDAL.AddNewEmployee(this.PersonID, this.Designation, this.Department, this.Salary, this.Notes, this.IsActive, this.CreationDate, this.ModifiedDate);

            return (this.EmployeeID != -1);
        }

        private bool _UpdateEmployee()
        {
            //call DataAccess Layer 



            return clsEmployeesDAL.UpdateEmployee(
                this.EmployeeID, this.PersonID, this.Designation, this.Department, this.Salary, this.Notes, this.IsActive, this.CreationDate, this.ModifiedDate);
        }



        public static bool DeleteEmployee(int ID)
        {
            return clsEmployeesDAL.DeleteEmployee(ID);
        }

        private void ValidateEmployee()
        {
            var DTO = new EmployeeDTO
            {
                Designation = this.Designation,
                Department = this.Department,
                Salary = this.Salary.ToString(),
                CreationDate = this.CreationDate,
                ModifiedDate = this.ModifiedDate,
                Notes = this.Notes
            };

            if (!BusinessValidationHelper.TryValidateEmployee(DTO, out string error))
            {

                // Log the validation error before throwing
                LogHelper.LogError($"Employee validation failed: {error}");

                throw new ValidationException(error);
            }

        }

        public bool SaveEmployee()
        {
            try
            {
                ValidateEmployee();

                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewEmployee())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        return false;

                    case enMode.Update:
                        return _UpdateEmployee();
                }

                return false;
            }
            catch (ValidationException ex)
            {
                LogHelper.LogError("Validation failed while saving employee.", ex);
                throw; // Optionally rethrow or return false
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Unexpected error in SaveEmployee.", ex);
                throw;
            }
        }




    }
}
