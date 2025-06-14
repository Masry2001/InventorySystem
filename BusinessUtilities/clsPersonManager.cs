using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_DAL;
using BusinessUtilities;
using System.Xml.Linq;

namespace Inventory_Business
{



    public class clsPersonManager
    {
        // Properties   
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;



        public clsPersonManager()
        {
            // Initialize with default values if necessary
            PersonID = -1;
            Name = "";
            Phone = "";
            Email = "";
            Address = "";
            Mode = enMode.AddNew;

        }

        // Parameterized Constructor to Initialize Fields
        public clsPersonManager(int id, string name, string phone, string email, string address)
        {
            PersonID = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            Mode = enMode.Update;
        }


        // Base Class Method to Display Basic Info
        public virtual string GetInfo()
        {
            return $"Name: {Name} - Email: {Email}, Phone: {Phone}, Address: {Address}";
        }


        public static clsPersonManager GetPerson(int PersonID)
        {
            if (clsPeopleDAL.GetPersonById(PersonID, out Dictionary<string, object> personData))
            {
                return new clsPersonManager
                {
                    PersonID = PersonID,
                    Name = personData["Name"].ToString(),
                    Phone = BusinessUtil.GetValueOrDefault(personData["Phone"]?.ToString()),
                    Email = BusinessUtil.GetValueOrDefault(personData["Email"]?.ToString()),
                    Address = BusinessUtil.GetValueOrDefault(personData["Address"]?.ToString())

                };
            }
            return null; // No data found
        }


        private bool _AddNewPerson()
        {
            //call DataAccess Layer

            this.PersonID = clsPeopleDAL.AddNewPerson(this.Name, this.Phone, this.Email,
                this.Address);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPeopleDAL.UpdatePerson(
                this.PersonID, this.Name, this.Phone, this.Email,
                this.Address);
        }

        public bool SavePerson()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }




    }

}
