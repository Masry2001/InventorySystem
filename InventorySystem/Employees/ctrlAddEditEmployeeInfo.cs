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
            _Employee.CreationDate = dtpCreationDate.Value;
            _Employee.ModifiedDate = dtpModifiedDate.Value;
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



        private void dtpCreationDate_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateCreationDate(dtpCreationDate, dtpModifiedDate, errorProvider1, e);
            
        }

        private void dtpModifiedDate_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateModifiedDate(dtpCreationDate, dtpModifiedDate, errorProvider1, e);
        }




    }
}
