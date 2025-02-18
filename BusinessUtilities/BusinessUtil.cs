using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessUtilities
{
    public class BusinessUtil
    {

        //Purpose: Handles null or empty strings and provides a default value.
        // This Method Will Be Used For Business Layer only
        public static string GetValueOrDefault(string value, string defaultValue = "Unknown")
        {
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        



    }
}
