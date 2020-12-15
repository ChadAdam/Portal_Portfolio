using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurdellsRamblinWrecks.Forms
{
    public partial class AddVendor : Form
    {
        public string AddedVendorName { get; set; }

        public AddVendor()
        {
            InitializeComponent();
            cbState.Items.AddRange(fiftyStates);
        }


        string[] fiftyStates = new string[50]
        {
            "Alabama",
            "Alaska",
            "Arizona",
            "Arkansas",
            "California",
            "Colorado",
            "Connecticut",
            "Delaware",
            "Florida",
            "Georgia",
            "Hawaii",
            "Idaho",
            "Illinois",
            "Indiana",
            "Iowa",
            "Kansas",
            "Kentucky",
            "Louisiana",
            "Maine",
            "Maryland",
            "Massachusetts",
            "Michigan",
            "Minnesota",
            "Mississippi",
            "Missouri",
            "Montana",
            "Nebraska",
            "Nevada",
            "New Hampshire",
            "New Jersey",
            "New Mexico",
            "New York",
            "North Carolina",
            "North Dakota",
            "Ohio",
            "Oklahoma",
            "Oregon",
            "Pennsylvania",
            "Rhode Island",
            "South Carolina",
            "South Dakota",
            "Tennessee",
            "Texas",
            "Utah",
            "Vermont",
            "Virginia",
            "Washington",
            "West Virginia",
            "Wisconsin",
            "Wyoming"
        };

        private void BtnAddVendor_Click(object sender, EventArgs e)
        {
            foreach (Control c in gbVendorDetails.Controls.OfType<TextBox>())
            {
                if (c.Text == null || this.Text == "")
                {
                    throw new Queries.FriendlyMessageException("Please Fill In All Applicable Fields!");
                }
            }
            if (cbState.SelectedItem == null || cbState.SelectedItem.ToString() == null || cbState.SelectedItem.ToString() == "")
            {
                throw new Queries.FriendlyMessageException("Please Fill In All Applicable Fields!");
            }
            else
            {
                Tasks.AddVendor AV = new Tasks.AddVendor();
                AV.AddNewVendor(txtName.Text, txtStreet.Text, txtCity.Text, cbState.SelectedItem.ToString(), txtPostal.Text, txtPhone.Text);
                this.AddedVendorName = txtName.Text;
                this.Close();
            }
                
        }
            
    }
}
