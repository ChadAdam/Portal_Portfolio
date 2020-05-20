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

    public partial class MonthlySalesDrilldownReport : Form
    {
        protected List<ReportClasses.MonthlySalesDrilldownReport> reportDetails = null;
        public MonthlySalesDrilldownReport(ReportClasses.MonthlySalesReport inputDetails)
        {
            InitializeComponent();
            var Task = new Tasks.MonthlySalesDrilldown();
            this.reportDetails = Task.GenerateReport(inputDetails);
            this.dgvSearchResults.DataSource = this.reportDetails;
        }
    }
}
