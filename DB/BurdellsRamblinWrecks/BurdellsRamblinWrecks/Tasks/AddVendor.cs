using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurdellsRamblinWrecks.Queries;

namespace BurdellsRamblinWrecks.Tasks
{
    class AddVendor
    {
        public void AddNewVendor(string vendor_name, string street, string city, string state, string postal, string phone)
        {
            var query = new QueryExecutor();
            query.InsertVendor(vendor_name, street, city, state, postal, phone);
        }

        public List<Entities.Vendor> SearchVendors(string vendor_name)
        {
            var query = new QueryExecutor();
            return query.querySearchVendors(vendor_name);
        }
    }
}
