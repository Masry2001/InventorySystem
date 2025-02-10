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


namespace InventorySystem.Utilities
{
    public partial class ctrlPersonCard : UserControl
    {

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }


        public void LoadPersonData(int PersonId)
        {
            if (clsPersonManager.GetPerson(PersonId, out Dictionary<string, object> personData))
            {
                lblPersonID.Text = PersonId.ToString();
                lblName.Text = Convert.ToString(personData["Name"]);
                lblPhone.Text = Convert.ToString(personData["Phone"]);
                lblEmail.Text = Convert.ToString(personData["Email"]);
                lblAddress.Text = string.IsNullOrEmpty(Convert.ToString(personData["Address"]))
                  ? "Unknown"
                  : Convert.ToString(personData["Address"]);
            }

            else
            {
                MessageBox.Show("Person not found.");
            }
        }

    }
}
