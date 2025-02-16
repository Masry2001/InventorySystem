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

        public frmEmployeeInfo(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
            LoadEmployeeData();
        }

        private void frmEmployeeInfo_Load(object sender, EventArgs e)
        {

        }

        private void LoadEmployeeData()
        {
            ctrlEmployeeCard1.LoadData(_EmployeeID); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
