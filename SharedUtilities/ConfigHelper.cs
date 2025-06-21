using System;
using System.Configuration;

namespace SharedUtilities
{
    public static class ConfigHelper
    {
        // Retrieves the connection string by name.
        public static string GetConnectionString(string name)
        {
            string conn = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;

            if (string.IsNullOrEmpty(conn))
            {
                Console.WriteLine($"⚠️ Warning: Connection string '{name}' not found in app.config!");
            }

            return conn;
        }


        public static int LengthOf250Char
        {
            get
            {
                if (int.TryParse(ConfigurationManager.AppSettings["LengthOf250Char"], out int value))
                    return value;
                else
                    return 250;
            }
        }

        public static int LengthOf50Char
        {
            get
            {
                if (int.TryParse(ConfigurationManager.AppSettings["LengthOf50Char"], out int value))
                    return value;
                else
                    return 50;
            }
        }

        public static int LengthOf15Char
        {
            get
            {
                if (int.TryParse(ConfigurationManager.AppSettings["LengthOf15Char"], out int value))
                    return value;
                else
                    return 15;
            }
        }

        public static decimal MinSalary
        {
            get
            {
                if (decimal.TryParse(ConfigurationManager.AppSettings["MinSalary"], out decimal value))
                    return value;
                else
                    return 0.00m; // Default value if parsing fails
            }
        }

        public static decimal MaxSalary
        {
            get
            {
                if (decimal.TryParse(ConfigurationManager.AppSettings["MaxSalary"], out decimal value))
                    return value;
                else
                    return 200000.99m; // Default value if parsing fails
            }
        }

    }
}
