namespace BurdellsRamblinWrecks.Forms
{
    partial class VehicleSearch
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
            this.btSearch = new System.Windows.Forms.Button();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTotalCarsAvail = new System.Windows.Forms.TextBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btSearchSold = new System.Windows.Forms.Button();
            this.tbVinSearch = new System.Windows.Forms.TextBox();
            this.lblVinSearch = new System.Windows.Forms.Label();
            this.tbKeyword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.tbModelYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbManufactorer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbVehicleType = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlySalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyLoanIncomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partsStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pricePerConditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageTimeInInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellerHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSorryGridEmpty = new System.Windows.Forms.Label();
            this.lblCurrentUserDesc = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.llLoginLogout = new System.Windows.Forms.LinkLabel();
            this.lblPleaseSelect = new System.Windows.Forms.Label();
            this.tbTotalPartsPending = new System.Windows.Forms.TextBox();
            this.lblTotalPartsPending = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(12, 128);
            this.btSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(100, 28);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.AllowUserToAddRows = false;
            this.dgvSearchResults.AllowUserToDeleteRows = false;
            this.dgvSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearchResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearchResults.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSearchResults.Location = new System.Drawing.Point(16, 270);
            this.dgvSearchResults.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSearchResults.MultiSelect = false;
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.ReadOnly = true;
            this.dgvSearchResults.RowHeadersVisible = false;
            this.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchResults.ShowCellErrors = false;
            this.dgvSearchResults.ShowEditingIcon = false;
            this.dgvSearchResults.ShowRowErrors = false;
            this.dgvSearchResults.Size = new System.Drawing.Size(1156, 702);
            this.dgvSearchResults.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Number of Cars Available To Purchase:";
            // 
            // tbTotalCarsAvail
            // 
            this.tbTotalCarsAvail.Location = new System.Drawing.Point(306, 53);
            this.tbTotalCarsAvail.Margin = new System.Windows.Forms.Padding(4);
            this.tbTotalCarsAvail.Name = "tbTotalCarsAvail";
            this.tbTotalCarsAvail.ReadOnly = true;
            this.tbTotalCarsAvail.Size = new System.Drawing.Size(93, 22);
            this.tbTotalCarsAvail.TabIndex = 3;
            // 
            // gbSearch
            // 
            this.gbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearch.Controls.Add(this.btSearchSold);
            this.gbSearch.Controls.Add(this.tbVinSearch);
            this.gbSearch.Controls.Add(this.lblVinSearch);
            this.gbSearch.Controls.Add(this.tbKeyword);
            this.gbSearch.Controls.Add(this.label6);
            this.gbSearch.Controls.Add(this.label5);
            this.gbSearch.Controls.Add(this.cbColor);
            this.gbSearch.Controls.Add(this.tbModelYear);
            this.gbSearch.Controls.Add(this.label4);
            this.gbSearch.Controls.Add(this.label3);
            this.gbSearch.Controls.Add(this.cbManufactorer);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Controls.Add(this.cbVehicleType);
            this.gbSearch.Controls.Add(this.btSearch);
            this.gbSearch.Location = new System.Drawing.Point(16, 98);
            this.gbSearch.Margin = new System.Windows.Forms.Padding(4);
            this.gbSearch.MinimumSize = new System.Drawing.Size(1156, 164);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Padding = new System.Windows.Forms.Padding(4);
            this.gbSearch.Size = new System.Drawing.Size(1156, 164);
            this.gbSearch.TabIndex = 4;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search for Vehicles";
            // 
            // btSearchSold
            // 
            this.btSearchSold.Location = new System.Drawing.Point(120, 128);
            this.btSearchSold.Margin = new System.Windows.Forms.Padding(4);
            this.btSearchSold.Name = "btSearchSold";
            this.btSearchSold.Size = new System.Drawing.Size(167, 28);
            this.btSearchSold.TabIndex = 14;
            this.btSearchSold.Text = "Search Previously Sold";
            this.btSearchSold.UseVisualStyleBackColor = true;
            this.btSearchSold.Click += new System.EventHandler(this.btSearchSold_Click);
            // 
            // tbVinSearch
            // 
            this.tbVinSearch.Location = new System.Drawing.Point(784, 91);
            this.tbVinSearch.Margin = new System.Windows.Forms.Padding(4);
            this.tbVinSearch.Name = "tbVinSearch";
            this.tbVinSearch.Size = new System.Drawing.Size(229, 22);
            this.tbVinSearch.TabIndex = 13;
            this.tbVinSearch.Visible = false;
            // 
            // lblVinSearch
            // 
            this.lblVinSearch.AutoSize = true;
            this.lblVinSearch.Location = new System.Drawing.Point(739, 95);
            this.lblVinSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVinSearch.Name = "lblVinSearch";
            this.lblVinSearch.Size = new System.Drawing.Size(34, 17);
            this.lblVinSearch.TabIndex = 12;
            this.lblVinSearch.Text = "VIN:";
            this.lblVinSearch.Visible = false;
            // 
            // tbKeyword
            // 
            this.tbKeyword.Location = new System.Drawing.Point(112, 91);
            this.tbKeyword.Margin = new System.Windows.Forms.Padding(4);
            this.tbKeyword.Name = "tbKeyword";
            this.tbKeyword.Size = new System.Drawing.Size(597, 22);
            this.tbKeyword.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Keyword:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Color:";
            // 
            // cbColor
            // 
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(484, 25);
            this.cbColor.Margin = new System.Windows.Forms.Padding(4);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(225, 24);
            this.cbColor.TabIndex = 8;
            // 
            // tbModelYear
            // 
            this.tbModelYear.Location = new System.Drawing.Point(484, 58);
            this.tbModelYear.Margin = new System.Windows.Forms.Padding(4);
            this.tbModelYear.Name = "tbModelYear";
            this.tbModelYear.Size = new System.Drawing.Size(93, 22);
            this.tbModelYear.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Model Year:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Manufacturer:";
            // 
            // cbManufactorer
            // 
            this.cbManufactorer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManufactorer.FormattingEnabled = true;
            this.cbManufactorer.Location = new System.Drawing.Point(112, 58);
            this.cbManufactorer.Margin = new System.Windows.Forms.Padding(4);
            this.cbManufactorer.Name = "cbManufactorer";
            this.cbManufactorer.Size = new System.Drawing.Size(225, 24);
            this.cbManufactorer.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vehicle Type:";
            // 
            // cbVehicleType
            // 
            this.cbVehicleType.BackColor = System.Drawing.SystemColors.Window;
            this.cbVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVehicleType.FormattingEnabled = true;
            this.cbVehicleType.Location = new System.Drawing.Point(112, 25);
            this.cbVehicleType.Margin = new System.Windows.Forms.Padding(4);
            this.cbVehicleType.Name = "cbVehicleType";
            this.cbVehicleType.Size = new System.Drawing.Size(225, 24);
            this.cbVehicleType.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1188, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVehicleToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 24);
            this.toolStripMenuItem1.Text = "Forms";
            // 
            // addVehicleToolStripMenuItem
            // 
            this.addVehicleToolStripMenuItem.Name = "addVehicleToolStripMenuItem";
            this.addVehicleToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.addVehicleToolStripMenuItem.Text = "Add Vehicle";
            this.addVehicleToolStripMenuItem.Click += new System.EventHandler(this.AddVehicleToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthlySalesToolStripMenuItem,
            this.monthlyLoanIncomeToolStripMenuItem,
            this.partsStatisticsToolStripMenuItem,
            this.pricePerConditionToolStripMenuItem,
            this.averageTimeInInventoryToolStripMenuItem,
            this.sellerHistoryToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // monthlySalesToolStripMenuItem
            // 
            this.monthlySalesToolStripMenuItem.Name = "monthlySalesToolStripMenuItem";
            this.monthlySalesToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.monthlySalesToolStripMenuItem.Text = "Monthly Sales";
            this.monthlySalesToolStripMenuItem.Click += new System.EventHandler(this.monthlySalesToolStripMenuItem_Click);
            // 
            // monthlyLoanIncomeToolStripMenuItem
            // 
            this.monthlyLoanIncomeToolStripMenuItem.Name = "monthlyLoanIncomeToolStripMenuItem";
            this.monthlyLoanIncomeToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.monthlyLoanIncomeToolStripMenuItem.Text = "Monthly Loan Income";
            this.monthlyLoanIncomeToolStripMenuItem.Click += new System.EventHandler(this.monthlyLoanIncomeToolStripMenuItem_Click);
            // 
            // partsStatisticsToolStripMenuItem
            // 
            this.partsStatisticsToolStripMenuItem.Name = "partsStatisticsToolStripMenuItem";
            this.partsStatisticsToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.partsStatisticsToolStripMenuItem.Text = "Parts Statistics";
            this.partsStatisticsToolStripMenuItem.Click += new System.EventHandler(this.partsStatisticsToolStripMenuItem_Click);
            // 
            // pricePerConditionToolStripMenuItem
            // 
            this.pricePerConditionToolStripMenuItem.Name = "pricePerConditionToolStripMenuItem";
            this.pricePerConditionToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.pricePerConditionToolStripMenuItem.Text = "Price Per Condition";
            this.pricePerConditionToolStripMenuItem.Click += new System.EventHandler(this.PricePerConditionToolStripMenuItem_Click);
            // 
            // averageTimeInInventoryToolStripMenuItem
            // 
            this.averageTimeInInventoryToolStripMenuItem.Name = "averageTimeInInventoryToolStripMenuItem";
            this.averageTimeInInventoryToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.averageTimeInInventoryToolStripMenuItem.Text = "Average Time In Inventory";
            this.averageTimeInInventoryToolStripMenuItem.Click += new System.EventHandler(this.averageTimeInInventoryToolStripMenuItem_Click);
            // 
            // sellerHistoryToolStripMenuItem
            // 
            this.sellerHistoryToolStripMenuItem.Name = "sellerHistoryToolStripMenuItem";
            this.sellerHistoryToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.sellerHistoryToolStripMenuItem.Text = "Seller History";
            this.sellerHistoryToolStripMenuItem.Click += new System.EventHandler(this.SellerHistoryToolStripMenuItem_Click);
            // 
            // lblSorryGridEmpty
            // 
            this.lblSorryGridEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSorryGridEmpty.AutoSize = true;
            this.lblSorryGridEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSorryGridEmpty.Location = new System.Drawing.Point(387, 404);
            this.lblSorryGridEmpty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSorryGridEmpty.Name = "lblSorryGridEmpty";
            this.lblSorryGridEmpty.Size = new System.Drawing.Size(402, 25);
            this.lblSorryGridEmpty.TabIndex = 6;
            this.lblSorryGridEmpty.Text = "Sorry, it looks like we don\'t have that in stock!";
            // 
            // lblCurrentUserDesc
            // 
            this.lblCurrentUserDesc.AutoSize = true;
            this.lblCurrentUserDesc.Location = new System.Drawing.Point(824, 57);
            this.lblCurrentUserDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentUserDesc.Name = "lblCurrentUserDesc";
            this.lblCurrentUserDesc.Size = new System.Drawing.Size(93, 17);
            this.lblCurrentUserDesc.TabIndex = 7;
            this.lblCurrentUserDesc.Text = "Current User:";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(912, 57);
            this.lblCurrentUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(149, 17);
            this.lblCurrentUser.TabIndex = 8;
            this.lblCurrentUser.Text = "Public (Not Logged In)";
            // 
            // llLoginLogout
            // 
            this.llLoginLogout.AutoSize = true;
            this.llLoginLogout.Location = new System.Drawing.Point(824, 79);
            this.llLoginLogout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llLoginLogout.Name = "llLoginLogout";
            this.llLoginLogout.Size = new System.Drawing.Size(43, 17);
            this.llLoginLogout.TabIndex = 9;
            this.llLoginLogout.TabStop = true;
            this.llLoginLogout.Text = "Login";
            this.llLoginLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLoginLogout_LinkClicked);
            // 
            // lblPleaseSelect
            // 
            this.lblPleaseSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPleaseSelect.AutoSize = true;
            this.lblPleaseSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseSelect.Location = new System.Drawing.Point(419, 320);
            this.lblPleaseSelect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPleaseSelect.Name = "lblPleaseSelect";
            this.lblPleaseSelect.Size = new System.Drawing.Size(318, 25);
            this.lblPleaseSelect.TabIndex = 10;
            this.lblPleaseSelect.Text = "Please select search criteria above.";
            // 
            // tbTotalPartsPending
            // 
            this.tbTotalPartsPending.Location = new System.Drawing.Point(700, 53);
            this.tbTotalPartsPending.Margin = new System.Windows.Forms.Padding(4);
            this.tbTotalPartsPending.Name = "tbTotalPartsPending";
            this.tbTotalPartsPending.ReadOnly = true;
            this.tbTotalPartsPending.Size = new System.Drawing.Size(93, 22);
            this.tbTotalPartsPending.TabIndex = 12;
            // 
            // lblTotalPartsPending
            // 
            this.lblTotalPartsPending.AutoSize = true;
            this.lblTotalPartsPending.Location = new System.Drawing.Point(420, 57);
            this.lblTotalPartsPending.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPartsPending.Name = "lblTotalPartsPending";
            this.lblTotalPartsPending.Size = new System.Drawing.Size(272, 17);
            this.lblTotalPartsPending.TabIndex = 11;
            this.lblTotalPartsPending.Text = "Total Number of Cars With Parts Pending:";
            // 
            // VehicleSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 986);
            this.Controls.Add(this.tbTotalPartsPending);
            this.Controls.Add(this.lblTotalPartsPending);
            this.Controls.Add(this.lblPleaseSelect);
            this.Controls.Add(this.llLoginLogout);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.lblCurrentUserDesc);
            this.Controls.Add(this.lblSorryGridEmpty);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.tbTotalCarsAvail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSearchResults);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1202, 1006);
            this.Name = "VehicleSearch";
            this.Text = "Burdell\'s Ramblin\' Wrecks - Vehicle Search";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTotalCarsAvail;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbVehicleType;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlySalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyLoanIncomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partsStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pricePerConditionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageTimeInInventoryToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbManufactorer;
        private System.Windows.Forms.TextBox tbModelYear;
        private System.Windows.Forms.TextBox tbKeyword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label lblSorryGridEmpty;
        private System.Windows.Forms.Label lblCurrentUserDesc;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.LinkLabel llLoginLogout;
        private System.Windows.Forms.TextBox tbVinSearch;
        private System.Windows.Forms.Label lblVinSearch;
        private System.Windows.Forms.Label lblPleaseSelect;
        private System.Windows.Forms.ToolStripMenuItem addVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellerHistoryToolStripMenuItem;
        private System.Windows.Forms.TextBox tbTotalPartsPending;
        private System.Windows.Forms.Label lblTotalPartsPending;
        private System.Windows.Forms.Button btSearchSold;
    }
}