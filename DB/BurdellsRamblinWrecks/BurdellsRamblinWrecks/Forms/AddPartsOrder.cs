using BurdellsRamblinWrecks.Global_Modules;
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
    public partial class AddPartsOrder : Form
    {
        private string m_VIN;
        private List<Entities.Part> AddedParts = new List<Entities.Part>();
        private string SelectedVendorName = null;
        private string m_poNumber = null;

        public AddPartsOrder(string VIN, string user)
        {
            InitializeComponent();
            m_VIN = VIN;
            tbVin.Text = m_VIN;
            tbUser.Text = user;
            m_poNumber = GenerateOrderID();
            tbPONumber.Text = m_poNumber;
        }

        private string GenerateOrderID()
        {
            var task = new Tasks.PartsOrder();
            var orderid = task.GeneratePONumber(m_VIN);
            return orderid;
        }

        private void btnSearchVendor_Click(object sender, EventArgs e)
        {
            var form = new Forms.SearchVendors();
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var vendorSearch = sender as Forms.SearchVendors;
            if (vendorSearch != null && vendorSearch.SelectedVendor != null)
            {
                this.SelectedVendorName = vendorSearch.SelectedVendor.vendor_name;
                tbVendor.Text = this.SelectedVendorName;
            }
        }

        private void btAddToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateFieldsAddPart())
                {

                    var newPart = new Entities.Part()
                    {
                        partnumber = tbPartNumber.Text,
                        description = tbDescription.Text,
                        cost = decimal.Parse(tbCost.Text),
                        statusid = "ordered"
                    };
                    this.AddedParts.Add(newPart);

                    tbPartNumber.Clear();
                    tbDescription.Clear();
                    tbCost.Clear();

                    bindParts();
                }
            }
            catch (Queries.FriendlyMessageException ex)
            {
                MessageBox.Show(ex.FriendlyMessage, "Problem Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                GlobalFunctions.Log(ex.ToString(), GlobalFunctions.entLogTypes.eAlarm);
                MessageBox.Show("Sorry, we have encountered an error saving your data: " + ex.Message, "Problem Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateFieldsAddPart()
        {
            bool allValid = true;
            string errors = string.Empty;

            if (string.IsNullOrWhiteSpace(tbPartNumber.Text) || tbPartNumber.Text.Length > 50)
            {
                errors += "Please enter a part number of up to 50 characters\n";
                allValid = false;
            }

            if (!string.IsNullOrWhiteSpace(tbDescription.Text) && tbDescription.Text.Length > 200)
            {
                errors += "Please enter up to 200 characters for description\n";
                allValid = false;
            }

            decimal attemptParse;
            if (!decimal.TryParse(tbCost.Text, out attemptParse))
            {
                errors += "Please enter a dollar amount for cost\n";
                allValid = false;
            }

            if (!allValid)
            {
                MessageBox.Show("Please fix the following errors to continue..\n" + errors, "Parts Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allValid;
        }

        private void bindParts()
        {
            this.dgvPartsList.DataSource = this.AddedParts;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.AddedParts = null;
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateFields())
                {
                    var task = new Tasks.PartsOrder();
                    var username = Tasks.Login.GetLoginTask().CurrentUser.username;
                    task.CreatePartsOrder(this.m_VIN, username, m_poNumber, this.SelectedVendorName, this.AddedParts);
                    this.Close();
                }
            }
            catch (Queries.FriendlyMessageException ex)
            {
                MessageBox.Show(ex.FriendlyMessage, "Problem Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                GlobalFunctions.Log(ex.ToString(), GlobalFunctions.entLogTypes.eAlarm);
                MessageBox.Show("Sorry, we have encountered an error saving your data: " + ex.Message, "Problem Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateFields()
        {
            bool allValid = true;
            string errors = string.Empty;

            if (string.IsNullOrEmpty(this.SelectedVendorName))
            {
                errors += "Please select or add a vendor\n";
                allValid = false;
            }

            if (this.AddedParts == null || this.AddedParts.Count == 0)
            {
                errors += "Please add at least 1 part\n";
                allValid = false;
            }

            if (!allValid)
            {
                MessageBox.Show("Please fix the following errors to continue..\n" + errors, "Parts Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allValid;
        }

        private void btAddVendor_Click(object sender, EventArgs e)
        {
            var addVendorForm = new Forms.AddVendor();
            addVendorForm.StartPosition = FormStartPosition.CenterParent;
            addVendorForm.FormClosed += AddVendorForm_FormClosed;
            addVendorForm.ShowDialog();
        }

        private void AddVendorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var addVendorForm = sender as Forms.AddVendor;
            if (addVendorForm != null && !string.IsNullOrWhiteSpace(addVendorForm.AddedVendorName))
            {
                this.SelectedVendorName = addVendorForm.AddedVendorName;
                tbVendor.Text = this.SelectedVendorName;
            }
        }
    }
}