using System;

using System.Configuration;

namespace SharedUtilities
{
    public class ConfigHelper
    {
        // Retrieves the connection string by name.
        public static string GetConnectionString(string name)
        {
            string conn = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;

            if (string.IsNullOrEmpty(conn))
            {
                Console.WriteLine($"⚠️ Warning: Connection string '{name}' not found in app.config!");
            }

            return conn ;
        }

    }
}
