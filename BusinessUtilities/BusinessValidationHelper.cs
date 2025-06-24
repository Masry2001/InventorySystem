using Inventory_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedUtilities;

namespace BusinessUtilities
{
    public static class BusinessValidationHelper
    {
        public static bool TryValidatePerson(clsPersonManager person, out string error)
        {
            // Name (Required + Valid + Length)
            if (!Validation.ValidateName(person.Name, out error))
                return false;
            if (!Validation.IsValidFieldByType(person.Name, "Name"))
            {
                error = "Name is too long.";
                return false;
            }

            // Phone (Optional + Egyptian format + Length)
            if (!Validation.IsValidPhone(person.Phone))
            {
                error = "Phone number must be a valid Egyptian number.";
                return false;
            }
            if (!Validation.IsValidFieldByType(person.Phone, "Phone"))
            {
                error = "Phone is too long.";
                return false;
            }

            // Email (Optional + Valid + Length)
            if (!Validation.ValidateEmail(person.Email))
            {
                error = "Invalid email format.";
                return false;
            }
            if (!Validation.IsValidFieldByType(person.Email, "Email"))
            {
                error = "Email is too long.";
                return false;
            }

            // Address (Optional + Length)
            if (!Validation.IsValidFieldByType(person.Address, "Address"))
            {
                error = "Address is too long.";
                return false;
            }

            error = null;
            return true;
        }


        public class EmployeeDTO
        {
            public string Designation { get; set; }
            public string Department { get; set; }
            public string Salary { get; set; } // Keep as string for validation consistency
            public DateTime CreationDate { get; set; }
            public DateTime ModifiedDate { get; set; }
            public string Notes { get; set; }
        }



        public static bool TryValidateEmployee(EmployeeDTO employee, out string error)
        {
            // Designation (Required + Length)
            if (string.IsNullOrWhiteSpace(employee.Designation))
            {
                error = "Designation is required.";
                return false;
            }
            if (!Validation.IsValidFieldByType(employee.Designation, "Name")) // same length as Name
            {
                error = "Designation is too long.";
                return false;
            }

            // Department (Required + Length)
            if (string.IsNullOrWhiteSpace(employee.Department))
            {
                error = "Department is required.";
                return false;
            }
            if (!Validation.IsValidFieldByType(employee.Department, "Name"))
            {
                error = "Department is too long.";
                return false;
            }

            // Salary (Required + Range)
            if (!Validation.IsValidSalary(employee.Salary.ToString()))
            {
                error = $"Salary must be between {ConfigHelper.MinSalary} and {ConfigHelper.MaxSalary}.";
                return false;
            }

            // Notes (Optional + Length)
            if (!Validation.IsValidFieldByType(employee.Notes, "Notes"))
            {
                error = "Notes is too long.";
                return false;
            }



            error = null;
            return true;
        }

        //This creates a specific type of exception for validation errors
        public class ValidationException : Exception
        {
            public ValidationException(string message) : base(message) { }
        }


    }

}
