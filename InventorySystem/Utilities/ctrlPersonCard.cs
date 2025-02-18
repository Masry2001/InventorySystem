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
using SharedUtilities;


namespace InventorySystem.Utilities
{
    public partial class ctrlPersonCard : UserControl
    {


        private clsPersonManager _Person;

        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPersonManager SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }



        public void LoadPersonData(int PersonId)
        {
            if (( _Person = clsPersonManager.GetPerson(PersonId) ) != null)
            {
                _PersonID = PersonId;

                lblPersonID.Text = PersonId.ToString();
                lblName.Text = _Person.Name;
                lblPhone.Text = _Person.Phone;
                lblEmail.Text = _Person.Email;
                lblAddress.Text = _Person.Address;
            }

            else
            {
                MessageBox.Show("Person not found.");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // open form for editing person info
            frmEditPerson frm = new frmEditPerson(_PersonID);
            frm.ShowDialog();
        }
    }
}
