using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            return conn ?? "Server=.;Database=InventoryDB;User Id=sa;Password=sa123456";
        }

    }
}
