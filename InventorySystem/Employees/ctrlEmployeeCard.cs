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
    public partial class ctrlEmployeeCard : UserControl
    {

        public ctrlEmployeeCard()
        {
            InitializeComponent();
        }

        private void ctrlEmployeeCard_Load(object sender, EventArgs e)
        {

        }

        public void LoadEmployeeData(int EmployeeID, int PersonID)
        {
            // we want to get personId then send it to ctrlPersonCard.LoadPersonData(personID)
            ctrlPersonCard1.LoadPersonData(PersonID);

            // load data for employee 
            LoadEmployeeData(EmployeeID);
        }

        private void LoadEmployeeData(int EmployeeID)
        {

            if (clsEmployeeManager.GetEmployee(EmployeeID, out Dictionary<string, object> EmployeeData))
            {
             
                lblEmployeeID.Text = EmployeeID.ToString();
                lblDesignation.Text = Convert.ToString(EmployeeData["Designation"]);
                lblDepartment.Text = Convert.ToString(EmployeeData["Department"]);
                lblSalary.Text = EmployeeData["Salary"]?.ToString() ?? "0.00";
                lblCreationDate.Text = Convert.ToString(EmployeeData["CreatedDate"]);
                lblModifiedDate.Text = Convert.ToString(EmployeeData["ModifiedDate"]);
                lblIsActive.Text = (bool)EmployeeData["IsActive"] ? "Active" : "Inactive";
                lblNotes.Text = string.IsNullOrEmpty(Convert.ToString(EmployeeData["Notes"]))
                  ? "No Notes"
                  : Convert.ToString(EmployeeData["Notes"]);

            }

            else
            {
                MessageBox.Show("Employee Data not found.");
            }

        }

    }
}
