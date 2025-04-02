using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedUtilities;
using System.Runtime.Remoting.Messaging;

namespace Inventory_DAL
{


    public class clsEmployeesDAL : BaseDAL
    {

    
        public static DataTable GetAllEmployeesAsDataTable()
        {
            string Query = "SELECT * FROM EmployeesData;";
            return ExecuteDataTable(Query);
        }

        public static int GetPersonIdByEmployeeId(int employeeId)
        {
            return GetPersonIdByEntityId("Employees", "EmployeeID", employeeId);
        }

        public static int GetPersonIdByCustomerId(int customerId)
        {
            return GetPersonIdByEntityId("Customers", "CustomerID", customerId);
        }

        public static int GetPersonIdBySupplierId(int supplierId)
        {
            return GetPersonIdByEntityId("Suppliers", "SupplierID", supplierId);
        }

        public static bool GetEmployeeById(int employeeId, out Dictionary<string, object> employeeData)
        {
            return GetEntityById("Employees", employeeId, new List<string> { "PersonID", "Designation", "Department", "Salary", "Notes", "IsActive", "CreatedDate", "ModifiedDate" }, out employeeData);
        }

        public static bool UpdateEmployee(int employeeId, int personId, string designation, string department, decimal salary, string notes, bool isActive, DateTime createdDate, DateTime modifiedDate)
        {
            return UpdateEntity("Employees", employeeId, new Dictionary<string, object> { { "Designation", designation }, { "Department", department }, { "Salary", salary }, { "Notes", notes }, { "IsActive", isActive }, { "CreatedDate", createdDate }, { "ModifiedDate", modifiedDate } });
        }

        public static bool DeleteEmployee(int employeeId)
        {
            return DeleteEntity("Employees", employeeId);
        }

    }
}
