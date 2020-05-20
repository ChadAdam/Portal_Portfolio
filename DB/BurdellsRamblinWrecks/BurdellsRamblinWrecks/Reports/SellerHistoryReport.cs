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

namespace BurdellsRamblinWrecks.Reports
{
    public partial class SellerHistoryReport : Form
    {
        protected List<ReportClasses.SellerHistoryReport> ReportRows = null;
        public SellerHistoryReport()
        {
            InitializeComponent();
            var Task = new Tasks.SellerHistory();
            this.ReportRows = Task.GenerateReport();
            this.dgvSearchResults.DataSource = this.ReportRows;
            this.dgvSearchResults.Columns[0].HeaderText = "Name";
            this.dgvSearchResults.Columns[1].HeaderText = "Total Sold";
            this.dgvSearchResults.Columns[2].HeaderText = "Average Purchase Price";
            this.dgvSearchResults.Columns[3].HeaderText = "Average # of Parts";
            this.dgvSearchResults.Columns[4].HeaderText = "Average Part Cost";
            dgvSearchResults.CellFormatting += DgvSearchResults_CellFormatting;
        }

        private void DgvSearchResults_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvSearchResults.Rows)
            {
                double tmpAvgNumParts = 0;
                double.TryParse(row.Cells[3].Value.ToString(), out tmpAvgNumParts);
                double tmpAgvPartCost = 0;
                double.TryParse(row.Cells[4].Value.ToString(), System.Globalization.NumberStyles.Currency, CultureInfo.CurrentCulture, out tmpAgvPartCost);
                if (tmpAvgNumParts >= 5 || tmpAgvPartCost >= 500.00)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            
        }


    }
}
