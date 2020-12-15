using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurdellsRamblinWrecks.Reports
{
    public partial class MonthlySalesReport : Form
    {
        protected List<ReportClasses.MonthlySalesReport> MSReport = null;
        public MonthlySalesReport()
        {
            InitializeComponent();
            var Task = new Tasks.MonthlySales();
            this.MSReport = Task.GenerateReport();
            this.dgvSearchResults.DataSource = this.MSReport;
            this.dgvSearchResults.CellDoubleClick += dgvSearchResults_CellDoubleClick;

        }

        private void dgvSearchResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow != null)
            {
                var rowResult = dgv.CurrentRow.DataBoundItem as ReportClasses.MonthlySalesReport;
                if (rowResult != null)
                {
                    var MSDrilldownForm = new Reports.MonthlySalesDrilldownReport(rowResult);
                    MSDrilldownForm.StartPosition = FormStartPosition.CenterParent;
                    MSDrilldownForm.ShowDialog();
                }
            }
        }
    }
}
