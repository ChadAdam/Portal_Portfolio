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
    public partial class PricePerConditionReport : Form
    {
        protected List<ReportClasses.PricePerConditionReport> ReportRows = null;
        public PricePerConditionReport()
        {
            InitializeComponent();
            var Task = new Tasks.PricePerCondition();
            this.ReportRows = Task.GenerateReport();
            this.dgvSearchResults.DataSource = this.ReportRows;
            this.dgvSearchResults.Columns[0].HeaderText = "Vehicle Type";
            this.dgvSearchResults.Columns[1].HeaderText = "Excellent";
            this.dgvSearchResults.Columns[2].HeaderText = "Very Good";
            this.dgvSearchResults.Columns[3].HeaderText = "Good";
            this.dgvSearchResults.Columns[4].HeaderText = "Fair";

        }
    }
}
