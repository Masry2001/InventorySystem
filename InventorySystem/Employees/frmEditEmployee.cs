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
            btnClose.CausesValidation = false;
            _EmployeeID = EmployeeID;

        }


        private void frmEditEmployee_Load(object sender, EventArgs e)
        {
            ctrlAddEditEmployeeInfo1.EmployeeID = _EmployeeID;
            ctrlAddEditEmployeeInfo1.LoadEmployeeData();


        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ctrlAddEditEmployeeInfo1.IsValid())
            {

                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ctrlAddEditEmployeeInfo1.SaveEmployeeData();
        }

    }



}
