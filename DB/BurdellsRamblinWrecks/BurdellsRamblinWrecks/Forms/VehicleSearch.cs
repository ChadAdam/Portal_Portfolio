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
using BurdellsRamblinWrecks.Entities;

namespace BurdellsRamblinWrecks.Forms
{
    public partial class VehicleSearch : Form
    {
        protected List<Vehicle> VehicleResults = null;
        protected List<VehicleType> mVehicleTypes = null;
        protected List<Manufacturer> mManufacturers = null;
        protected List<VehicleColor> mColors = null;

        public VehicleSearch()
        {
            InitializeComponent();
            this.dgvSearchResults.CellDoubleClick += dgvSearchResults_CellDoubleClick;
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
            cbVehicleType.Items.Insert(0, new { VehicleTypeId = "* Any *" });
            cbVehicleType.SelectedIndex = 0;

            //cbManufactorer.ValueMember = "ManufacturerId";
            cbManufactorer.DisplayMember = "ManufacturerId";
            mManufacturers = searchTask.GetManufacturers();
            foreach (var manufacturer in mManufacturers)
            {
                cbManufactorer.Items.Add(new { manufacturer.ManufacturerId });
            }
            cbManufactorer.Items.Insert(0, new { ManufacturerId = "* Any *" });
            cbManufactorer.SelectedIndex = 0;

            //cbColor.ValueMember = "ColorId";
            cbColor.DisplayMember = "ColorId";
            mColors = searchTask.GetColors();
            foreach (var color in mColors)
            {
                cbColor.Items.Add(new { color.ColorId });
            }
            cbColor.Items.Insert(0, new { ColorId = "* Any *" });
            cbColor.SelectedIndex = 0;

            lblPleaseSelect.Visible = true;
            lblSorryGridEmpty.Visible = false;

            UserRolesEnum userRoles = Tasks.Login.GetLoginTask().GetUserRoles();
            if ((userRoles & UserRolesEnum.Manager) != UserRolesEnum.Manager &&
                     (userRoles & UserRolesEnum.Owner) != UserRolesEnum.Owner)
            {
                this.reportsToolStripMenuItem.Enabled = false; //Gray out the button
            }
            else
            {
                this.reportsToolStripMenuItem.Enabled = true; // Enable the button for managers and owners
            }

            if ((userRoles & UserRolesEnum.InventoryClerk) == UserRolesEnum.InventoryClerk || (userRoles & UserRolesEnum.Manager) == UserRolesEnum.Manager)
            {
                this.addVehicleToolStripMenuItem.Enabled = (userRoles & UserRolesEnum.InventoryClerk) == UserRolesEnum.InventoryClerk;
                tbTotalPartsPending.Visible = true;
                lblTotalPartsPending.Visible = true;
                btSearchSold.Visible = true;
            }
            else
            {
                this.addVehicleToolStripMenuItem.Enabled = false;
                tbTotalPartsPending.Visible = false;
                lblTotalPartsPending.Visible = false;
                btSearchSold.Visible = false;
            }


            try { tbTotalCarsAvail.Text = new Tasks.SearchForVehicles().SearchPublicOnly(null, null, null, null, null, null).Count().ToString(); } catch { }
            try { tbTotalPartsPending.Text = new Tasks.SearchForVehicles().GetTotalVehiclesPartsPending().ToString(); } catch { }
        }

