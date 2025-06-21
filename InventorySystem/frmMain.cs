using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Inventory_Business;
using InventorySystem.Employees;

namespace Inventory_Presentation
{


    public partial class frmMain : Form
    {


        public frmMain() // Constructor
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListEmployees frm = new frmListEmployees();


            //This way you simulate modal behavior without ShowDialog().


            this.Enabled = false; // disable frmMain
            frm.FormClosed += (s, args) => this.Enabled = true; // re-enable after closing
            frm.Show();

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
