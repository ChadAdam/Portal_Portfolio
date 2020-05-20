using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurdellsRamblinWrecks.Queries;

namespace BurdellsRamblinWrecks.Tasks
{
    class SellerHistory
    { 
        public List<Reports.ReportClasses.SellerHistoryReport> GenerateReport()
        {
            var query = new QueryExecutor();
            return query.GenerateSellerHistoryReport();
        }
    }
}
