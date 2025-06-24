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

namespace InventorySystem.Utilities
{
    public partial class ctrlAddEditPersonInfo : UserControl
    {




        public event EventHandler FieldChanged;


        private void OnFieldChanged(object sender, EventArgs e)
        {
            FieldChanged?.Invoke(this, EventArgs.Empty);
        }


        clsPersonManager _Person;

        public ctrlAddEditPersonInfo()
        {
            InitializeComponent();
        }


        private void ctrlAddEditPersonInfo_Load(object sender, EventArgs e)
        {

            PresentationUtility.SetTextBoxesMaxLength(this);

            //Whenever TextChanged happens, automatically .NET Framework call the OnFieldChanged method
            //👤 User types in textbox
            //      ↓
            //🔁 .NET says: “Ah! Text changed”
            //      ↓
            //🎯 Calls: OnFieldChanged(sender, e)
            //      ↓
            //📢 OnFieldChanged raises: FieldChanged event
            //      ↓
            //🏃 Parent Form hears it, runs: ValidateAll(sender, e)
            //      ↓
            //✅ Checks all inputs and enables Save button if valid
            txtName.TextChanged += OnFieldChanged;
            txtPhone.TextChanged += OnFieldChanged;
            txtEmail.TextChanged += OnFieldChanged;
            txtAddress.TextChanged += OnFieldChanged;


            txtAddress.PreviewKeyDown += txtAddress_PreviewKeyDown;


        }

        private bool RunValidation()
        {
            return this.ValidateChildren(ValidationConstraints.Enabled);
        }

        public bool IsValid() => RunValidation();

        public clsPersonManager GetPersonData()
        {
            if (_Person == null)
                _Person = new clsPersonManager();

            if (!RunValidation())
                return null;

            _Person.Name = txtName.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;

            return _Person;
        }


        private void txtName_Validating(object sender, CancelEventArgs e)
        {


            PresentationUtility.ValidateName(sender, errorProvider1, e);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidatePhone(sender, errorProvider1, e);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            PresentationUtility.ValidateEmail(sender, errorProvider1, e);

        }




        public event EventHandler MoveToNextTab;

        private void txtAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                // Tell the parent to move to the next tab
                MoveToNextTab?.Invoke(this, EventArgs.Empty);

                // Optional: prevent default tabbing behavior
                e.IsInputKey = true; // Makes Tab act like a regular key
            }
        }


        public void FocusFirstField()
        {
            txtName.Focus();
        }









        // The Following Code Is For Editing Person Data    

        public int PersonID = -1;
        public void LoadPersonData()
        {
            if ((_Person = clsPersonManager.GetPerson(PersonID)) != null)
            {

                lblPersonID.Text = PersonID.ToString();
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


    }
}
