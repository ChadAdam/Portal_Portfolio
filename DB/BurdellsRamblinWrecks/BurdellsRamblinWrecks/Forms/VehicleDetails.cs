using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BurdellsRamblinWrecks.Entities;
using BurdellsRamblinWrecks.Queries;

namespace BurdellsRamblinWrecks.Forms
{
    public partial class VehicleDetails : Form
    {
        protected Vehicle vehicle;

        // if this is populated then the form has specificed that we want to sell this particular car to a customer. parent form should check.
        public Vehicle VehicleToSell { get; set; }

        public VehicleDetails()
        {
            InitializeComponent();

            UserRolesEnum userRoles = Tasks.Login.GetLoginTask().GetUserRoles();
            if ((userRoles & UserRolesEnum.SalesPerson) == UserRolesEnum.SalesPerson)
            {
                btSellCar.Enabled = true;
                btSellCar.Visible = true;
            }
            else
            {
                btSellCar.Enabled = false;
                btSellCar.Visible = false;
            }
        }

        public void SendLookupData(List<VehicleType> vehicleTypes, List<Manufacturer> manufacturers)
        {
            cbVehicleType.DisplayMember = "VehicleTypeId";
            foreach (var vehicleType in vehicleTypes)
            {
                cbVehicleType.Items.Add(new { vehicleType.VehicleTypeId });
            }

            cbManufacturer.DisplayMember = "ManufacturerId";
            foreach (var manufacturer in manufacturers)
            {
                cbManufacturer.Items.Add(new { manufacturer.ManufacturerId });
            }
        }

        public void SendVehicle(Vehicle vehicle)
        {
            this.vehicle = vehicle;

            tbVin.ReadOnly = true;
            cbVehicleType.Enabled = false;
            tbModelName.ReadOnly = true;
            tbModelYear.ReadOnly = true;
            tbMileage.ReadOnly = true;
            cbManufacturer.Enabled = false;
            tbColors.ReadOnly = true;
            tbSalesPrice.ReadOnly = true;
            tbDescription.ReadOnly = true;

            var userRoles = Tasks.Login.GetLoginTask().GetUserRoles();
            if ((userRoles & UserRolesEnum.InventoryClerk) == UserRolesEnum.InventoryClerk)
            {
                lblTotalPartsCost.Visible = true;
                tbTotalPartsCost.Visible = true;
                tbPurchasePrice.Visible = true;
                lblPurchasePrice.Visible = true;
                this.grPartDetails.Enabled = true;
                queryAndBindParts();
            }
            else
            {
                lblTotalPartsCost.Visible = false;
                tbTotalPartsCost.Visible = false;
                tbPurchasePrice.Visible = false;
                lblPurchasePrice.Visible = false;
                this.grPartDetails.Enabled = false;
            }

            this.VehicleToSell = null;
            BindFields();
        }

        private void queryAndBindParts()
        {
            var task = new Tasks.PartsOrder();
            var parts = task.QueryPartsForVechicle(this.vehicle.VIN);
            this.dgvParts.DataSource = parts;

            DataGridViewButtonColumn button = new DataGridViewButtonColumn()
            {
                Name = "Update Status",
                HeaderText = "Update Status",
                Text = "Update Status",
                UseColumnTextForButtonValue = true
            };
            if (this.dgvParts.Columns.Count != 8)
            {
                this.dgvParts.Columns.Add(button);
                this.dgvParts.CellContentClick += DgvParts_CellContentClick;
            }
        }

        private void DgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    string oldPartStatus = this.dgvParts.Rows[e.RowIndex].Cells[7].Value.ToString();
                    string newPartStatus = calculateNewPartStatus(oldPartStatus);
                    string orderid = this.dgvParts.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string partnumber = this.dgvParts.Rows[e.RowIndex].Cells[3].Value.ToString();
                    DialogResult result = MessageBox.Show(string.Format("This will update your status to {0} ?", newPartStatus), "Update Status?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var task = new Tasks.PartsOrder();
                        task.updatePartStatus(orderid, partnumber, newPartStatus);
                        queryAndBindParts();
                    }
                }
            }
            catch (FriendlyMessageException ex)
            {
                MessageBox.Show(ex.FriendlyMessage, "Part Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string calculateNewPartStatus(string oldPartStatus)
        {
            if (oldPartStatus == "ordered")
                return "received";
            else if (oldPartStatus == "received")
                return "installed";
            else
            {
                throw new FriendlyMessageException("Sorry, you can't change this parts status");
            }
        }

        public void BindFields()
        {
            tbVin.Text = vehicle.VIN;
            cbVehicleType.Text = vehicle.vehicleTypeId;
            tbModelName.Text = vehicle.model_name;
            tbModelYear.Text = vehicle.model_year;
            tbMileage.Text = vehicle.mileage;
            cbManufacturer.Text = vehicle.manufacturerId;
            tbColors.Text = vehicle.color;
            tbSalesPrice.Text = vehicle.sales_price.ToString("C");
            tbDescription.Text = vehicle.description;
            tbTotalPartsCost.Text = vehicle.total_parts_cost.ToString("C");
            tbPurchasePrice.Text = vehicle.purchase_price.ToString("C");
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.VehicleToSell = null;
            this.Close();
        }

        private void btSellCar_Click(object sender, EventArgs e)
        {
            this.VehicleToSell = this.vehicle;
            this.Close();
        }

        private void btAddPartsOrder_Click(object sender, EventArgs e)
        {
            var form = new Forms.AddPartsOrder(this.vehicle.VIN, Tasks.Login.GetLoginTask().CurrentUser.username);
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormClosed += Form_FormClosed;
            form.ShowDialog();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            queryAndBindParts();
        }
    }
}
