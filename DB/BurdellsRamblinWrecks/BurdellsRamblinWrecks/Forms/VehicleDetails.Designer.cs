namespace BurdellsRamblinWrecks.Forms
{
    partial class VehicleDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbVehicleDetails = new System.Windows.Forms.GroupBox();
            this.tbTotalPartsCost = new System.Windows.Forms.TextBox();
            this.lblTotalPartsCost = new System.Windows.Forms.Label();
            this.tbPurchasePrice = new System.Windows.Forms.TextBox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbSalesPrice = new System.Windows.Forms.TextBox();
            this.lblSalesPrice = new System.Windows.Forms.Label();
            this.cbVehicleType = new System.Windows.Forms.ComboBox();
            this.tbMileage = new System.Windows.Forms.TextBox();
            this.lblMileage = new System.Windows.Forms.Label();
            this.tbColors = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.tbModelName = new System.Windows.Forms.TextBox();
            this.lblModelName = new System.Windows.Forms.Label();
            this.tbModelYear = new System.Windows.Forms.TextBox();
            this.lblModelYear = new System.Windows.Forms.Label();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.tbVin = new System.Windows.Forms.TextBox();
            this.lblVin = new System.Windows.Forms.Label();
            this.btSellCar = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.grPartDetails = new System.Windows.Forms.GroupBox();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.btAddPartsOrder = new System.Windows.Forms.Button();
            this.gbVehicleDetails.SuspendLayout();
            this.grPartDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVehicleDetails
            // 
            this.gbVehicleDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVehicleDetails.Controls.Add(this.tbTotalPartsCost);
            this.gbVehicleDetails.Controls.Add(this.lblTotalPartsCost);
            this.gbVehicleDetails.Controls.Add(this.tbPurchasePrice);
            this.gbVehicleDetails.Controls.Add(this.lblPurchasePrice);
            this.gbVehicleDetails.Controls.Add(this.tbDescription);
            this.gbVehicleDetails.Controls.Add(this.lblDescription);
            this.gbVehicleDetails.Controls.Add(this.tbSalesPrice);
            this.gbVehicleDetails.Controls.Add(this.lblSalesPrice);
            this.gbVehicleDetails.Controls.Add(this.cbVehicleType);
            this.gbVehicleDetails.Controls.Add(this.tbMileage);
            this.gbVehicleDetails.Controls.Add(this.lblMileage);
            this.gbVehicleDetails.Controls.Add(this.tbColors);
            this.gbVehicleDetails.Controls.Add(this.label1);
            this.gbVehicleDetails.Controls.Add(this.cbManufacturer);
            this.gbVehicleDetails.Controls.Add(this.lblManufacturer);
            this.gbVehicleDetails.Controls.Add(this.tbModelName);
            this.gbVehicleDetails.Controls.Add(this.lblModelName);
            this.gbVehicleDetails.Controls.Add(this.tbModelYear);
            this.gbVehicleDetails.Controls.Add(this.lblModelYear);
            this.gbVehicleDetails.Controls.Add(this.lblVehicleType);
            this.gbVehicleDetails.Controls.Add(this.tbVin);
            this.gbVehicleDetails.Controls.Add(this.lblVin);
            this.gbVehicleDetails.Location = new System.Drawing.Point(12, 12);
            this.gbVehicleDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbVehicleDetails.Name = "gbVehicleDetails";
            this.gbVehicleDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbVehicleDetails.Size = new System.Drawing.Size(1034, 250);
            this.gbVehicleDetails.TabIndex = 0;
            this.gbVehicleDetails.TabStop = false;
            this.gbVehicleDetails.Text = "Vehicle Details";
            // 
            // tbTotalPartsCost
            // 
            this.tbTotalPartsCost.Location = new System.Drawing.Point(469, 220);
            this.tbTotalPartsCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTotalPartsCost.Name = "tbTotalPartsCost";
            this.tbTotalPartsCost.ReadOnly = true;
            this.tbTotalPartsCost.Size = new System.Drawing.Size(149, 22);
            this.tbTotalPartsCost.TabIndex = 19;
            // 
            // lblTotalPartsCost
            // 
            this.lblTotalPartsCost.AutoSize = true;
            this.lblTotalPartsCost.Location = new System.Drawing.Point(355, 223);
            this.lblTotalPartsCost.Name = "lblTotalPartsCost";
            this.lblTotalPartsCost.Size = new System.Drawing.Size(113, 17);
            this.lblTotalPartsCost.TabIndex = 20;
            this.lblTotalPartsCost.Text = "Total Parts Cost:";
            // 
            // tbPurchasePrice
            // 
            this.tbPurchasePrice.Location = new System.Drawing.Point(123, 222);
            this.tbPurchasePrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPurchasePrice.Name = "tbPurchasePrice";
            this.tbPurchasePrice.ReadOnly = true;
            this.tbPurchasePrice.Size = new System.Drawing.Size(140, 22);
            this.tbPurchasePrice.TabIndex = 17;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(11, 225);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(108, 17);
            this.lblPurchasePrice.TabIndex = 18;
            this.lblPurchasePrice.Text = "Purchase Price:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(469, 119);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(240, 84);
            this.tbDescription.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(381, 122);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "Description:";
            // 
            // tbSalesPrice
            // 
            this.tbSalesPrice.Location = new System.Drawing.Point(469, 91);
            this.tbSalesPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSalesPrice.Name = "tbSalesPrice";
            this.tbSalesPrice.Size = new System.Drawing.Size(240, 22);
            this.tbSalesPrice.TabIndex = 8;
            // 
            // lblSalesPrice
            // 
            this.lblSalesPrice.AutoSize = true;
            this.lblSalesPrice.Location = new System.Drawing.Point(381, 94);
            this.lblSalesPrice.Name = "lblSalesPrice";
            this.lblSalesPrice.Size = new System.Drawing.Size(83, 17);
            this.lblSalesPrice.TabIndex = 14;
            this.lblSalesPrice.Text = "Sales Price:";
            // 
            // cbVehicleType
            // 
            this.cbVehicleType.FormattingEnabled = true;
            this.cbVehicleType.Location = new System.Drawing.Point(123, 63);
            this.cbVehicleType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbVehicleType.Name = "cbVehicleType";
            this.cbVehicleType.Size = new System.Drawing.Size(240, 24);
            this.cbVehicleType.TabIndex = 2;
            // 
            // tbMileage
            // 
            this.tbMileage.Location = new System.Drawing.Point(469, 63);
            this.tbMileage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMileage.Name = "tbMileage";
            this.tbMileage.Size = new System.Drawing.Size(240, 22);
            this.tbMileage.TabIndex = 7;
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new System.Drawing.Point(405, 66);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(61, 17);
            this.lblMileage.TabIndex = 11;
            this.lblMileage.Text = "Mileage:";
            // 
            // tbColors
            // 
            this.tbColors.Location = new System.Drawing.Point(469, 34);
            this.tbColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbColors.Name = "tbColors";
            this.tbColors.Size = new System.Drawing.Size(240, 22);
            this.tbColors.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Color(s):";
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.Location = new System.Drawing.Point(123, 149);
            this.cbManufacturer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(240, 24);
            this.cbManufacturer.TabIndex = 5;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(23, 153);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(96, 17);
            this.lblManufacturer.TabIndex = 7;
            this.lblManufacturer.Text = "Manufacturer:";
            // 
            // tbModelName
            // 
            this.tbModelName.Location = new System.Drawing.Point(123, 121);
            this.tbModelName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbModelName.Name = "tbModelName";
            this.tbModelName.Size = new System.Drawing.Size(240, 22);
            this.tbModelName.TabIndex = 4;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Location = new System.Drawing.Point(29, 124);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(91, 17);
            this.lblModelName.TabIndex = 5;
            this.lblModelName.Text = "Model Name:";
            // 
            // tbModelYear
            // 
            this.tbModelYear.Location = new System.Drawing.Point(123, 94);
            this.tbModelYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbModelYear.Name = "tbModelYear";
            this.tbModelYear.Size = new System.Drawing.Size(77, 22);
            this.tbModelYear.TabIndex = 3;
            // 
            // lblModelYear
            // 
            this.lblModelYear.AutoSize = true;
            this.lblModelYear.Location = new System.Drawing.Point(35, 96);
            this.lblModelYear.Name = "lblModelYear";
            this.lblModelYear.Size = new System.Drawing.Size(84, 17);
            this.lblModelYear.TabIndex = 3;
            this.lblModelYear.Text = "Model Year:";
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Location = new System.Drawing.Point(27, 66);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(94, 17);
            this.lblVehicleType.TabIndex = 2;
            this.lblVehicleType.Text = "Vehicle Type:";
            // 
            // tbVin
            // 
            this.tbVin.Location = new System.Drawing.Point(123, 34);
            this.tbVin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbVin.Name = "tbVin";
            this.tbVin.Size = new System.Drawing.Size(240, 22);
            this.tbVin.TabIndex = 1;
            // 
            // lblVin
            // 
            this.lblVin.AutoSize = true;
            this.lblVin.Location = new System.Drawing.Point(87, 38);
            this.lblVin.Name = "lblVin";
            this.lblVin.Size = new System.Drawing.Size(34, 17);
            this.lblVin.TabIndex = 0;
            this.lblVin.Text = "VIN:";
            // 
            // btSellCar
            // 
            this.btSellCar.Location = new System.Drawing.Point(371, 607);
            this.btSellCar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSellCar.Name = "btSellCar";
            this.btSellCar.Size = new System.Drawing.Size(101, 28);
            this.btSellCar.TabIndex = 10;
            this.btSellCar.Text = "Sell Car";
            this.btSellCar.UseVisualStyleBackColor = true;
            this.btSellCar.Click += new System.EventHandler(this.btSellCar_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(493, 607);
            this.btOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 28);
            this.btOK.TabIndex = 11;
            this.btOK.Text = "Close";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // grPartDetails
            // 
            this.grPartDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grPartDetails.Controls.Add(this.dgvParts);
            this.grPartDetails.Controls.Add(this.btAddPartsOrder);
            this.grPartDetails.Location = new System.Drawing.Point(12, 268);
            this.grPartDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grPartDetails.Name = "grPartDetails";
            this.grPartDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grPartDetails.Size = new System.Drawing.Size(1034, 250);
            this.grPartDetails.TabIndex = 12;
            this.grPartDetails.TabStop = false;
            this.grPartDetails.Text = "Parts Details:";
            // 
            // dgvParts
            // 
            this.dgvParts.AllowUserToAddRows = false;
            this.dgvParts.AllowUserToDeleteRows = false;
            this.dgvParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvParts.Location = new System.Drawing.Point(13, 75);
            this.dgvParts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvParts.MultiSelect = false;
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.ReadOnly = true;
            this.dgvParts.RowHeadersVisible = false;
            this.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParts.ShowCellErrors = false;
            this.dgvParts.ShowEditingIcon = false;
            this.dgvParts.ShowRowErrors = false;
            this.dgvParts.Size = new System.Drawing.Size(1014, 167);
            this.dgvParts.TabIndex = 14;
            // 
            // btAddPartsOrder
            // 
            this.btAddPartsOrder.Location = new System.Drawing.Point(424, 21);
            this.btAddPartsOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddPartsOrder.Name = "btAddPartsOrder";
            this.btAddPartsOrder.Size = new System.Drawing.Size(181, 28);
            this.btAddPartsOrder.TabIndex = 13;
            this.btAddPartsOrder.Text = "Add Parts Order";
            this.btAddPartsOrder.UseVisualStyleBackColor = true;
            this.btAddPartsOrder.Click += new System.EventHandler(this.btAddPartsOrder_Click);
            // 
            // VehicleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 660);
            this.ControlBox = false;
            this.Controls.Add(this.grPartDetails);
            this.Controls.Add(this.btSellCar);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.gbVehicleDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VehicleDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VehicleDetails";
            this.gbVehicleDetails.ResumeLayout(false);
            this.gbVehicleDetails.PerformLayout();
            this.grPartDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVehicleDetails;
        private System.Windows.Forms.TextBox tbVin;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.TextBox tbModelName;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.TextBox tbModelYear;
        private System.Windows.Forms.Label lblModelYear;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.TextBox tbColors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbVehicleType;
        private System.Windows.Forms.TextBox tbMileage;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.TextBox tbSalesPrice;
        private System.Windows.Forms.Label lblSalesPrice;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btSellCar;
        private System.Windows.Forms.TextBox tbPurchasePrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.TextBox tbTotalPartsCost;
        private System.Windows.Forms.Label lblTotalPartsCost;
        private System.Windows.Forms.GroupBox grPartDetails;
        private System.Windows.Forms.Button btAddPartsOrder;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.Label lblVin;
    }
}