namespace BurdellsRamblinWrecks.Forms
{
    partial class AddPartsOrder
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
            this.btnSearchVendor = new System.Windows.Forms.Button();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbOrderID = new System.Windows.Forms.TextBox();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.tbPONumber = new System.Windows.Forms.TextBox();
            this.lblModelName = new System.Windows.Forms.Label();
            this.lblModelYear = new System.Windows.Forms.Label();
            this.lblVehicleType = new System.Windows.Forms.Label();
            this.tbVin = new System.Windows.Forms.TextBox();
            this.lblVin = new System.Windows.Forms.Label();
            this.btAddToOrder = new System.Windows.Forms.Button();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.lblSalesPrice = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblMileage = new System.Windows.Forms.Label();
            this.tbPartNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPartsList = new System.Windows.Forms.DataGridView();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btAddVendor = new System.Windows.Forms.Button();
            this.gbVehicleDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsList)).BeginInit();
            this.SuspendLayout();
            // 
            // gbVehicleDetails
            // 
            this.gbVehicleDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVehicleDetails.Controls.Add(this.btAddVendor);
            this.gbVehicleDetails.Controls.Add(this.btnSearchVendor);
            this.gbVehicleDetails.Controls.Add(this.tbVendor);
            this.gbVehicleDetails.Controls.Add(this.tbUser);
            this.gbVehicleDetails.Controls.Add(this.tbOrderID);
            this.gbVehicleDetails.Controls.Add(this.lblManufacturer);
            this.gbVehicleDetails.Controls.Add(this.tbPONumber);
            this.gbVehicleDetails.Controls.Add(this.lblModelName);
            this.gbVehicleDetails.Controls.Add(this.lblModelYear);
            this.gbVehicleDetails.Controls.Add(this.lblVehicleType);
            this.gbVehicleDetails.Controls.Add(this.tbVin);
            this.gbVehicleDetails.Controls.Add(this.lblVin);
            this.gbVehicleDetails.Location = new System.Drawing.Point(15, 14);
            this.gbVehicleDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbVehicleDetails.Name = "gbVehicleDetails";
            this.gbVehicleDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbVehicleDetails.Size = new System.Drawing.Size(769, 219);
            this.gbVehicleDetails.TabIndex = 1;
            this.gbVehicleDetails.TabStop = false;
            this.gbVehicleDetails.Text = "Part Order Details";
            // 
            // btnSearchVendor
            // 
            this.btnSearchVendor.Location = new System.Drawing.Point(383, 145);
            this.btnSearchVendor.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchVendor.Name = "btnSearchVendor";
            this.btnSearchVendor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSearchVendor.Size = new System.Drawing.Size(129, 33);
            this.btnSearchVendor.TabIndex = 20;
            this.btnSearchVendor.Text = "Search Vendor";
            this.btnSearchVendor.UseVisualStyleBackColor = true;
            this.btnSearchVendor.Click += new System.EventHandler(this.btnSearchVendor_Click);
            // 
            // tbVendor
            // 
            this.tbVendor.Location = new System.Drawing.Point(123, 150);
            this.tbVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.ReadOnly = true;
            this.tbVendor.Size = new System.Drawing.Size(240, 22);
            this.tbVendor.TabIndex = 19;
            // 
            // tbUser
            // 
            this.tbUser.BackColor = System.Drawing.SystemColors.Control;
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUser.Location = new System.Drawing.Point(123, 96);
            this.tbUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(241, 15);
            this.tbUser.TabIndex = 18;
            // 
            // tbOrderID
            // 
            this.tbOrderID.BackColor = System.Drawing.SystemColors.Control;
            this.tbOrderID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbOrderID.Location = new System.Drawing.Point(123, 63);
            this.tbOrderID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.ReadOnly = true;
            this.tbOrderID.Size = new System.Drawing.Size(241, 15);
            this.tbOrderID.TabIndex = 17;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(56, 154);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(58, 17);
            this.lblManufacturer.TabIndex = 7;
            this.lblManufacturer.Text = "Vendor:";
            // 
            // tbPONumber
            // 
            this.tbPONumber.Location = new System.Drawing.Point(123, 121);
            this.tbPONumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPONumber.Name = "tbPONumber";
            this.tbPONumber.ReadOnly = true;
            this.tbPONumber.Size = new System.Drawing.Size(240, 22);
            this.tbPONumber.TabIndex = 4;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Location = new System.Drawing.Point(29, 124);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(86, 17);
            this.lblModelName.TabIndex = 5;
            this.lblModelName.Text = "PO Number:";
            // 
            // lblModelYear
            // 
            this.lblModelYear.AutoSize = true;
            this.lblModelYear.Location = new System.Drawing.Point(75, 96);
            this.lblModelYear.Name = "lblModelYear";
            this.lblModelYear.Size = new System.Drawing.Size(42, 17);
            this.lblModelYear.TabIndex = 3;
            this.lblModelYear.Text = "User:";
            // 
            // lblVehicleType
            // 
            this.lblVehicleType.AutoSize = true;
            this.lblVehicleType.Location = new System.Drawing.Point(56, 66);
            this.lblVehicleType.Name = "lblVehicleType";
            this.lblVehicleType.Size = new System.Drawing.Size(66, 17);
            this.lblVehicleType.TabIndex = 2;
            this.lblVehicleType.Text = "Order ID:";
            // 
            // tbVin
            // 
            this.tbVin.BackColor = System.Drawing.SystemColors.Control;
            this.tbVin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVin.Location = new System.Drawing.Point(123, 34);
            this.tbVin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbVin.Name = "tbVin";
            this.tbVin.ReadOnly = true;
            this.tbVin.Size = new System.Drawing.Size(241, 15);
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
            // btAddToOrder
            // 
            this.btAddToOrder.Location = new System.Drawing.Point(392, 155);
            this.btAddToOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btAddToOrder.Name = "btAddToOrder";
            this.btAddToOrder.Size = new System.Drawing.Size(173, 33);
            this.btAddToOrder.TabIndex = 28;
            this.btAddToOrder.Text = "Add To Order";
            this.btAddToOrder.UseVisualStyleBackColor = true;
            this.btAddToOrder.Click += new System.EventHandler(this.btAddToOrder_Click);
            // 
            // tbCost
            // 
            this.tbCost.Location = new System.Drawing.Point(144, 160);
            this.tbCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(240, 22);
            this.tbCost.TabIndex = 24;
            // 
            // lblSalesPrice
            // 
            this.lblSalesPrice.AutoSize = true;
            this.lblSalesPrice.Location = new System.Drawing.Point(97, 164);
            this.lblSalesPrice.Name = "lblSalesPrice";
            this.lblSalesPrice.Size = new System.Drawing.Size(40, 17);
            this.lblSalesPrice.TabIndex = 27;
            this.lblSalesPrice.Text = "Cost:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(143, 71);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(611, 74);
            this.tbDescription.TabIndex = 23;
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new System.Drawing.Point(55, 75);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(83, 17);
            this.lblMileage.TabIndex = 26;
            this.lblMileage.Text = "Description:";
            // 
            // tbPartNumber
            // 
            this.tbPartNumber.Location = new System.Drawing.Point(143, 43);
            this.tbPartNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPartNumber.Name = "tbPartNumber";
            this.tbPartNumber.Size = new System.Drawing.Size(240, 22);
            this.tbPartNumber.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Part Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btAddToOrder);
            this.groupBox1.Controls.Add(this.tbPartNumber);
            this.groupBox1.Controls.Add(this.tbCost);
            this.groupBox1.Controls.Add(this.lblMileage);
            this.groupBox1.Controls.Add(this.lblSalesPrice);
            this.groupBox1.Controls.Add(this.tbDescription);
            this.groupBox1.Location = new System.Drawing.Point(15, 239);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(769, 245);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Parts";
            // 
            // dgvPartsList
            // 
            this.dgvPartsList.AllowUserToAddRows = false;
            this.dgvPartsList.AllowUserToDeleteRows = false;
            this.dgvPartsList.AllowUserToOrderColumns = true;
            this.dgvPartsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartsList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPartsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPartsList.Location = new System.Drawing.Point(15, 507);
            this.dgvPartsList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPartsList.MultiSelect = false;
            this.dgvPartsList.Name = "dgvPartsList";
            this.dgvPartsList.ReadOnly = true;
            this.dgvPartsList.RowHeadersVisible = false;
            this.dgvPartsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartsList.ShowCellErrors = false;
            this.dgvPartsList.ShowEditingIcon = false;
            this.dgvPartsList.ShowRowErrors = false;
            this.dgvPartsList.Size = new System.Drawing.Size(1036, 287);
            this.dgvPartsList.TabIndex = 30;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(345, 826);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(175, 37);
            this.btnSubmit.TabIndex = 31;
            this.btnSubmit.Text = "Submit Order";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(528, 826);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(151, 37);
            this.btCancel.TabIndex = 32;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btAddVendor
            // 
            this.btAddVendor.Location = new System.Drawing.Point(383, 108);
            this.btAddVendor.Margin = new System.Windows.Forms.Padding(4);
            this.btAddVendor.Name = "btAddVendor";
            this.btAddVendor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btAddVendor.Size = new System.Drawing.Size(129, 33);
            this.btAddVendor.TabIndex = 21;
            this.btAddVendor.Text = "Add Vendor";
            this.btAddVendor.UseVisualStyleBackColor = true;
            this.btAddVendor.Click += new System.EventHandler(this.btAddVendor_Click);
            // 
            // AddPartsOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 885);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dgvPartsList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbVehicleDetails);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddPartsOrder";
            this.Text = "AddPartsOrder";
            this.gbVehicleDetails.ResumeLayout(false);
            this.gbVehicleDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVehicleDetails;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Label lblModelYear;
        private System.Windows.Forms.Label lblVehicleType;
        private System.Windows.Forms.TextBox tbVin;
        private System.Windows.Forms.Label lblVin;
        private System.Windows.Forms.TextBox tbOrderID;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPONumber;
        private System.Windows.Forms.Button btnSearchVendor;
        private System.Windows.Forms.TextBox tbVendor;
        private System.Windows.Forms.Button btAddToOrder;
        private System.Windows.Forms.TextBox tbCost;
        private System.Windows.Forms.Label lblSalesPrice;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.TextBox tbPartNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvPartsList;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btAddVendor;
    }
}