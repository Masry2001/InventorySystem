﻿using System;
using System.Text.RegularExpressions;

namespace SharedUtilities
{

    public static class Validation
    {
        public static bool ValidateEmail(string emailAddress)
        {
            // Updated regex pattern

            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return true;
            }

            string pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)+$";

            return Regex.IsMatch(emailAddress, pattern);
        }

        public static bool IsValidPhone(string Phone)
        {
            if (string.IsNullOrEmpty(Phone))
            {
                return true;
            }
            string pattern = @"^(01[0-2,5]{1}[0-9]{8})$"; // Matches Egypt Phone Numbers Only
            return Regex.IsMatch(Phone, pattern);
        }

        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }

        
        public static bool IsValidSalary(string Salary)
        {
            if (string.IsNullOrEmpty(Salary))
            {
                return true;
            }
            string pattern = @"^\d{1,9}(\.\d{1,4})?$"; // Matches Salary with 2 decimal points
            return Regex.IsMatch(Salary, pattern);
        }

 


    }
}
