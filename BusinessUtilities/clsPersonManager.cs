﻿using BusinessUtilities;
using Inventory_DAL;
using SharedUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BusinessUtilities.BusinessValidationHelper;
using Inventory_Models;

namespace Inventory_Business
{



    public class clsPersonManager
    {
        // Properties (match PersonDto)
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public clsPersonManager()
        {
            PersonID = -1;
            Name = "";
            Phone = "";
            Email = "";
            Address = "";
            IsDeleted = false;
            DeletedDate = null;
            Mode = enMode.AddNew;
        }

        public clsPersonManager(int id, string name, string phone, string email, string address, bool isDeleted, DateTime? deletedDate)
        {
            PersonID = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            IsDeleted = isDeleted;
            DeletedDate = deletedDate;
            Mode = enMode.Update;
        }

        public virtual string GetInfo()
        {
            return $"Name: {Name} - Email: {Email}, Phone: {Phone}, Address: {Address}";
        }

        public static clsPersonManager GetPerson(int personID)
        {
            if (clsPeopleDAL.GetPersonById(personID, out PersonDto dto))
            {
                return new clsPersonManager(
                    dto.PersonID,
                    dto.Name,
                    BusinessUtil.GetValueOrDefault(dto.Phone),
                    BusinessUtil.GetValueOrDefault(dto.Email),
                    BusinessUtil.GetValueOrDefault(dto.Address),
                    dto.IsDeleted,
                    dto.DeletedDate
                );
            }

            return null;
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


        private void ValidatePerson()
        {
            if (!BusinessValidationHelper.TryValidatePerson(this, out string error))
            {
                LogHelper.LogError($"Person validation failed: {error}");
                throw new ValidationException(error);
            }
        }

        public bool SavePerson()
        {
            try
            {
                ValidatePerson();

                switch (Mode)
                {
                    case enMode.AddNew:
                        if (_AddNewPerson())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        return false;

                    case enMode.Update:
                        return _UpdatePerson();
                }

                return false;
            }
            catch (ValidationException ex)
            {
                LogHelper.LogError("Validation failed while saving person.", ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.LogError("Unexpected error in SavePerson.", ex);
                throw;
            }
        }





    }

}
