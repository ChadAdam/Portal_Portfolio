using BurdellsRamblinWrecks.Entities;
using BurdellsRamblinWrecks.Global_Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurdellsRamblinWrecks.Forms
{
    public partial class AddVehicle : Form
    {
        protected Customer SelectedCustomer;
        public Vehicle Vehicle { get; set; }

        protected List<Vehicle> VehicleResults = null;
        protected List<VehicleType> mVehicleTypes = null;
        protected List<Manufacturer> mManufacturers = null;
        protected List<VehicleColor> mColors = null;
        protected List<Condition> mConditions = null;

        public AddVehicle()
        {
            InitializeComponent();
            InitialDisplay();
        }

        public void InitialDisplay()
        {
            var searchTask = new Tasks.SearchForVehicles();

            //cbVehicleType.ValueMember = "VehicleTypeId";
            cbVehicleType.DisplayMember = "VehicleTypeId";
            mVehicleTypes = searchTask.GetVehicleTypes();
            foreach (var vehicleType in mVehicleTypes)
            {
                cbVehicleType.Items.Add(new { vehicleType.VehicleTypeId });
            }
            cbVehicleType.Items.Insert(0, new { VehicleTypeId = "* Please Select *" });
            cbVehicleType.SelectedIndex = 0;

            //cbManufactorer.ValueMember = "ManufacturerId";
            cbManufacturer.DisplayMember = "ManufacturerId";
            mManufacturers = searchTask.GetManufacturers();
            foreach (var manufacturer in mManufacturers)
            {
                cbManufacturer.Items.Add(new { manufacturer.ManufacturerId });
            }
            cbManufacturer.Items.Insert(0, new { ManufacturerId = "* Please Select *" });
            cbManufacturer.SelectedIndex = 0;

            //cbColor.ValueMember = "ColorId";
            //.DisplayMember = "ColorId";
            mColors = searchTask.GetColors();
            foreach (var color in mColors)
            {
                lbColors.Items.Add(color.ColorId);
            }

            cbCondition.DisplayMember = "ConditionId";
            mConditions = new BurdellsRamblinWrecks.Tasks.AddVehicle().GetConditions();
            foreach (var condition in mConditions)
            {
                cbCondition.Items.Add(new { condition.ConditionId });
            }
            cbCondition.Items.Insert(0, new { Conditionid = "* Please Select *" });
            cbCondition.SelectedIndex = 0;
        }

        private void btFindOrAddCustomer_Click(object sender, EventArgs e)
        {
            var customerAddSearchForm = new Forms.CustomerSearchAdd();
            customerAddSearchForm.StartPosition = FormStartPosition.CenterParent;
            customerAddSearchForm.FormClosed += CustomerAddSearchForm_FormClosed;
            customerAddSearchForm.ShowDialog();
        }

        private void CustomerAddSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var customerAddSearchForm = sender as Forms.CustomerSearchAdd;
            if (customerAddSearchForm != null && customerAddSearchForm.SelectedCustomer != null)
            {
                this.SelectedCustomer = customerAddSearchForm.SelectedCustomer;
                customerAddSearchForm.FormClosed -= CustomerAddSearchForm_FormClosed;
                BindCustomerFields();
            }
        }

        public void BindCustomerFields()
        {
            txtbxStreet.Text = this.SelectedCustomer.address_street;
            txtbxCity.Text = this.SelectedCustomer.address_city;
            txtbxState.Text = this.SelectedCustomer.address_state;
            txtbxPostal.Text = this.SelectedCustomer.address_postal_code;
            txtbxEmail.Text = this.SelectedCustomer.email;
            txtbxPhoneNum.Text = this.SelectedCustomer.phone_number;
            radiobtnBus.Checked = this.SelectedCustomer.IsBusiness;
            radiobtnIndiv.Checked = !this.SelectedCustomer.IsBusiness;

            gbBusiness.Visible = this.SelectedCustomer.IsBusiness;
            gbBusiness.Enabled = this.SelectedCustomer.IsBusiness;
            gbIndividual.Visible = !this.SelectedCustomer.IsBusiness;
            gbIndividual.Enabled = !this.SelectedCustomer.IsBusiness;

            txtbxIDBus.Text = this.SelectedCustomer.tax_identification_number;
            tbPrimaryContactFirst.Text = this.SelectedCustomer.primary_contact_first_name;
            tbPrimaryContactLast.Text = this.SelectedCustomer.primary_contact_last_name;
            tbBusinessName.Text = this.SelectedCustomer.business_name;
            tbContactTitle.Text = this.SelectedCustomer.primary_contact_title;

            txtbxName.Text = this.SelectedCustomer.first_name;
            txtbxNamelast.Text = this.SelectedCustomer.last_name;
            txtbxID.Text = this.SelectedCustomer.drivers_license_number;
        }

        private void btCancelSale_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cancel Purchase?", "Are you sure you wish to cancel this vehicle purchase?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.SelectedCustomer = null;
                this.Vehicle = null;
                this.Close();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateFields())
                {
                    var addSalesOrderTask = new Tasks.AddVehicle();
                    this.Vehicle = addSalesOrderTask.InsertNewVehicle(tbVin.Text, tbModelName.Text, tbModelYear.Text, tbMileage.Text, tbDescription.Text,
                        DateTime.Parse(tbPurchaseDate.Text),
                        decimal.Parse(tbPurchasePrice.Text),
                        (cbVehicleType.SelectedIndex == 0 ? null : (cbVehicleType.SelectedItem as dynamic).VehicleTypeId),
                        (cbManufacturer.SelectedIndex == 0 ? null : (cbManufacturer.SelectedItem as dynamic).ManufacturerId),
                        getSelectedColorIds(),
                        (cbCondition.SelectedIndex == 0 ? null : (cbCondition.SelectedItem as dynamic).ConditionId),
                        this.SelectedCustomer.customerID);
                  
                    MessageBox.Show("Vehicle Purchase Completed!", "Add Vechicle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private List<string> getSelectedColorIds()
        {
            return lbColors.CheckedItems.OfType<string>().ToList();         
        }

        private bool validateFields()
        {
            bool allValid = true;
            string errors = string.Empty;

            if (this.SelectedCustomer == null)
            {
                errors += "Please search for an existing customer or add a new Customer to continue.";
                allValid = false;
            }
            
            if (string.IsNullOrWhiteSpace(tbVin.Text) || tbVin.Text.Length > 50)
            {
                errors += "Please enter a VIN up to 50 characters.\n";
                allValid = false;
            }

            if (cbVehicleType.SelectedIndex == 0)
            {
                errors += "Please select a Vehicle Type.\n";
                allValid = false;
            }

            if (string.IsNullOrWhiteSpace(tbModelYear.Text))
            {
                errors += "Please enter a 4 digit year that does not exceed the current year plus 1.";
                allValid = false;
            }

            DateTime attemptedParse = default(DateTime);
            if (!string.IsNullOrWhiteSpace(tbModelYear.Text) && !DateTime.TryParseExact(tbModelYear.Text, "yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out attemptedParse))
            {
                errors += "Please enter a 4 digit year that does not exceed the current year plus 1.";
                allValid = false;
            }

            var currentYear = DateTime.Now.Year;
            if (attemptedParse.Year > (currentYear + 1))
            {
                errors += "Please enter a 4 digit year that does not exceed the current year plus 1.";
                allValid = false;
            }

            if (cbManufacturer.SelectedIndex == 0)
            {
                errors += "Please select a manufacturer";
                allValid = false;
            }

            if (string.IsNullOrWhiteSpace(tbModelName.Text) || tbModelName.Text.Length > 50)
            {
                errors += "Please enter a Model Name up to 50 characters.\n";
                allValid = false;
            }

            if (cbCondition.SelectedIndex == 0)
            {
                errors += "Please select a condition for the vehicle";
                allValid = false;
            }

            decimal attemptedMileage = 0m;
            if (!decimal.TryParse(tbMileage.Text, out attemptedMileage))
            {
                errors += "Please enter a numeric value for Mileage";
                allValid = false;
            }

            decimal attemptedPurchasePrice = 0m;
            if (!decimal.TryParse(tbPurchasePrice.Text, out attemptedPurchasePrice))
            {
                errors += "Please enter a numeric value for Purchase Price (KBB Value)";
                allValid = false;
            }

            if (!string.IsNullOrWhiteSpace(tbDescription.Text) && tbDescription.Text.Length > 200)
            {
                errors += "Please enter up to 200 characters for the description";
                allValid = false;
            }

            DateTime attemptedParsePurchaseDate = default(DateTime);
            if (string.IsNullOrWhiteSpace(tbPurchaseDate.Text) || !DateTime.TryParse(tbPurchaseDate.Text, out attemptedParsePurchaseDate))
            {
                errors += "Please enter a valid date in mm/dd/yyyy format for a Sales Date.";
                allValid = false;
            }

            if (!allValid)
            {
                MessageBox.Show("Please fix the following errors to continue..\n" + errors, "Add Vehicle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allValid;
        }
    }   
}
