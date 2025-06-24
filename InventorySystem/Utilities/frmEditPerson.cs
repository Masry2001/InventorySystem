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
            btnClose.CausesValidation = false;
            _PersonID = personID;
        }

        private void frmEditPerson_Load(object sender, EventArgs e)
        {
            ctrlAddEditPersonInfo1.PersonID = _PersonID;
            ctrlAddEditPersonInfo1.LoadPersonData();
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ctrlAddEditPersonInfo1.IsValid())
            {

                MessageBox.Show("Some fileds are not valide!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            ctrlAddEditPersonInfo1.SavePersonData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
