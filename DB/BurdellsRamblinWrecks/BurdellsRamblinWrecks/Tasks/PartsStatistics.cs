using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BurdellsRamblinWrecks.Queries;

namespace BurdellsRamblinWrecks.Tasks
{
    class PartsStatistics
    {
        public List<Tuple<String, short, String>> GenerateReport()
        {
            var query = new QueryExecutor();
            return query.GeneratePartsStatisticsReport();
        }
    }
}
