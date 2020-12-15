namespace BurdellsRamblinWrecks.Forms
{
    partial class SearchCustomer
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
            this.txtbxID = new System.Windows.Forms.TextBox();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            this.radiobtnBus = new System.Windows.Forms.RadioButton();
            this.radiobtnIndiv = new System.Windows.Forms.RadioButton();
            this.txtbxPhoneNum = new System.Windows.Forms.TextBox();
            this.txtbxStreet = new System.Windows.Forms.TextBox();
            this.txtbxEmail = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAdres = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPNumber = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtbxContact = new System.Windows.Forms.TextBox();
            this.txtbxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtbxCity = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtbxState = new System.Windows.Forms.TextBox();
            this.lblPostal = new System.Windows.Forms.Label();
            this.txtbxPostal = new System.Windows.Forms.TextBox();
            this.lblNameBus = new System.Windows.Forms.Label();
            this.lblIDBus = new System.Windows.Forms.Label();
            this.txtbxNameBus = new System.Windows.Forms.TextBox();
            this.txtbxIDBus = new System.Windows.Forms.TextBox();
            this.lblNamelast = new System.Windows.Forms.Label();
            this.txtbxNamelast = new System.Windows.Forms.TextBox();
            this.lblNamelastBus = new System.Windows.Forms.Label();
            this.txtbxNamelastBus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtbxID
            // 
            this.txtbxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxID.Location = new System.Drawing.Point(207, 27);
            this.txtbxID.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxID.Name = "txtbxID";
            this.txtbxID.Size = new System.Drawing.Size(140, 21);
            this.txtbxID.TabIndex = 0;
            this.txtbxID.TextChanged += new System.EventHandler(this.txtbxID_TextChanged);
            // 
            // txtbxName
            // 
            this.txtbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxName.Location = new System.Drawing.Point(207, 67);
            this.txtbxName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(140, 21);
            this.txtbxName.TabIndex = 1;
            this.txtbxName.TextChanged += new System.EventHandler(this.txtbxName_TextChanged);
            // 
            // btnLookup
            // 
            this.btnLookup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnLookup.Location = new System.Drawing.Point(289, 264);
            this.btnLookup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(87, 25);
            this.btnLookup.TabIndex = 2;
            this.btnLookup.Text = "Add";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // radiobtnBus
            // 
            this.radiobtnBus.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radiobtnBus.FlatAppearance.BorderSize = 10;
            this.radiobtnBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.radiobtnBus.Location = new System.Drawing.Point(531, 48);
            this.radiobtnBus.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.radiobtnBus.MaximumSize = new System.Drawing.Size(100, 100);
            this.radiobtnBus.Name = "radiobtnBus";
            this.radiobtnBus.Size = new System.Drawing.Size(100, 65);
            this.radiobtnBus.TabIndex = 3;
            this.radiobtnBus.TabStop = true;
            this.radiobtnBus.Text = "Business";
            this.radiobtnBus.UseVisualStyleBackColor = true;
            this.radiobtnBus.CheckedChanged += new System.EventHandler(this.radiobtnBus_CheckedChanged);
            // 
            // radiobtnIndiv
            // 
            this.radiobtnIndiv.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.radiobtnIndiv.FlatAppearance.BorderSize = 10;
            this.radiobtnIndiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.radiobtnIndiv.Location = new System.Drawing.Point(531, 100);
            this.radiobtnIndiv.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.radiobtnIndiv.Name = "radiobtnIndiv";
            this.radiobtnIndiv.Size = new System.Drawing.Size(115, 78);
            this.radiobtnIndiv.TabIndex = 4;
            this.radiobtnIndiv.TabStop = true;
            this.radiobtnIndiv.Text = "Individual";
            this.radiobtnIndiv.UseVisualStyleBackColor = true;
            this.radiobtnIndiv.CheckedChanged += new System.EventHandler(this.radiobtnIndiv_CheckedChanged);
            // 
            // txtbxPhoneNum
            // 
            this.txtbxPhoneNum.Location = new System.Drawing.Point(403, 248);
            this.txtbxPhoneNum.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxPhoneNum.Name = "txtbxPhoneNum";
            this.txtbxPhoneNum.Size = new System.Drawing.Size(87, 17);
            this.txtbxPhoneNum.TabIndex = 5;
            this.txtbxPhoneNum.TextChanged += new System.EventHandler(this.txtbxPhoneNum_TextChanged);
            // 
            // txtbxStreet
            // 
            this.txtbxStreet.Location = new System.Drawing.Point(76, 178);
            this.txtbxStreet.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxStreet.Name = "txtbxStreet";
            this.txtbxStreet.Size = new System.Drawing.Size(87, 17);
            this.txtbxStreet.TabIndex = 6;
            // 
            // txtbxEmail
            // 
            this.txtbxEmail.Location = new System.Drawing.Point(104, 248);
            this.txtbxEmail.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxEmail.Name = "txtbxEmail";
            this.txtbxEmail.Size = new System.Drawing.Size(87, 17);
            this.txtbxEmail.TabIndex = 7;
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblID.Location = new System.Drawing.Point(94, 27);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(86, 20);
            this.lblID.TabIndex = 8;
            this.lblID.Text = "Drivers ID:";
            this.lblID.Click += new System.EventHandler(this.lblID_Click);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblName.Location = new System.Drawing.Point(89, 59);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(81, 20);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "First Name:";
            this.lblName.Click += new System.EventHandler(this.lblName_Click_1);
            // 
            // lblAdres
            // 
            this.lblAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblAdres.Location = new System.Drawing.Point(94, 158);
            this.lblAdres.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdres.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(60, 15);
            this.lblAdres.TabIndex = 10;
            this.lblAdres.Text = "Street:";
            this.lblAdres.Click += new System.EventHandler(this.lblAdres_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblEmail.Location = new System.Drawing.Point(125, 219);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(45, 13);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "Email:";
            // 
            // lblPNumber
            // 
            this.lblPNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblPNumber.Location = new System.Drawing.Point(400, 219);
            this.lblPNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPNumber.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblPNumber.Name = "lblPNumber";
            this.lblPNumber.Size = new System.Drawing.Size(100, 20);
            this.lblPNumber.TabIndex = 12;
            this.lblPNumber.Text = "Phone #:";
            this.lblPNumber.Click += new System.EventHandler(this.lblPNumber_Click);
            // 
            // lblContact
            // 
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblContact.Location = new System.Drawing.Point(357, 98);
            this.lblContact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContact.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(60, 17);
            this.lblContact.TabIndex = 20;
            this.lblContact.Text = "Contact:";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblTitle.Location = new System.Drawing.Point(370, 49);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(50, 17);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Title:";
            // 
            // txtbxContact
            // 
            this.txtbxContact.Location = new System.Drawing.Point(424, 96);
            this.txtbxContact.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxContact.Name = "txtbxContact";
            this.txtbxContact.Size = new System.Drawing.Size(87, 17);
            this.txtbxContact.TabIndex = 18;
            // 
            // txtbxTitle
            // 
            this.txtbxTitle.Location = new System.Drawing.Point(424, 48);
            this.txtbxTitle.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxTitle.Name = "txtbxTitle";
            this.txtbxTitle.Size = new System.Drawing.Size(87, 17);
            this.txtbxTitle.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "lblGetCustomers";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // lblCity
            // 
            this.lblCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblCity.Location = new System.Drawing.Point(204, 158);
            this.lblCity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCity.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(60, 15);
            this.lblCity.TabIndex = 23;
            this.lblCity.Text = "City:";
            this.lblCity.Click += new System.EventHandler(this.lblCity_Click);
            // 
            // txtbxCity
            // 
            this.txtbxCity.Location = new System.Drawing.Point(193, 178);
            this.txtbxCity.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxCity.Name = "txtbxCity";
            this.txtbxCity.Size = new System.Drawing.Size(87, 17);
            this.txtbxCity.TabIndex = 22;
            this.txtbxCity.TextChanged += new System.EventHandler(this.txtbxCity_TextChanged_1);
            // 
            // lblState
            // 
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblState.Location = new System.Drawing.Point(314, 158);
            this.lblState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblState.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(60, 15);
            this.lblState.TabIndex = 25;
            this.lblState.Text = "State:";
            // 
            // txtbxState
            // 
            this.txtbxState.Location = new System.Drawing.Point(301, 178);
            this.txtbxState.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxState.Name = "txtbxState";
            this.txtbxState.Size = new System.Drawing.Size(87, 17);
            this.txtbxState.TabIndex = 24;
            // 
            // lblPostal
            // 
            this.lblPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblPostal.Location = new System.Drawing.Point(400, 158);
            this.lblPostal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPostal.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblPostal.Name = "lblPostal";
            this.lblPostal.Size = new System.Drawing.Size(90, 15);
            this.lblPostal.TabIndex = 27;
            this.lblPostal.Text = "Postal Code:";
            this.lblPostal.Click += new System.EventHandler(this.lblPostal_Click);
            // 
            // txtbxPostal
            // 
            this.txtbxPostal.Location = new System.Drawing.Point(403, 178);
            this.txtbxPostal.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxPostal.Name = "txtbxPostal";
            this.txtbxPostal.Size = new System.Drawing.Size(87, 17);
            this.txtbxPostal.TabIndex = 26;
            // 
            // lblNameBus
            // 
            this.lblNameBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblNameBus.Location = new System.Drawing.Point(89, 59);
            this.lblNameBus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameBus.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblNameBus.Name = "lblNameBus";
            this.lblNameBus.Size = new System.Drawing.Size(86, 20);
            this.lblNameBus.TabIndex = 31;
            this.lblNameBus.Text = "First Name:";
            this.lblNameBus.Click += new System.EventHandler(this.lblNameBus_Click);
            // 
            // lblIDBus
            // 
            this.lblIDBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblIDBus.Location = new System.Drawing.Point(94, 28);
            this.lblIDBus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIDBus.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblIDBus.Name = "lblIDBus";
            this.lblIDBus.Size = new System.Drawing.Size(86, 20);
            this.lblIDBus.TabIndex = 30;
            this.lblIDBus.Text = "Tax ID #:";
            this.lblIDBus.Click += new System.EventHandler(this.lblIDBus_Click);
            // 
            // txtbxNameBus
            // 
            this.txtbxNameBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxNameBus.Location = new System.Drawing.Point(207, 66);
            this.txtbxNameBus.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxNameBus.Name = "txtbxNameBus";
            this.txtbxNameBus.Size = new System.Drawing.Size(140, 21);
            this.txtbxNameBus.TabIndex = 29;
            this.txtbxNameBus.TextChanged += new System.EventHandler(this.txtbxNameBus_TextChanged);
            // 
            // txtbxIDBus
            // 
            this.txtbxIDBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxIDBus.Location = new System.Drawing.Point(207, 27);
            this.txtbxIDBus.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxIDBus.Name = "txtbxIDBus";
            this.txtbxIDBus.Size = new System.Drawing.Size(140, 21);
            this.txtbxIDBus.TabIndex = 28;
            this.txtbxIDBus.TextChanged += new System.EventHandler(this.txtbxIDBus_TextChanged);
            // 
            // lblNamelast
            // 
            this.lblNamelast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblNamelast.Location = new System.Drawing.Point(89, 95);
            this.lblNamelast.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNamelast.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblNamelast.Name = "lblNamelast";
            this.lblNamelast.Size = new System.Drawing.Size(86, 20);
            this.lblNamelast.TabIndex = 33;
            this.lblNamelast.Text = "Last Name:";
            this.lblNamelast.Click += new System.EventHandler(this.lblNamelast_Click);
            // 
            // txtbxNamelast
            // 
            this.txtbxNamelast.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxNamelast.Location = new System.Drawing.Point(207, 98);
            this.txtbxNamelast.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxNamelast.Name = "txtbxNamelast";
            this.txtbxNamelast.Size = new System.Drawing.Size(140, 21);
            this.txtbxNamelast.TabIndex = 32;
            this.txtbxNamelast.TextChanged += new System.EventHandler(this.txtbxNamelast_TextChanged);
            // 
            // lblNamelastBus
            // 
            this.lblNamelastBus.AccessibleName = "lblNamelast";
            this.lblNamelastBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.lblNamelastBus.Location = new System.Drawing.Point(89, 95);
            this.lblNamelastBus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNamelastBus.MaximumSize = new System.Drawing.Size(100, 100);
            this.lblNamelastBus.Name = "lblNamelastBus";
            this.lblNamelastBus.Size = new System.Drawing.Size(86, 20);
            this.lblNamelastBus.TabIndex = 35;
            this.lblNamelastBus.Text = "Last Name:";
            this.lblNamelastBus.Click += new System.EventHandler(this.lblNamelastBus_Click_1);
            // 
            // txtbxNamelastBus
            // 
            this.txtbxNamelastBus.AccessibleName = "lblNamelast";
            this.txtbxNamelastBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtbxNamelastBus.Location = new System.Drawing.Point(207, 98);
            this.txtbxNamelastBus.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtbxNamelastBus.Name = "txtbxNamelastBus";
            this.txtbxNamelastBus.Size = new System.Drawing.Size(140, 21);
            this.txtbxNamelastBus.TabIndex = 34;
            this.txtbxNamelastBus.TextChanged += new System.EventHandler(this.txtbxNamelastBus_TextChanged_3);
            // 
            // SearchCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 9F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 331);
            this.Controls.Add(this.lblPostal);
            this.Controls.Add(this.txtbxPostal);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.txtbxState);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtbxCity);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtbxContact);
            this.Controls.Add(this.txtbxTitle);
            this.Controls.Add(this.lblPNumber);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAdres);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtbxEmail);
            this.Controls.Add(this.txtbxStreet);
            this.Controls.Add(this.txtbxPhoneNum);
            this.Controls.Add(this.radiobtnIndiv);
            this.Controls.Add(this.radiobtnBus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtbxID);
            this.Controls.Add(this.lblNameBus);
            this.Controls.Add(this.lblIDBus);
            this.Controls.Add(this.lblNamelast);
            this.Controls.Add(this.lblNamelastBus);
            this.Controls.Add(this.txtbxNamelastBus);
            this.Controls.Add(this.txtbxNamelast);
            this.Controls.Add(this.txtbxNameBus);
            this.Controls.Add(this.txtbxName);
            this.Controls.Add(this.txtbxIDBus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "SearchCustomer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SearchCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.TextBox txtbxID;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.RadioButton radiobtnBus;
        private System.Windows.Forms.RadioButton radiobtnIndiv;
        private System.Windows.Forms.TextBox txtbxPhoneNum;
        private System.Windows.Forms.TextBox txtbxStreet;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPNumber;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtbxContact;
        private System.Windows.Forms.TextBox txtbxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtbxCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtbxState;
        private System.Windows.Forms.Label lblPostal;
        private System.Windows.Forms.TextBox txtbxPostal;
        private System.Windows.Forms.Label lblNameBus;
        private System.Windows.Forms.Label lblIDBus;
        private System.Windows.Forms.TextBox txtbxNameBus;
        private System.Windows.Forms.TextBox txtbxIDBus;
        private System.Windows.Forms.Label lblNamelast;
        private System.Windows.Forms.TextBox txtbxNamelast;
        private System.Windows.Forms.Label lblNamelastBus;
        private System.Windows.Forms.TextBox txtbxNamelastBus;
    }
}

