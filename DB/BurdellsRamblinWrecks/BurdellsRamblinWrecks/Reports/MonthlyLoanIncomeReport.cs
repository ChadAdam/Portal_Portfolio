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
    public partial class MonthlyLoanIncomeReport : Form
    {
        protected List<Tuple<String, String, String, String>> MSIResults = null;
        public MonthlyLoanIncomeReport()
        {
            InitializeComponent();
            var searchTask = new Tasks.MonthlyLoanIncome();
            this.MSIResults = searchTask.GenerateReport();
            this.dgvSearchResults.DataSource = this.MSIResults;
            this.dgvSearchResults.Columns[0].HeaderText = "Month";
            this.dgvSearchResults.Columns[1].HeaderText = "Year";
            this.dgvSearchResults.Columns[2].HeaderText = "Total Monthly Payment";
            this.dgvSearchResults.Columns[3].HeaderText = "Total Monthly Income";
        }

    }
}
