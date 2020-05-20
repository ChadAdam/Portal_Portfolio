using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BurdellsRamblinWrecks.Entities;
using BurdellsRamblinWrecks.Global_Modules;

namespace BurdellsRamblinWrecks.Forms
{
    public partial class SalesOrder : Form
    {
        protected Vehicle Vehicle;
        protected Customer SelectedCustomer;
        protected decimal? CalculatedSalesPrice;

        public SalesOrder()
        {
            InitializeComponent();
            btFindOrAddCustomer.Focus();
            this.rbLoanYes.CheckedChanged += RbLoanYes_CheckedChanged;

            tbStartingMonth.Enabled = false;
            tbLoanTerm.Enabled = false;
            tbMonthlyPayment.Enabled = false;
            tbInterestRate.Enabled = false;
            tbDownPayment.Enabled = false;
            rbLoanNo.Checked = true;
        }
        
        public void SendVehicle(Vehicle vehicleToSell)
        {
            this.Vehicle = vehicleToSell;
            BindVehicleFields();
        }

        public void BindVehicleFields()
        {
            tbVin.Text = this.Vehicle.VIN;
            cbVehicleType.Text = this.Vehicle.vehicleTypeId;
            tbModelName.Text = this.Vehicle.model_name;
            tbModelYear.Text = this.Vehicle.model_year;
            tbMileage.Text = this.Vehicle.mileage;
            cbManufacturer.Text = this.Vehicle.manufacturerId;
            tbColors.Text = this.Vehicle.color;
            tbSalesPrice.Text = this.Vehicle.sales_price.ToString("C");
            tbDescription.Text = this.Vehicle.description;

            calculateSalesPrice();
            tbSalesPrice2.Text = this.CalculatedSalesPrice.HasValue ? this.CalculatedSalesPrice.Value.ToString("C") : "Not Calculated";
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

        private void btCancelSale_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cancel Sale?", "Are you sure you wish to cancel this sale?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.SelectedCustomer = null;
                this.Vehicle = null;
                this.CalculatedSalesPrice = null;
                this.Close();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateFields())
                {
                    var addSalesOrderTask = new Tasks.AddSalesOrder();
                    if (rbLoanYes.Checked)
                    {
                        addSalesOrderTask.InsertNewSalesOrder(this.Vehicle.VIN, this.SelectedCustomer.customerID, DateTime.Parse(tbSalesDate.Text), this.CalculatedSalesPrice.GetValueOrDefault(0m)
                         , rbLoanYes.Checked, decimal.Parse(tbDownPayment.Text), tbStartingMonth.Text, int.Parse(tbLoanTerm.Text), decimal.Parse(tbMonthlyPayment.Text), decimal.Parse(tbInterestRate.Text));
                    }
                    else
                    {
                        addSalesOrderTask.InsertNewSalesOrder(this.Vehicle.VIN, this.SelectedCustomer.customerID, DateTime.Parse(tbSalesDate.Text), this.CalculatedSalesPrice.GetValueOrDefault(0m)
                            , rbLoanYes.Checked);
                    }

                    MessageBox.Show("Sales Order Completed!", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void RbLoanYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLoanYes.Checked)
            {
                tbStartingMonth.Enabled = true;
                tbLoanTerm.Enabled = true;
                tbMonthlyPayment.Enabled = true;
                tbInterestRate.Enabled = true;
                tbDownPayment.Enabled = true;
            }
            else
            {
                tbStartingMonth.Enabled = false;
                tbLoanTerm.Enabled = false;
                tbMonthlyPayment.Enabled = false;
                tbInterestRate.Enabled = false;
                tbDownPayment.Enabled = false;
            }
        }
        
        private void calculateSalesPrice()
        {
            //refactored but left method
            this.CalculatedSalesPrice = this.Vehicle.sales_price;            
        }

        private bool validateFields()
        {
            bool allValid = true;
            string errors = string.Empty;

            if (this.SelectedCustomer == null)
            {
                MessageBox.Show("Please search for an existing customer or add a new Customer to continue.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime attemptedParse = default(DateTime);
            if (string.IsNullOrWhiteSpace(tbSalesDate.Text) || !DateTime.TryParse(tbSalesDate.Text, out attemptedParse))
            {
                MessageBox.Show("Please enter a valid date in mm/dd/yyyy format for a Sales Date.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.Vehicle == null)
            {
                MessageBox.Show("Please return to vehicle search and selecte another vehicle.", "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rbLoanYes.Checked)
            {
                DateTime attemptedParse2 = default(DateTime);
                if (string.IsNullOrWhiteSpace(this.tbStartingMonth.Text) || !DateTime.TryParseExact(tbStartingMonth.Text, "yyyy-MM", new CultureInfo("en-US"), DateTimeStyles.None, out attemptedParse2))
                {
                    errors += "Please enter a starting month for the loan in format YYYY-MM.\n";
                    allValid = false;
                }

                int attemptedParseLoanTerm = default(int);
                if (!int.TryParse(tbLoanTerm.Text, out attemptedParseLoanTerm))
                {
                    errors += "Please enter an integer value for the number of months of the loan term.\n";
                    allValid = false;
                }

                try
                {
                    decimal attemptedParseDecimal = default(decimal);
                    if (string.IsNullOrWhiteSpace(tbMonthlyPayment.Text) || !decimal.TryParse(tbMonthlyPayment.Text.Replace("$",""), out attemptedParseDecimal))
                    {
                        errors += "Please enter a Monthly Payment up to 999999.99\n";
                        allValid = false;
                    }
                    System.Data.SqlTypes.SqlDecimal.ConvertToPrecScale(new SqlDecimal(attemptedParseDecimal), 8, 2);
                }
                catch
                {
                    errors += "Please enter a Monthly Payment up to 999999.99\n";
                    allValid = false;
                }

                try
                {
                    decimal attemptedParseDecimal = default(decimal);
                    if (string.IsNullOrWhiteSpace(tbInterestRate.Text) || !decimal.TryParse(tbInterestRate.Text, out attemptedParseDecimal))
                    {
                        errors += "Please enter a valid interest rate.\n";
                        allValid = false;
                    }
                    System.Data.SqlTypes.SqlDecimal.ConvertToPrecScale(new SqlDecimal(attemptedParseDecimal), 8, 2);
                }
                catch
                {
                    errors += "Please enter a valid interest rate.\n";
                    allValid = false;
                }

                try
                {
                    decimal attemptedParseDecimal = default(decimal);
                    if (string.IsNullOrWhiteSpace(tbDownPayment.Text) || !decimal.TryParse(tbDownPayment.Text.Replace("$",""), out attemptedParseDecimal))
                    {
                        errors += "Please enter a Down Payment up to 999999.99\n";
                        allValid = false;
                    }
                    System.Data.SqlTypes.SqlDecimal.ConvertToPrecScale(new SqlDecimal(attemptedParseDecimal), 8, 2);
                }
                catch
                {
                    errors += "Please enter a Down Payment up to 999999.99\n";
                    allValid = false;
                }
            }

            if (!allValid)
            {
                MessageBox.Show("Please fix the following errors to continue..\n" + errors, "Sales Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return allValid;
        }
    }
}
