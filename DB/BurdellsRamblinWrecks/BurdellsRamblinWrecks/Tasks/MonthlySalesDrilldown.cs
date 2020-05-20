using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BurdellsRamblinWrecks.Queries;

using BurdellsRamblinWrecks.Reports;

namespace BurdellsRamblinWrecks.Tasks
{
    class MonthlySalesDrilldown
    {
        public List<Reports.ReportClasses.MonthlySalesDrilldownReport> GenerateReport(Reports.ReportClasses.MonthlySalesReport inputDetails)
        {
            var query = new QueryExecutor();
            return query.GenerateMonthlySalesDrilldownReport(inputDetails);
        }
    }
}
