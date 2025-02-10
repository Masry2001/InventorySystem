﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_DAL
{
    public class clsPeopleDAL : BaseDAL
    {

        // Find Person Using PersonID
        public static bool GetPersonById(int personId, out Dictionary<string, object> personData)
        {
            return GetEntityById("People", personId, new List<string> { "Name", "Phone", "Email", "Address" }, out personData);
        }



        public static bool GetCustomerById(int customerId, out Dictionary<string, object> customerData)
        {
            return GetEntityById("Customers", customerId, new List<string> { "PersonID", "Notes", "IsActive", "CreatedDate", "ModifiedDate" }, out customerData);
        }


        public static bool GetSupplierById(int supplierId, out Dictionary<string, object> supplierData)
        {
            return GetEntityById("Suppliers", supplierId, new List<string> { "PersonID", "Notes", "IsActive", "CreatedDate", "ModifiedDate" }, out supplierData);
        }



    }
}
