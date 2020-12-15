using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BurdellsRamblinWrecks.Queries;
using BurdellsRamblinWrecks.Reports;

namespace BurdellsRamblinWrecks.Tasks
{
    class MonthlySales
    {
        public List<Reports.ReportClasses.MonthlySalesReport> GenerateReport()
        {
            var query = new QueryExecutor();
            return query.GenerateMonthlySalesReport();
        }
    }
}
