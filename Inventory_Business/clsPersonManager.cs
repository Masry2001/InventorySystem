using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_DAL;
using BusinessUtilities;

namespace Inventory_Business
{



    public class clsPersonManager
    {
        // Properties   
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }



        public clsPersonManager()
        {
            // Initialize with default values if necessary
        }

        // Parameterized Constructor to Initialize Fields
        public clsPersonManager(int id, string name, string phone, string email, string address)
        {
            PersonId = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }

        // Validation Methods
        //Before Saving Data to the Database (During Create/Update Operations).
        //During User Input Validation(e.g., in a UI form before allowing submission).
        public bool IsValidEmail()
        {
            if (string.IsNullOrEmpty(Email)) return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return addr.Address == Email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPhone()
        {
            if (string.IsNullOrEmpty(Phone)) return false;
            string pattern = @"^(01[0-2,5]{1}[0-9]{8})$"; // Matches Egypt Phone Numbers Only
            return System.Text.RegularExpressions.Regex.IsMatch(Phone, pattern);
        }

        // Base Class Method to Display Basic Info
        public virtual string GetInfo()
        {
            return $"Name: {Name} - Email: {Email}, Phone: {Phone}, Address: {Address}";
        }


        public static bool GetPerson(int personId, out Dictionary<string, object> personData)
        {
            return clsPeopleDAL.GetPersonById(personId, out personData);

        }

        public static clsPersonManager GetPerson(int personId)
        {
            if (clsPeopleDAL.GetPersonById(personId, out Dictionary<string, object> personData))
            {
                return new clsPersonManager
                {
                    PersonId = personId,
                    Name = personData["Name"].ToString(),
                    Phone = BusinessUtil.GetValueOrDefault(personData["Phone"]?.ToString()),
                    Email = BusinessUtil.GetValueOrDefault(personData["Email"]?.ToString()),
                    Address = BusinessUtil.GetValueOrDefault(personData["Address"]?.ToString())

                };
            }
            return null; // No data found
        }






    }

}
