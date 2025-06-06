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

namespace InventorySystem.Employees
{
    public partial class frmAddEmployee : Form
    {

        private int _PersonID = -1;
        private int _EmployeeID = -1;
        clsPersonManager _Person;
        clsEmployeeManager _Employee;

        public frmAddEmployee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

           

            // Save Person Info

            SavePersonInfo();
            // Save Employee Info

        }


        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    bool allValid = true;

        //    if (string.IsNullOrWhiteSpace(txtName.Text))
        //    {
        //        errorProvider1.SetError(txtName, "Name is required.");
        //        allValid = false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtEmail.Text))
        //    {
        //        errorProvider1.SetError(txtEmail, "Email is required.");
        //        allValid = false;
        //    }

        //    // Add more fields as needed...

        //    if (!allValid)
        //    {
        //        MessageBox.Show("Please fill in all required fields before saving.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Proceed to save...
        //}


        private void SavePersonInfo()
        {
           

            _Person = ctrlAddEditPersonInfo1.GetPersonData();


        }
    }
}
