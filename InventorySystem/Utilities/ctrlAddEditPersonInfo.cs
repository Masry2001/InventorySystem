using Inventory_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InventorySystem.Utilities
{
    public partial class ctrlAddEditPersonInfo : UserControl
    {


        clsPersonManager _Person;

        public ctrlAddEditPersonInfo()
        {
            InitializeComponent();
        }


        private void ctrlAddEditPersonInfo_Load(object sender, EventArgs e)
        {

            //The Load event is raised after all controls have been created, added to the visual tree, and initialized.

            PresentationUtility.SetTextBoxesMaxLength(this);

        }

        public clsPersonManager GetPersonData()
        {
            if (_Person == null)
            {
                _Person = new clsPersonManager();
            }
            _Person.Name = txtName.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;
            return _Person;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateName(sender, errorProvider1, e);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidatePhone(sender, errorProvider1, e);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateEmail(sender, errorProvider1, e);

        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateFieldIsLessThan250Char(sender, errorProvider1, e);
        }


    }
}
