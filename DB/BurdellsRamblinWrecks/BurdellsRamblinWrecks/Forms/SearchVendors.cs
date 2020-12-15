using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurdellsRamblinWrecks.Forms
{
    public partial class SearchVendors : Form
    {
        public Entities.Vendor SelectedVendor { get; set; }

        public SearchVendors()
        {
            InitializeComponent();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            var task = new Tasks.AddVendor();
            List<Entities.Vendor> vendors = task.SearchVendors(tbVendorName.Text);

            this.dgvVendors.DataSource = vendors;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.SelectedVendor = null;
            DataGridView dgv = dgvVendors;
            if (dgv.CurrentRow != null)
            {
                var vendor = dgv.CurrentRow.DataBoundItem as Entities.Vendor;
                if (vendor != null)
                {
                    this.SelectedVendor = vendor;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a vendor before continuing.", "Vendor Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
