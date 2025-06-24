using InventorySystem.Utilities;
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

namespace InventorySystem.Employees
{
    public partial class ctrlAddEditEmployeeInfo : UserControl
    {
        public event EventHandler FieldChanged;




        private void OnFieldChanged(object sender, EventArgs e)
        {
            FieldChanged?.Invoke(this, EventArgs.Empty);
        }

        clsEmployeeManager _Employee;
        public ctrlAddEditEmployeeInfo()
        {
            InitializeComponent();
        }
       
        

        private void ctrlAddEditEmployeeInfo_Load(object sender, EventArgs e)
        {
            PresentationUtility.SetTextBoxesMaxLength(this);

            txtDesignation.TextChanged += OnFieldChanged;
            txtDepartment.TextChanged += OnFieldChanged;
            txtSalary.TextChanged += OnFieldChanged;
            txtNotes.TextChanged += OnFieldChanged;

        }

        private bool RunValidation()
        {
            return this.ValidateChildren(ValidationConstraints.Enabled);
        }

        public bool IsValid() => RunValidation();


        public void FocusFirstField()
        {
            txtDesignation.Focus();
        }


        public clsEmployeeManager GetEmployeeData()
        {


            if (_Employee == null)
            {
                _Employee = new clsEmployeeManager();
            }

            if (!RunValidation())
                return null;



            _Employee.Designation = txtDesignation.Text;
            _Employee.Department = txtDepartment.Text;
            _Employee.Salary = Convert.ToDecimal(txtSalary.Text);
            _Employee.Notes = txtNotes.Text;
            _Employee.IsActive = chkIsActive.Checked;
            return _Employee;
        }

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



        // This Code is Used For Edit Employee

        public int EmployeeID;

        public void LoadEmployeeData()
        {
            if ((_Employee = clsEmployeeManager.GetEmployee(EmployeeID)) != null)
            {

                lblEmployeeID.Text = EmployeeID.ToString();
                txtDesignation.Text = _Employee.Designation;
                txtDepartment.Text = _Employee.Department;
                txtSalary.Text = _Employee.Salary.ToString();
                txtNotes.Text = _Employee.Notes;
                chkIsActive.Checked = _Employee.IsActive;
                dtpCreationDate.Value = _Employee.CreationDate;
                dtpModifiedDate.Value = _Employee.ModifiedDate;


            }

            else
            {
                MessageBox.Show("Employee not found.");
            }
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

        private void dtpCreationDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
