using Inventory_Business;
using InventorySystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Employees
{
    public partial class frmListEmployees : Form
    {

        private static DataTable _dtAllEmployees = clsEmployeeManager.GetAllEmployeesAsDataTable();

        //only select the columns that you want to show in the grid
        //EmployeeID, PersonID, Name, Phone, Email, Address, Designation, Department, Salary,  Notes, IsActive, CreatedDate, ModifiedDate
        private DataTable _dtAllEmployeesWithSpecificColumns = _dtAllEmployees.DefaultView.ToTable(false, "EmployeeID", "Name", "Designation", "Department", "Phone", "Salary", "IsActive");

        private void _RefreshEmployeesList()
        {
            _dtAllEmployees = clsEmployeeManager.GetAllEmployeesAsDataTable();
            _dtAllEmployeesWithSpecificColumns = _dtAllEmployees.DefaultView.ToTable(false, "EmployeeID", "Name", "Designation", "Department", "Phone", "Salary", "IsActive");

            dgvEmployees.DataSource = _dtAllEmployeesWithSpecificColumns;
            lblRecordsCount.Text = dgvEmployees.Rows.Count.ToString();
        }

        private void _MaintainTableWidth()
        {
            var columnSettings = new Dictionary<int, (string header, int width)>
            {
                { 0, ("Employee ID", 140) },
                { 1, ("Full Name", 280) },
                { 2, ("Designation", 150) },
                { 3, ("Department", 150) },
                { 4, ("Phone", 150) },
                { 5, ("Salary", 110) },
                { 6, ("Is Active", 100) }
            };

            PresentationUtility.SetDataGridViewColumns(dgvEmployees, columnSettings);


         
        }

        public frmListEmployees()
        {
            InitializeComponent();
        }

        private void frmListEmployees_Load(object sender, EventArgs e)
        {

            dgvEmployees.DataSource = _dtAllEmployeesWithSpecificColumns;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvEmployees.Rows.Count.ToString();
            cbIsActive.Visible = false;

            _MaintainTableWidth();  


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _RefreshEmployeesList();

            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbSalary.Visible = false;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else if (cbFilterBy.Text == "Salary")
            {
                txtFilterValue.Visible = true;
                cbIsActive.Visible = false;
                cbSalary.Text = string.Empty;
                cbSalary.Visible = true;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
            else
            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;
                cbSalary.Visible = false;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "Salary")
            {
                return;
            }

                // Define a dictionary inside the form
                Dictionary<string, string> filterMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Employee ID", "EmployeeID" },
                { "Full Name", "Name" },
                { "Designation", "Designation" },
                { "Department", "Department" },
                { "Phone", "Phone" },
                { "Salary", "Salary" },
                { "Is Active", "IsActive" }
            };

            string filterColumn;

            // Get mapped column name
            if (!filterMap.TryGetValue(cbFilterBy.Text.Trim(), out filterColumn))
            {
                filterColumn = "None";
            }

            // Call shared method for filtering
            PresentationUtility.ApplyFilter(_dtAllEmployeesWithSpecificColumns, filterColumn, txtFilterValue.Text);

            lblRecordsCount.Text = dgvEmployees.Rows.Count.ToString();
        }



        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string recordCount;
            PresentationUtility.ApplyIsActiveFilter(_dtAllEmployeesWithSpecificColumns, cbIsActive.Text, out recordCount);
            lblRecordsCount.Text = recordCount;
        }

        private void cbSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            string recordCount;
            PresentationUtility.ApplyMoneyFilter(_dtAllEmployeesWithSpecificColumns, "Salary",
                txtFilterValue.Text.Trim(), cbSalary.Text, out recordCount);
            lblRecordsCount.Text = recordCount;
        }


        private void OpenEmployeeInfo()
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
                using (frmEmployeeInfo frm = new frmEmployeeInfo(employeeId))
                {
                    frm.ShowDialog();
                }
                _RefreshEmployeesList();
            }
            else
            {
                MessageBox.Show("Please select an employee.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void employeeInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenEmployeeInfo();
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OpenEmployeeInfo();
            }
        }

        private void updateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                OpenEmployeeInfo();
            
        }

        private void deActivateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
                clsEmployeeManager employee = clsEmployeeManager.GetEmployee(employeeId);

                if (!employee.IsActive) // Employee is already inactive
                {
                    MessageBox.Show("Employee is already inactive.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Deactivate Employee
                employee.IsActive = false;
                employee.ModifiedDate = DateTime.Now;
                if (employee.SaveEmployee())
                {
                    MessageBox.Show("Employee has been deactivated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshEmployeesList();
                    UpdateMenuItemsState(); // Ensure UI reflects changes
                }
                else
                {
                    MessageBox.Show("Failed to deactivate employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void activateEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
                clsEmployeeManager employee = clsEmployeeManager.GetEmployee(employeeId);

                if (employee.IsActive) // Employee is already active
                {
                    MessageBox.Show("Employee is already active.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Activate Employee
                employee.IsActive = true;
                employee.ModifiedDate = DateTime.Now;

                if (employee.SaveEmployee())
                {
                    MessageBox.Show("Employee has been activated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshEmployeesList();
                    UpdateMenuItemsState(); // Ensure UI reflects changes
                }
                else
                {
                    MessageBox.Show("Failed to activate employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // This method is triggered when the selection in DataGridView changes
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            UpdateMenuItemsState();
        }

        // This method ensures correct enabling/disabling of menu items
        private void UpdateMenuItemsState()
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
                clsEmployeeManager employee = clsEmployeeManager.GetEmployee(employeeId);

                // If employee is active, allow deactivation but disable activation
                deActivateEmployeeToolStripMenuItem.Enabled = employee.IsActive;
                activateEmployeeToolStripMenuItem.Enabled = !employee.IsActive;
            }
            else
            {
                // No employee selected, disable both options
                deActivateEmployeeToolStripMenuItem.Enabled = false;
                activateEmployeeToolStripMenuItem.Enabled = false;
            }
        }



        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
