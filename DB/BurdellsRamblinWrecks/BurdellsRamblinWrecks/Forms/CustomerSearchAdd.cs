using BurdellsRamblinWrecks.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurdellsRamblinWrecks.Forms
{
    public partial class CustomerSearchAdd : Form
    {
        protected List<Entities.Customer> CustomerResults;

        public Entities.Customer SelectedCustomer { get; private set; }

        public CustomerSearchAdd()
        {
            InitializeComponent();
            InitialDisplay();
        }

        public void InitialDisplay()
        {
            this.radiobtnIndiv.Checked = false;
            this.radiobtnBus.Checked = true;
            this.hideShowPanels();

            this.radiobtnBus.CheckedChanged += RadiobtnBus_CheckedChanged;
        }

        private void RadiobtnBus_CheckedChanged(object sender, EventArgs e)
        {
            this.hideShowPanels();
        }

        private void hideShowPanels()
        {
            if (this.radiobtnBus.Checked)
            {
                this.gbBusiness.Visible = true;
                this.gbBusiness.Enabled = true;
                this.gbIndividual.Visible = false;
                this.gbIndividual.Enabled = false;
            }
            else
            {
                this.gbBusiness.Visible = false;
                this.gbBusiness.Enabled = false;
                this.gbIndividual.Visible = true;
                this.gbIndividual.Enabled = true;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.SelectedCustomer = null;
            this.Close();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            var searchTask = new Tasks.SearchForCustomers();
            this.CustomerResults = searchTask.Search(txtbxPhoneNum.Text, txtbxEmail.Text, txtbxStreet.Text, txtbxState.Text, txtbxPostal.Text, txtbxCity.Text, txtbxIDBus.Text, txtbxNameBus.Text,
                txtbxTitle.Text, tbPrimaryContactFirst.Text, tbPrimaryContactLast.Text, txtbxID.Text, txtbxName.Text, txtbxNamelast.Text, radiobtnIndiv.Checked);

            this.dgvCustomerSearch.DataSource = this.CustomerResults;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear all fields?", "Customer Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtbxPhoneNum.Clear();
                txtbxEmail.Clear();
                txtbxStreet.Clear();
                txtbxState.Clear();
                txtbxPostal.Clear();
                txtbxCity.Clear();
                txtbxIDBus.Clear();
                txtbxNameBus.Clear();
                txtbxTitle.Clear();
                tbPrimaryContactFirst.Clear();
                tbPrimaryContactLast.Clear();
                txtbxID.Clear();
                txtbxName.Clear();
                txtbxNamelast.Clear();
            }
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                try
                {
                    var addCustomerTask = new Tasks.AddCustomer();
                    addCustomerTask.AddNewCustomer(txtbxPhoneNum.Text, txtbxEmail.Text, txtbxStreet.Text, txtbxState.Text, txtbxPostal.Text, txtbxCity.Text, txtbxIDBus.Text, txtbxNameBus.Text,
                        txtbxTitle.Text, tbPrimaryContactFirst.Text, tbPrimaryContactLast.Text, txtbxID.Text, txtbxName.Text, txtbxNamelast.Text, radiobtnIndiv.Checked);

                    // If we've just added a customer we want to close the screen and have the SelectedCustomer equal the one just added.
                    if (radiobtnIndiv.Checked)
                    {
                        //find the invididual inserted
                        var searchTask = new Tasks.SearchForCustomers();
                        this.SelectedCustomer = searchTask.Search(null, null, null, null, null, null, null, null,
                            null, null, null, txtbxID.Text, null, null, radiobtnIndiv.Checked).FirstOrDefault();
                    }
                    else
                    {
                        //find the business inserted
                        var searchTask = new Tasks.SearchForCustomers();
                        this.SelectedCustomer = searchTask.Search(null, null, null, null, null, null, txtbxIDBus.Text, null,
                            null, null, null, null, null, null, radiobtnIndiv.Checked).FirstOrDefault();
                    }

                    this.Close();
                }
                catch (Queries.FriendlyMessageException ex)
                {
                    MessageBox.Show(ex.FriendlyMessage, "Problem Saving Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.SelectedCustomer = null;
            DataGridView dgv = dgvCustomerSearch;
            if (dgv.CurrentRow != null)
            {
                var customer = dgv.CurrentRow.DataBoundItem as Customer;
                if (customer != null)
                {
                    this.SelectedCustomer = customer;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please either select an existing customer or add a new customer before continuing.", "Customer Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool validateFields()
        {
            bool allValid = true;
            string errors = string.Empty;

            if (string.IsNullOrWhiteSpace(this.txtbxPhoneNum.Text) || this.txtbxPhoneNum.Text.Length > 10 || this.txtbxPhoneNum.Text.Length < 7 || !Regex.IsMatch(txtbxPhoneNum.Text, @"^\d+$"))
            {
                errors += "Please enter a 10 digit number, including area code, for phone number. Exclude any dashes or other characters.\n";
                allValid = false;
            }

            if (!string.IsNullOrWhiteSpace(this.txtbxEmail.Text) && (new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(txtbxEmail.Text)))
            {
                errors += "Max characters for email is 50.\n";
                allValid = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtbxStreet.Text) || this.txtbxStreet.Text.Length > 50)
            {
                errors += "Please enter a Street Address up to 50 characters.\n";
                allValid = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtbxCity.Text) || this.txtbxCity.Text.Length > 50)
            {
                errors += "Please enter a City up to 50 characters.\n";
                allValid = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtbxState.Text) || this.txtbxState.Text.Length > 50)
            {
                errors += "Please enter a State up to 50 characters.\n";
                allValid = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtbxPostal.Text) || this.txtbxPostal.Text.Length > 10)
            {
                errors += "Please enter a Postal Code up to 10 characters.\n";
                allValid = false;
            }

            if (radiobtnBus.Checked)
            {
                // business fields 
                if (string.IsNullOrWhiteSpace(this.txtbxIDBus.Text) || this.txtbxIDBus.Text.Length > 50)
                {
                    errors += "Please enter a Tax ID up to 50 characters.\n";
                    allValid = false;
                }

                if (string.IsNullOrWhiteSpace(this.txtbxNameBus.Text) || this.txtbxNameBus.Text.Length > 50)
                {
                    errors += "Please enter a Business Name up to 50 characters.\n";
                    allValid = false;
                }

                if (string.IsNullOrWhiteSpace(this.tbPrimaryContactFirst.Text) || this.tbPrimaryContactFirst.Text.Length > 50)
                {
                    errors += "Please enter a Primary Contact First Name up to 50 characters.\n";
                    allValid = false;
                }

                if (string.IsNullOrWhiteSpace(this.tbPrimaryContactLast.Text) || this.tbPrimaryContactLast.Text.Length > 50)
                {
                    errors += "Please enter a Primary Contact Last Name up to 50 characters.\n";
                    allValid = false;
                }

                if (string.IsNullOrWhiteSpace(this.txtbxTitle.Text) || this.txtbxTitle.Text.Length > 50)
                {
                    errors += "Please enter a Primary Contact Title up to 50 characters.\n";
                    allValid = false;
                }

            }
            else
            {
                // customer fields
                if (string.IsNullOrWhiteSpace(this.txtbxID.Text) || this.txtbxID.Text.Length > 50)
                {
                    errors += "Please enter a Driver's License Number up to 50 characters.\n";
                    allValid = false;
                }

                if (string.IsNullOrWhiteSpace(this.txtbxName.Text) || this.txtbxName.Text.Length > 50)
                {
                    errors += "Please enter a First Name up to 50 characters.\n";
                    allValid = false;
                }

                if (string.IsNullOrWhiteSpace(this.txtbxNamelast.Text) || this.txtbxNamelast.Text.Length > 50)
                {
                    errors += "Please enter a First Name up to 50 characters.\n";
                    allValid = false;
                }
            }

            if (!allValid)
            {
                MessageBox.Show("Please fix the following errors to continue..\n\n" + errors, "Sales Order - Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allValid;
        }
    }
}
