using System;
using System.Text.RegularExpressions;

namespace SharedUtilities
{

    public static class Validation
    {
        public static bool ValidateEmail(string emailAddress)
        {

            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return true; // allow empty email addresses
            }

            string pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)+$";

            return Regex.IsMatch(emailAddress, pattern);
        }

        public static bool IsValidPhone(string Phone)
        {
            if (string.IsNullOrWhiteSpace(Phone))
            {
                return true; // allow empty phone numbers
            }
            string pattern = @"^(01[0-2,5]{1}[0-9]{8})$"; // Matches Egypt Phone Numbers Only
            return Regex.IsMatch(Phone, pattern);
        }

        public static bool ValidateName(string name, out string error)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                error = "RequiredField";
                return false;
            }

            if (!Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                error = "InvalidName";
                return false;
            }

            error = string.Empty;
            return true;
        }


        public static bool ValidateInteger(string Number)
        {
            if (string.IsNullOrWhiteSpace(Number))
                return false;

            var pattern = @"^\d+$"; // 1 or more digits
            return Regex.IsMatch(Number, pattern);
        }


        public static bool ValidateFloat(string Number)
        {
            if (string.IsNullOrWhiteSpace(Number))
                return false;

            var pattern = @"^\d+(\.\d+)?$";
            return Regex.IsMatch(Number, pattern);
        }


        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }

        
        public static bool IsValidSalary(string Salary)
        {
            if (string.IsNullOrWhiteSpace(Salary))
            {
                return false;
            }
            string pattern = @"^\d{1,9}(\.\d{1,4})?$"; // Matches Salary with 2 decimal points
            return Regex.IsMatch(Salary, pattern);
        }

 


    }
}
