using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurdellsRamblinWrecks.Queries;

namespace BurdellsRamblinWrecks.Tasks
{
    class AverageTimeInInventory
    {
        public List< Tuple< String, String>> GenerateReport()
        {
            var query = new QueryExecutor();
            return query.GenerateAverageTimeInInventoryReport();
        }
    }
}
