using Inventory_Business;
using InventorySystem.Utilities;
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
    public partial class frmEditEmployee: Form
    {


        private clsEmployeeManager _Employee;

        private int _EmployeeID = -1;


        public int EmployeeID
        {
            get { return _EmployeeID; }
        }

        public clsEmployeeManager SelectedEmployeeInfo
        {
            get { return _Employee; }
        }


        public frmEditEmployee(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void frmEditEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployeeData();
            dtpModifiedDate.Enabled = false;

        }

        public void LoadEmployeeData()
        {
            if ((_Employee = clsEmployeeManager.GetEmployee(_EmployeeID)) != null)
            {

                lblEmployeeID.Text = _EmployeeID.ToString();
                lblPersonID.Text = _Employee.PersonID.ToString();
                txtDesignation.Text = _Employee.Designation;
                txtDepartment.Text = _Employee.Department;
                txtSalary.Text = _Employee.Salary.ToString();
                txtNotes.Text = _Employee.Notes;
                chkIsActive.Checked = _Employee.IsActive;
                dtpCreationDate.Value = _Employee.CreatedDate;
                dtpModifiedDate.Value = _Employee.ModifiedDate;


            }
                
            else
            {
                MessageBox.Show("Employee not found.");
            }
        }

        // Make Validation Checks 
        // Department and Designation are required fields
        // Salary should be a positive number
        // Notes should not exceed 250 characters
        // Modified Date should be greater than to Created Date
        private void txtDesignation_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateEmptyTextBox(sender, errorProvider1, e);
        }

        private void txtDepartment_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateEmptyTextBox(sender, errorProvider1, e);
        }

        private void txtSalary_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateSalary(sender, errorProvider1, e);
        }

        private void dtpModifiedDate_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateModifiedDate(dtpCreationDate, dtpModifiedDate, errorProvider1, e);
        }

        private void dtpCreationDate_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateCreationDate(dtpCreationDate, dtpModifiedDate, errorProvider1, e);
        }

        private void txtNotes_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateNotesIsLessThan250Char(sender, errorProvider1, e);
        }


        public void SaveEmployeeData()
        {
            if (_Employee == null) return;

            _Employee.Designation = txtDesignation.Text;
            _Employee.Department = txtDepartment.Text;
            if (decimal.TryParse(txtSalary.Text, out decimal salary))
            {
                _Employee.Salary = salary;
            }


            _Employee.Notes = txtNotes.Text;
            _Employee.IsActive = chkIsActive.Checked;
            _Employee.CreatedDate = dtpCreationDate.Value;

            dtpModifiedDate.Value = DateTime.Now;
            _Employee.ModifiedDate = dtpModifiedDate.Value;

            _Employee.Mode = clsEmployeeManager.enMode.Update;

            if (_Employee.SaveEmployee())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            SaveEmployeeData();
        }
    }



}
