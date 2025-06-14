using Inventory_Business;
using InventorySystem.Utilities;
using SharedUtilities;
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
    public partial class ctrlEmployeeCard : UserControl
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

        public ctrlEmployeeCard()
        {
            InitializeComponent();
        }

        private void ctrlEmployeeCard_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(int EmployeeID)
        {

            LoadEmployeeData(EmployeeID);

            int PersonID = _Employee.PersonID;
            ctrlPersonCard1.LoadPersonData(PersonID);

        }




        private void LoadEmployeeData(int EmployeeID)
        {

            if (( _Employee = clsEmployeeManager.GetEmployee(EmployeeID)) != null)
            {
                _EmployeeID = EmployeeID;

                lblEmployeeID.Text = EmployeeID.ToString();
                lblDesignation.Text = _Employee.Designation;
                lblDepartment.Text = _Employee.Department;
                lblSalary.Text = Convert.ToString(_Employee.Salary);
                lblCreationDate.Text = Convert.ToString(_Employee.CreationDate);
                lblModifiedDate.Text = Convert.ToString(_Employee.ModifiedDate);
                lblIsActive.Text = _Employee.ActiveStatus;
                lblNotes.Text = _Employee.Notes;
            }

            else
            {
                MessageBox.Show("Employee Data not found.");
            }

        }

        private void llEditEmployeeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditEmployee frm = new frmEditEmployee(_EmployeeID);
            frm.ShowDialog();
            LoadEmployeeData(_EmployeeID);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
