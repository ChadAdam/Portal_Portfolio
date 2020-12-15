namespace BurdellsRamblinWrecks.Forms
{
    partial class SearchVendors
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
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.dgvVendors = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.tbVendorName = new System.Windows.Forms.TextBox();
            this.btnLookup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendors)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btCancel.Location = new System.Drawing.Point(440, 343);
            this.btCancel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 28);
            this.btCancel.TabIndex = 90;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btOk.Location = new System.Drawing.Point(349, 343);
            this.btOk.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 28);
            this.btOk.TabIndex = 89;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // dgvVendors
            // 
            this.dgvVendors.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvVendors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvVendors.Location = new System.Drawing.Point(12, 55);
            this.dgvVendors.MultiSelect = false;
            this.dgvVendors.Name = "dgvVendors";
            this.dgvVendors.ReadOnly = true;
            this.dgvVendors.RowHeadersVisible = false;
            this.dgvVendors.RowTemplate.Height = 24;
            this.dgvVendors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendors.ShowCellErrors = false;
            this.dgvVendors.ShowEditingIcon = false;
            this.dgvVendors.ShowRowErrors = false;
            this.dgvVendors.Size = new System.Drawing.Size(862, 262);
            this.dgvVendors.TabIndex = 91;
            this.dgvVendors.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 17);
            this.label8.TabIndex = 97;
            this.label8.Text = "Vendor Name:";
            // 
            // tbVendorName
            // 
            this.tbVendorName.Location = new System.Drawing.Point(116, 15);
            this.tbVendorName.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tbVendorName.Name = "tbVendorName";
            this.tbVendorName.Size = new System.Drawing.Size(162, 22);
            this.tbVendorName.TabIndex = 95;
            // 
            // btnLookup
            // 
            this.btnLookup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnLookup.Location = new System.Drawing.Point(291, 11);
            this.btnLookup.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(87, 28);
            this.btnLookup.TabIndex = 96;
            this.btnLookup.Text = "Search";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // SearchVendors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 388);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbVendorName);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.dgvVendors);
            this.Name = "SearchVendors";
            this.Text = "SearchVendors";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.DataGridView dgvVendors;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbVendorName;
        private System.Windows.Forms.Button btnLookup;
    }
}