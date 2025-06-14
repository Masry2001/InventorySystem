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


            GetEmployeeInfo();
            SaveEmployeeInfo();

        }



        private void GetEmployeeInfo()
        {

            // Get Person Data From Control
            _Person = ctrlAddEditPersonInfo1.GetPersonData();


            // Get Employee Data From Control
            _Employee = ctrlAddEditEmployeeInfo1.GetEmployeeData();


        }

        private void SaveEmployeeInfo()
        {
            if (_Person.SavePerson())
            {
                _PersonID = _Person.PersonID;

                _Employee.PersonID = _Person.PersonID; 


                if (_Employee.SaveEmployee())
                {
                    _EmployeeID = _Employee.EmployeeID;

                    MessageBox.Show($"Employee saved successfully EmployeeID: {_EmployeeID}, PersonID: {_PersonID} .");
                }
                else
                {
                    MessageBox.Show($"Failed to save employee, PersonID: {_PersonID}.");
                }
            }
            else
            {
                MessageBox.Show("Failed to save person.");
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