        public void ReDisplayForm()
        {
            Tasks.Login loginTask = Tasks.Login.GetLoginTask();
            if (loginTask.IsUserAuthenticated)
            {
                llLoginLogout.Text = "Logout";
                lblVinSearch.Visible = true;
                tbVinSearch.Visible = true;
            }
            else
            {
                llLoginLogout.Text = "Login";
                lblVinSearch.Visible = false;
                tbVinSearch.Clear();
                tbVinSearch.Visible = false;
            }

            this.lblCurrentUser.Text = loginTask.CurrentUser.first_name + " " + loginTask.CurrentUser.last_name;

            UserRolesEnum userRoles = Tasks.Login.GetLoginTask().GetUserRoles();
            if ((userRoles & UserRolesEnum.Manager) != UserRolesEnum.Manager &&
                     (userRoles & UserRolesEnum.Owner) != UserRolesEnum.Owner)
            {
                this.reportsToolStripMenuItem.Enabled = false; //Gray out the button
            }
            else
            {
                this.reportsToolStripMenuItem.Enabled = true; // Enable the button for managers and owners
            }

            if ((userRoles & UserRolesEnum.InventoryClerk) == UserRolesEnum.InventoryClerk || (userRoles & UserRolesEnum.Manager) == UserRolesEnum.Manager)
            {
                this.addVehicleToolStripMenuItem.Enabled = (userRoles & UserRolesEnum.InventoryClerk) == UserRolesEnum.InventoryClerk;
                tbTotalPartsPending.Visible = true;
                lblTotalPartsPending.Visible = true;
                btSearchSold.Visible = true;
            }
            else
            {
                this.addVehicleToolStripMenuItem.Enabled = false;
                tbTotalPartsPending.Visible = false;
                lblTotalPartsPending.Visible = false;
                btSearchSold.Visible = false;
            }

            ClearSearchResults();
            try { tbTotalCarsAvail.Text = new Tasks.SearchForVehicles().SearchPublicOnly(null, null, null, null, null, null).Count().ToString(); } catch { }
            try { tbTotalPartsPending.Text = new Tasks.SearchForVehicles().GetTotalVehiclesPartsPending().ToString(); } catch { }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var loginForm = new Forms.Login();
            loginForm.StartPosition = FormStartPosition.CenterParent;
            loginForm.FormClosed += LoginForm_FormClosed;
            loginForm.ShowDialog();
        }

