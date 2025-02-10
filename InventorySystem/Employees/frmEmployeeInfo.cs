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
    public partial class frmEmployeeInfo : Form
    {

        private int _EmployeeID;
        private int _PersonID;

        public frmEmployeeInfo(int EmployeeID,  int PersonID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
            _PersonID = PersonID;
            LoadEmployeeData();
        }

        private void frmEmployeeInfo_Load(object sender, EventArgs e)
        {

        }

        private void LoadEmployeeData()
        {
            // Load and display employee details using _employeeId and _personId
            //ctrlEmployeeCard1.LoadUserInfo(_UserID);
            ctrlEmployeeCard1.LoadEmployeeData(_EmployeeID, _PersonID); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
