using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Tasks
{
    class PartsOrder
    {
        public void CreatePartsOrder(string vin, string username, string ponumber, string vendor_name, List<Entities.Part> PartList)
        {
            Queries.QueryExecutor Query = new Queries.QueryExecutor();
            var orderID = Guid.NewGuid();
            Query.InsertPartsOrder(orderID.ToString(), vin, username, ponumber, vendor_name, PartList);
        }

        public List<Entities.PartWithOrder> QueryPartsForVechicle(string vin)
        {
            Queries.QueryExecutor query = new Queries.QueryExecutor();
            return query.QueryPartsForVechicle(vin);
        }

        public void updatePartStatus(string orderid, string partnumber, string newstatus)
        {
            var query = new Queries.QueryExecutor();
            query.UpdatePartStatus(orderid, partnumber, newstatus);
        }

        public string GeneratePONumber(string vin)
        {
            var query = new Queries.QueryExecutor();
            List<string> allPOs = query.getAllPoNumbersForVIN(vin) ?? new List<string>();
            int count = allPOs.Count;
            return vin + "-" + (count + 1).ToString("D3");
        }
    }
}