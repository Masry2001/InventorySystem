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
    public partial class frmEditPerson : Form
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
        public frmEditPerson(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void frmEditPerson_Load(object sender, EventArgs e)
        {
            LoadPersonData();
        }

        public void LoadPersonData()
        {
            if ((_Person = clsPersonManager.GetPerson(_PersonID)) != null)
            {

                lblPersonID.Text = _PersonID.ToString();
                txtName.Text = _Person.Name;
                txtPhone.Text = _Person.Phone;
                txtEmail.Text = _Person.Email;
                txtAddress.Text = _Person.Address;
            }

            else
            {
                MessageBox.Show("Person not found.");
            }
        }

        public void SavePersonData()
        {
            if (_Person == null) return;

            _Person.Name = txtName.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;
            _Person.Mode = clsPersonManager.enMode.Update;

            if (_Person.SavePerson())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            SavePersonData();

        }


        // make the validation function Generic and move them to Shared Utility Class

        private void txtEmail_Validating_1(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateEmail(sender, errorProvider1, e);

        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateEmptyTextBox(sender, errorProvider1, e);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidatePhone(sender, errorProvider1, e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
