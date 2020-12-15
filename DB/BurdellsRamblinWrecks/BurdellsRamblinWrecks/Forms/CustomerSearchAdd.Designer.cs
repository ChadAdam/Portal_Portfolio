namespace BurdellsRamblinWrecks.Forms
{
    partial class CustomerSearchAdd
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
            this.dgvCustomerSearch = new System.Windows.Forms.DataGridView();
            this.btClear = new System.Windows.Forms.Button();
            this.btAddNew = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbIndividual = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.txtbxID = new System.Windows.Forms.TextBox();
            this.txtbxNamelast = new System.Windows.Forms.TextBox();
            this.gbBusiness = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbPrimaryContactLast = new System.Windows.Forms.TextBox();
            this.txtbxTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbxNameBus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPrimaryContactFirst = new System.Windows.Forms.TextBox();
            this.txtbxIDBus = new System.Windows.Forms.TextBox();
            this.txtbxPostal = new System.Windows.Forms.TextBox();
            this.txtbxState = new System.Windows.Forms.TextBox();
            this.txtbxCity = new System.Windows.Forms.TextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            this.txtbxEmail = new System.Windows.Forms.TextBox();
            this.txtbxStreet = new System.Windows.Forms.TextBox();
            this.txtbxPhoneNum = new System.Windows.Forms.TextBox();
            this.radiobtnIndiv = new System.Windows.Forms.RadioButton();
            this.radiobtnBus = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerSearch)).BeginInit();
            this.gbIndividual.SuspendLayout();
            this.gbBusiness.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomerSearch
            // 
            this.dgvCustomerSearch.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCustomerSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCustomerSearch.Location = new System.Drawing.Point(21, 267);
            this.dgvCustomerSearch.MultiSelect = false;
            this.dgvCustomerSearch.Name = "dgvCustomerSearch";
            this.dgvCustomerSearch.ReadOnly = true;
            this.dgvCustomerSearch.RowHeadersVisible = false;
            this.dgvCustomerSearch.RowTemplate.Height = 24;
            this.dgvCustomerSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerSearch.ShowCellErrors = false;
            this.dgvCustomerSearch.ShowEditingIcon = false;
            this.dgvCustomerSearch.ShowRowErrors = false;
            this.dgvCustomerSearch.Size = new System.Drawing.Size(862, 262);
            this.dgvCustomerSearch.TabIndex = 88;
            this.dgvCustomerSearch.TabStop = false;
            // 
            // btClear
            // 
            this.btClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btClear.Location = new System.Drawing.Point(112, 221);
            this.btClear.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(87, 28);
            this.btClear.TabIndex = 98;
            this.btClear.TabStop = false;
            this.btClear.Text = "Clear Fields";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btAddNew
            // 
            this.btAddNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btAddNew.Location = new System.Drawing.Point(203, 221);
            this.btAddNew.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btAddNew.Name = "btAddNew";
            this.btAddNew.Size = new System.Drawing.Size(87, 28);
            this.btAddNew.TabIndex = 87;
            this.btAddNew.Text = "Add New";
            this.btAddNew.UseVisualStyleBackColor = true;
            this.btAddNew.Click += new System.EventHandler(this.btAddNew_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(663, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 97;
            this.label11.Text = "Phone:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(671, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 17);
            this.label10.TabIndex = 96;
            this.label10.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(628, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 17);
            this.label9.TabIndex = 95;
            this.label9.Text = "Postal Code:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(397, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 94;
            this.label8.Text = "State:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(407, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 93;
            this.label7.Text = "City:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 92;
            this.label4.Text = "Street:";
            // 
            // gbIndividual
            // 
            this.gbIndividual.Controls.Add(this.label1);
            this.gbIndividual.Controls.Add(this.lblLastName);
            this.gbIndividual.Controls.Add(this.lblFirstName);
            this.gbIndividual.Controls.Add(this.txtbxName);
            this.gbIndividual.Controls.Add(this.txtbxID);
            this.gbIndividual.Controls.Add(this.txtbxNamelast);
            this.gbIndividual.Location = new System.Drawing.Point(21, 17);
            this.gbIndividual.Name = "gbIndividual";
            this.gbIndividual.Size = new System.Drawing.Size(356, 187);
            this.gbIndividual.TabIndex = 91;
            this.gbIndividual.TabStop = false;
            this.gbIndividual.Text = "Individual Details:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "Driver\'s Lic. #:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(36, 72);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(80, 17);
            this.lblLastName.TabIndex = 66;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(36, 39);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(80, 17);
            this.lblFirstName.TabIndex = 65;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtbxName
            // 
            this.txtbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxName.Location = new System.Drawing.Point(121, 36);
            this.txtbxName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(162, 21);
            this.txtbxName.TabIndex = 1;
            // 
            // txtbxID
            // 
            this.txtbxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxID.Location = new System.Drawing.Point(121, 101);
            this.txtbxID.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxID.Name = "txtbxID";
            this.txtbxID.Size = new System.Drawing.Size(162, 21);
            this.txtbxID.TabIndex = 3;
            // 
            // txtbxNamelast
            // 
            this.txtbxNamelast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxNamelast.Location = new System.Drawing.Point(121, 69);
            this.txtbxNamelast.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxNamelast.Name = "txtbxNamelast";
            this.txtbxNamelast.Size = new System.Drawing.Size(162, 21);
            this.txtbxNamelast.TabIndex = 2;
            // 
            // gbBusiness
            // 
            this.gbBusiness.Controls.Add(this.label12);
            this.gbBusiness.Controls.Add(this.tbPrimaryContactLast);
            this.gbBusiness.Controls.Add(this.txtbxTitle);
            this.gbBusiness.Controls.Add(this.label3);
            this.gbBusiness.Controls.Add(this.label6);
            this.gbBusiness.Controls.Add(this.txtbxNameBus);
            this.gbBusiness.Controls.Add(this.label5);
            this.gbBusiness.Controls.Add(this.label2);
            this.gbBusiness.Controls.Add(this.tbPrimaryContactFirst);
            this.gbBusiness.Controls.Add(this.txtbxIDBus);
            this.gbBusiness.Location = new System.Drawing.Point(24, 16);
            this.gbBusiness.Name = "gbBusiness";
            this.gbBusiness.Size = new System.Drawing.Size(356, 187);
            this.gbBusiness.TabIndex = 69;
            this.gbBusiness.TabStop = false;
            this.gbBusiness.Text = "Business Details:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 17);
            this.label12.TabIndex = 76;
            this.label12.Text = "Contact Last Name:";
            // 
            // tbPrimaryContactLast
            // 
            this.tbPrimaryContactLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.tbPrimaryContactLast.Location = new System.Drawing.Point(155, 123);
            this.tbPrimaryContactLast.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbPrimaryContactLast.Name = "tbPrimaryContactLast";
            this.tbPrimaryContactLast.Size = new System.Drawing.Size(162, 21);
            this.tbPrimaryContactLast.TabIndex = 75;
            // 
            // txtbxTitle
            // 
            this.txtbxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxTitle.Location = new System.Drawing.Point(155, 153);
            this.txtbxTitle.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxTitle.Name = "txtbxTitle";
            this.txtbxTitle.Size = new System.Drawing.Size(162, 21);
            this.txtbxTitle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 74;
            this.label3.Text = "Contact Title:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 73;
            this.label6.Text = "Business Name:";
            // 
            // txtbxNameBus
            // 
            this.txtbxNameBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxNameBus.Location = new System.Drawing.Point(155, 61);
            this.txtbxNameBus.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxNameBus.Name = "txtbxNameBus";
            this.txtbxNameBus.Size = new System.Drawing.Size(162, 21);
            this.txtbxNameBus.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 71;
            this.label5.Text = "Contact First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "Tax ID #:";
            // 
            // tbPrimaryContactFirst
            // 
            this.tbPrimaryContactFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.tbPrimaryContactFirst.Location = new System.Drawing.Point(155, 92);
            this.tbPrimaryContactFirst.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbPrimaryContactFirst.Name = "tbPrimaryContactFirst";
            this.tbPrimaryContactFirst.Size = new System.Drawing.Size(162, 21);
            this.tbPrimaryContactFirst.TabIndex = 37;
            // 
            // txtbxIDBus
            // 
            this.txtbxIDBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxIDBus.Location = new System.Drawing.Point(155, 30);
            this.txtbxIDBus.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxIDBus.Name = "txtbxIDBus";
            this.txtbxIDBus.Size = new System.Drawing.Size(162, 21);
            this.txtbxIDBus.TabIndex = 36;
            // 
            // txtbxPostal
            // 
            this.txtbxPostal.Location = new System.Drawing.Point(721, 86);
            this.txtbxPostal.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxPostal.Name = "txtbxPostal";
            this.txtbxPostal.Size = new System.Drawing.Size(162, 22);
            this.txtbxPostal.TabIndex = 83;
            // 
            // txtbxState
            // 
            this.txtbxState.Location = new System.Drawing.Point(447, 151);
            this.txtbxState.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxState.Name = "txtbxState";
            this.txtbxState.Size = new System.Drawing.Size(162, 22);
            this.txtbxState.TabIndex = 82;
            // 
            // txtbxCity
            // 
            this.txtbxCity.Location = new System.Drawing.Point(447, 118);
            this.txtbxCity.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxCity.Name = "txtbxCity";
            this.txtbxCity.Size = new System.Drawing.Size(162, 22);
            this.txtbxCity.TabIndex = 81;
            // 
            // btnLookup
            // 
            this.btnLookup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnLookup.Location = new System.Drawing.Point(21, 221);
            this.btnLookup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(87, 28);
            this.btnLookup.TabIndex = 86;
            this.btnLookup.Text = "Search";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // txtbxEmail
            // 
            this.txtbxEmail.Location = new System.Drawing.Point(721, 118);
            this.txtbxEmail.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxEmail.Name = "txtbxEmail";
            this.txtbxEmail.Size = new System.Drawing.Size(162, 22);
            this.txtbxEmail.TabIndex = 84;
            // 
            // txtbxStreet
            // 
            this.txtbxStreet.Location = new System.Drawing.Point(447, 86);
            this.txtbxStreet.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxStreet.Name = "txtbxStreet";
            this.txtbxStreet.Size = new System.Drawing.Size(162, 22);
            this.txtbxStreet.TabIndex = 80;
            // 
            // txtbxPhoneNum
            // 
            this.txtbxPhoneNum.Location = new System.Drawing.Point(721, 151);
            this.txtbxPhoneNum.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxPhoneNum.Name = "txtbxPhoneNum";
            this.txtbxPhoneNum.Size = new System.Drawing.Size(162, 22);
            this.txtbxPhoneNum.TabIndex = 85;
            // 
            // radiobtnIndiv
            // 
            this.radiobtnIndiv.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radiobtnIndiv.FlatAppearance.BorderSize = 10;
            this.radiobtnIndiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.radiobtnIndiv.Location = new System.Drawing.Point(494, 25);
            this.radiobtnIndiv.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.radiobtnIndiv.Name = "radiobtnIndiv";
            this.radiobtnIndiv.Size = new System.Drawing.Size(115, 49);
            this.radiobtnIndiv.TabIndex = 90;
            this.radiobtnIndiv.Text = "Individual";
            this.radiobtnIndiv.UseVisualStyleBackColor = true;
            // 
            // radiobtnBus
            // 
            this.radiobtnBus.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radiobtnBus.FlatAppearance.BorderSize = 10;
            this.radiobtnBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.radiobtnBus.Location = new System.Drawing.Point(397, 17);
            this.radiobtnBus.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.radiobtnBus.MaximumSize = new System.Drawing.Size(100, 100);
            this.radiobtnBus.Name = "radiobtnBus";
            this.radiobtnBus.Size = new System.Drawing.Size(100, 65);
            this.radiobtnBus.TabIndex = 89;
            this.radiobtnBus.Text = "Business";
            this.radiobtnBus.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(295, 228);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(436, 17);
            this.label13.TabIndex = 101;
            this.label13.Text = "Note: A new customer will be added based on the information above";
            // 
            // btOk
            // 
            this.btOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btOk.Location = new System.Drawing.Point(356, 533);
            this.btOk.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 28);
            this.btOk.TabIndex = 20;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btCancel.Location = new System.Drawing.Point(447, 533);
            this.btCancel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 28);
            this.btCancel.TabIndex = 21;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // CustomerSearchAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 570);
            this.ControlBox = false;
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dgvCustomerSearch);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.gbBusiness);
            this.Controls.Add(this.btAddNew);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbIndividual);
            this.Controls.Add(this.txtbxPostal);
            this.Controls.Add(this.txtbxState);
            this.Controls.Add(this.txtbxCity);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.txtbxEmail);
            this.Controls.Add(this.txtbxStreet);
            this.Controls.Add(this.txtbxPhoneNum);
            this.Controls.Add(this.radiobtnIndiv);
            this.Controls.Add(this.radiobtnBus);
            this.MaximumSize = new System.Drawing.Size(920, 617);
            this.MinimumSize = new System.Drawing.Size(920, 617);
            this.Name = "CustomerSearchAdd";
            this.Text = "CustomerSearch";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerSearch)).EndInit();
            this.gbIndividual.ResumeLayout(false);
            this.gbIndividual.PerformLayout();
            this.gbBusiness.ResumeLayout(false);
            this.gbBusiness.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvCustomerSearch;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btAddNew;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbIndividual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.TextBox txtbxNamelast;
        private System.Windows.Forms.TextBox txtbxID;
        private System.Windows.Forms.GroupBox gbBusiness;
        private System.Windows.Forms.TextBox txtbxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbxNameBus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPrimaryContactFirst;
        private System.Windows.Forms.TextBox txtbxIDBus;
        private System.Windows.Forms.TextBox txtbxPostal;
        private System.Windows.Forms.TextBox txtbxState;
        private System.Windows.Forms.TextBox txtbxCity;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.TextBox txtbxStreet;
        private System.Windows.Forms.TextBox txtbxPhoneNum;
        private System.Windows.Forms.RadioButton radiobtnIndiv;
        private System.Windows.Forms.RadioButton radiobtnBus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbPrimaryContactLast;
    }
}