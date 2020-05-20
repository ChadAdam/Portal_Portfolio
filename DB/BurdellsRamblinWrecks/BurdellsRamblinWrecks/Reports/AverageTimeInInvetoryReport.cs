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
    public partial class AverageTimeInInvetoryReport : Form
    {
        protected List<Tuple<String, String>> avgResults = null;
        public AverageTimeInInvetoryReport()
        {
            InitializeComponent();
            var searchTask = new Tasks.AverageTimeInInventory();
            this.avgResults = searchTask.GenerateReport();
            this.dgvSearchResults.DataSource = this.avgResults;
            this.dgvSearchResults.Columns[0].HeaderText = "VehicleType";
            this.dgvSearchResults.Columns[1].HeaderText = "Average Time In Inventory";
        }

       /* private void AvgTimeReportButton_Click(object sender, EventArgs e)
        {
            var searchTask = new Tasks.AverageTimeInInventory();
            this.avgResults = searchTask.GenerateReport();
            this.dgvSearchResults.DataSource = this.avgResults;
            this.dgvSearchResults.Columns[0].HeaderText = "VehicleType";
            this.dgvSearchResults.Columns[1].HeaderText = "Average Time In Inventory";
        }*/
    }
}
