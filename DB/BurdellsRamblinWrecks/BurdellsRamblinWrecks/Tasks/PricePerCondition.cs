using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurdellsRamblinWrecks.Queries;

namespace BurdellsRamblinWrecks.Tasks
{
    class PricePerCondition
    {
        public List<Reports.ReportClasses.PricePerConditionReport> GenerateReport()
        {
            var query = new QueryExecutor();
            return query.GeneratePricePerConditionReport();
        }
    }
}
