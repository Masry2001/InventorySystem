using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;



namespace SharedUtilities
{

    public static class Validation
    {


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


        public static bool IsValidSalary(string salary)
        {

            decimal MinSalary = ConfigHelper.MinSalary;
            decimal MaxSalary = ConfigHelper.MaxSalary;

            if (string.IsNullOrWhiteSpace(salary))
                return false;

            if (!decimal.TryParse(salary, out decimal salaryValue))
                return false;

            return salaryValue >= MinSalary && salaryValue <= MaxSalary;
        }




        // Generic text length validation
        public static bool IsValidTextLength(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text))
                return true; // Empty is considered valid, adjust if needed

            return text.Length <= maxLength;
        }

        
        private static readonly Dictionary<string, int> FieldMaxLengths = new Dictionary<string, int>
        {
            { "Name", ConfigHelper.LengthOf50Char },
            { "Phone", ConfigHelper.LengthOf15Char },
            { "Email", ConfigHelper.LengthOf50Char },
            { "Address", ConfigHelper.LengthOf250Char },
            { "Notes", ConfigHelper.LengthOf250Char },
            // Add More As Needed
        };

        public static bool IsValidFieldByType(string text, string fieldType)
        {
            if (FieldMaxLengths.TryGetValue(fieldType, out int maxLength))
            {
                return IsValidTextLength(text, maxLength);
            }

            // Default to 50 characters if field type not found
            return IsValidTextLength(text, ConfigHelper.LengthOf50Char);
        }



        // Enhanced validation method with specific error messages
        public static bool IsValidDateOrder(DateTime creationDate, DateTime modifiedDate, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (creationDate > modifiedDate)
            {
                errorMessage = "Creation date cannot be later than modified date.";
                return false;
            }

            // Optional: Check for future dates
            if (creationDate > DateTime.Now)
            {
                errorMessage = "Creation date cannot be in the future.";
                return false;
            }

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




    }


}
