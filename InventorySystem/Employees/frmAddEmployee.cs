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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            ctrlAddEditPersonInfo1.FocusFirstField();


            // this means “Dear ctrlAddEditEmployeeInfo, if you raise your FieldChanged event, I want you to call my method ValidateAll().”

            ctrlAddEditPersonInfo1.FieldChanged += ValidateAll;
            ctrlAddEditEmployeeInfo1.FieldChanged += ValidateAll;

            ctrlAddEditPersonInfo1.MoveToNextTab += MoveToEmployeeTab;

        }

        private void ValidateAll(object sender, EventArgs e)
        {
            btnSave.Enabled =
                ctrlAddEditPersonInfo1.IsValid() &&
                ctrlAddEditEmployeeInfo1.IsValid();
        }


        private void MoveToEmployeeTab(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tpEmployee;
            ctrlAddEditEmployeeInfo1.FocusFirstField();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TrySaveEmployee())
            {
                MessageBox.Show($"Employee saved successfully.\nEmployeeID: {_EmployeeID}, PersonID: {_PersonID}.");
                this.DialogResult = DialogResult.OK; // Automatically closes the form
            }
            else
            {
                MessageBox.Show("Failed to save employee information.");
            }
        }

        private bool TrySaveEmployee()
        {
            if (!CollectEmployeeData())
                return false;

            if (!_Person.SavePerson())
            {
                MessageBox.Show("Failed to save person data.");
                return false;
            }

            _PersonID = _Person.PersonID;
            _Employee.PersonID = _PersonID;

            if (!_Employee.SaveEmployee())
            {
                MessageBox.Show($"Failed to save employee record (PersonID: {_PersonID}).");
                return false;
            }

            _EmployeeID = _Employee.EmployeeID;
            return true;
        }

        private bool CollectEmployeeData()
        {
            _Person = ctrlAddEditPersonInfo1.GetPersonData();
            _Employee = ctrlAddEditEmployeeInfo1.GetEmployeeData();

            if (_Person == null || _Employee == null)
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

  
    }
}
