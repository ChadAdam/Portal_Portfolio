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
    public partial class PartsStatisticsReport : Form
    {
        protected List<Tuple<String, short, String>> partsResults = null;
        public PartsStatisticsReport()
        {
            InitializeComponent();
            var searchTask = new Tasks.PartsStatistics();
            this.partsResults = searchTask.GenerateReport();
            this.dgvSearchResults.DataSource = this.partsResults;
            this.dgvSearchResults.Columns[0].HeaderText = "Vendor Name";
            this.dgvSearchResults.Columns[1].HeaderText = "Number of Parts Supplied";
            this.dgvSearchResults.Columns[2].HeaderText = "Average cost of the parts";
        }
    }
}