        private void averageTimeInInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var avgReport = new Reports.AverageTimeInInvetoryReport();
            avgReport.StartPosition = FormStartPosition.WindowsDefaultLocation;
            avgReport.ShowDialog();
        }
        private void partsStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var partsReport = new Reports.PartsStatisticsReport();
            partsReport.StartPosition = FormStartPosition.WindowsDefaultLocation;
            partsReport.ShowDialog();
        }

        private void monthlyLoanIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var partsReport = new Reports.MonthlyLoanIncomeReport();
            partsReport.StartPosition = FormStartPosition.WindowsDefaultLocation;
            partsReport.ShowDialog();
        }

        private void monthlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var partsReport = new Reports.MonthlySalesReport();
            partsReport.StartPosition = FormStartPosition.WindowsDefaultLocation;
            partsReport.ShowDialog();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Tasks.Login loginTask = Tasks.Login.GetLoginTask();
            ReDisplayForm();

            if (loginTask.IsUserAuthenticated)
            {
                MessageBox.Show(this, "Login Successful. Please Perform Your Search Again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sorry, that UserName/Password Combination was Incorrect. Please Try Again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            DateTime attemptedParse = default(DateTime);
            if (!string.IsNullOrWhiteSpace(tbModelYear.Text) && !DateTime.TryParseExact(tbModelYear.Text, "yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out attemptedParse))
            {
                MessageBox.Show("Please enter a 4 digit year that does not exceed the current year plus 1.", "Vehicle Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var currentYear = DateTime.Now.Year;
            if (attemptedParse.Year > (currentYear + 1))
            {
                MessageBox.Show("Please enter a 4 digit year that does not exceed the current year plus 1.", "Vehicle Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ObtainAndBindSearchResults();
        }

        private void dgvSearchResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow != null)
            {
                var vehicle = dgv.CurrentRow.DataBoundItem as Vehicle;
                if (vehicle != null)
                {
                    var vehicleDetailsForm = new Forms.VehicleDetails();
                    vehicleDetailsForm.SendLookupData(mVehicleTypes, mManufacturers);
                    vehicleDetailsForm.SendVehicle(vehicle);
                    vehicleDetailsForm.StartPosition = FormStartPosition.CenterParent;
                    vehicleDetailsForm.FormClosed += VehicleDetailsForm_FormClosed;
                    vehicleDetailsForm.ShowDialog();
                }
            }
        }

        private void VehicleDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var vehicleDetailsForm = sender as Forms.VehicleDetails;
            if (vehicleDetailsForm != null && vehicleDetailsForm.VehicleToSell != null)
            {
                Invoke(new MethodInvoker(() =>
                {
                    //this means a salesperson wants to sell this vehicle
                    var salesOrderForm = new Forms.SalesOrder();
                    salesOrderForm.SendVehicle(vehicleDetailsForm.VehicleToSell);
                    salesOrderForm.StartPosition = FormStartPosition.CenterParent;
                    salesOrderForm.FormClosed += SalesOrderForm_FormClosed;
                    vehicleDetailsForm.FormClosed -= VehicleDetailsForm_FormClosed;
                    vehicleDetailsForm.VehicleToSell = null;
                    salesOrderForm.ShowDialog();
                }));
            }
        }

        private void SalesOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var salesOrderForm = sender as Forms.SalesOrder;
            if (salesOrderForm != null)
            {               
                ClearSearchResults(); // we can't let the car we just sold remain in the search results
                salesOrderForm.FormClosed -= SalesOrderForm_FormClosed;
            }

            try { tbTotalCarsAvail.Text = new Tasks.SearchForVehicles().SearchPublicOnly(null, null, null, null, null, null).Count().ToString(); } catch { }
            try { tbTotalPartsPending.Text = new Tasks.SearchForVehicles().GetTotalVehiclesPartsPending().ToString(); } catch { }
        }

        private void llLoginLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (llLoginLogout.Text == "Login")
            {
                var loginForm = new Forms.Login();
                loginForm.StartPosition = FormStartPosition.CenterParent;
                loginForm.FormClosed += LoginForm_FormClosed;
                loginForm.ShowDialog();

                ReDisplayForm();
            }
            else
            {
                Tasks.Login.GetLoginTask().LogoutUser();
                MessageBox.Show("Since you've logged out, you will need to perform your search again.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ReDisplayForm();
            }
        }

        private void ObtainAndBindSearchResults()
        {            
            var searchTask = new Tasks.SearchForVehicles();
            this.VehicleResults = searchTask.Search(
                  cbVehicleType.SelectedIndex == 0 ? null : (cbVehicleType.SelectedItem as dynamic).VehicleTypeId
                , cbColor.SelectedIndex == 0 ? null : (cbColor.SelectedItem as dynamic).ColorId
                , cbManufactorer.SelectedIndex == 0 ? null : (cbManufactorer.SelectedItem as dynamic).ManufacturerId
                , tbModelYear.Text
                , tbKeyword.Text
                , tbVinSearch.Text);
            this.dgvSearchResults.DataSource = this.VehicleResults;
            this.lblSorryGridEmpty.Visible = (this.VehicleResults == null || this.VehicleResults.Count == 0);
            this.lblPleaseSelect.Visible = false;
        }

        private void ClearSearchResults()
        {
            this.VehicleResults = null;
            this.dgvSearchResults.DataSource = this.VehicleResults;
            this.lblSorryGridEmpty.Visible = false;
            this.lblPleaseSelect.Visible = true;
        }

        private void PricePerConditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.PricePerConditionReport PCReport = new Reports.PricePerConditionReport();
            PCReport.StartPosition = FormStartPosition.CenterScreen;
            PCReport.ShowDialog();
        }

        private void AddVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.AddVendor AV = new AddVendor();
            AV.StartPosition = FormStartPosition.CenterScreen;
            AV.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserRolesEnum userRoles = Tasks.Login.GetLoginTask().GetUserRoles();
            if ((userRoles & UserRolesEnum.Manager) == UserRolesEnum.Manager ||
                     (userRoles & UserRolesEnum.Owner) == UserRolesEnum.Owner)
            {
                this.monthlySalesToolStripMenuItem.Visible = true;
                this.monthlyLoanIncomeToolStripMenuItem.Visible = true;
                this.partsStatisticsToolStripMenuItem.Visible = true;
                this.pricePerConditionToolStripMenuItem.Visible = true;
                this.averageTimeInInventoryToolStripMenuItem.Visible = true;
                this.sellerHistoryToolStripMenuItem.Visible = true;
            }
            else
            {
                this.monthlySalesToolStripMenuItem.Visible = false;
                this.monthlyLoanIncomeToolStripMenuItem.Visible = false;
                this.partsStatisticsToolStripMenuItem.Visible = false;
                this.pricePerConditionToolStripMenuItem.Visible = false;
                this.averageTimeInInventoryToolStripMenuItem.Visible = false;
                this.sellerHistoryToolStripMenuItem.Visible = false;
            }
        }

        private void SellerHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.SellerHistoryReport SH = new Reports.SellerHistoryReport();
            SH.StartPosition = FormStartPosition.CenterScreen;
            SH.ShowDialog();
        }

        private void AddVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.AddVehicle AV = new AddVehicle();
            AV.StartPosition = FormStartPosition.CenterScreen;
            AV.FormClosed += AV_FormClosed;
            AV.ShowDialog();
        }

        private void AV_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { tbTotalCarsAvail.Text = new Tasks.SearchForVehicles().SearchPublicOnly(null, null, null, null, null, null).Count().ToString(); } catch { }
            try { tbTotalPartsPending.Text = new Tasks.SearchForVehicles().GetTotalVehiclesPartsPending().ToString(); } catch { }

            var form = sender as Forms.AddVehicle;
            if (form != null)
            {
                form.FormClosed -= AV_FormClosed;

                if (form != null && form.Vehicle != null)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        //this means a salesperson wants to sell this vehicle
                        var detailsForm = new Forms.VehicleDetails();
                        detailsForm.SendVehicle(form.Vehicle);
                        detailsForm.StartPosition = FormStartPosition.CenterParent;                        
                        detailsForm.ShowDialog();
                    }));
                }

            }

        }

        private void btSearchSold_Click(object sender, EventArgs e)
        {
            DateTime attemptedParse = default(DateTime);
            if (!string.IsNullOrWhiteSpace(tbModelYear.Text) && !DateTime.TryParseExact(tbModelYear.Text, "yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out attemptedParse))
            {
                MessageBox.Show("Please enter a 4 digit year that does not exceed the current year plus 1.", "Vehicle Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var currentYear = DateTime.Now.Year;
            if (attemptedParse.Year > (currentYear + 1))
            {
                MessageBox.Show("Please enter a 4 digit year that does not exceed the current year plus 1.", "Vehicle Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var userRoles = Tasks.Login.GetLoginTask().GetUserRoles();
            if ((userRoles & UserRolesEnum.InventoryClerk) == UserRolesEnum.InventoryClerk || (userRoles & UserRolesEnum.Manager) == UserRolesEnum.Manager)
            {
                var searchTask = new Tasks.SearchForVehicles();
                this.VehicleResults = searchTask.SearchSold(
                      cbVehicleType.SelectedIndex == 0 ? null : (cbVehicleType.SelectedItem as dynamic).VehicleTypeId
                    , cbColor.SelectedIndex == 0 ? null : (cbColor.SelectedItem as dynamic).ColorId
                    , cbManufactorer.SelectedIndex == 0 ? null : (cbManufactorer.SelectedItem as dynamic).ManufacturerId
                    , tbModelYear.Text
                    , tbKeyword.Text
                    , tbVinSearch.Text);
                this.dgvSearchResults.DataSource = this.VehicleResults;
                this.lblSorryGridEmpty.Visible = (this.VehicleResults == null || this.VehicleResults.Count == 0);
                this.lblPleaseSelect.Visible = false;
            }
            else
            {
                MessageBox.Show("Sorry you don't have access to this feature", "Sold Search", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
