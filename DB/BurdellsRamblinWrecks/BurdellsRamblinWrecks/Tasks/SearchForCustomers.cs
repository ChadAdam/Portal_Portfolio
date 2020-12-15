using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurdellsRamblinWrecks.Entities;
using BurdellsRamblinWrecks.Queries;
using BurdellsRamblinWrecks.Forms;

namespace BurdellsRamblinWrecks.Tasks
{
    public class SearchForCustomers
    {      
        public List<Customer> Search(string phone_number, string email, string address_street, string address_state, string address_postal_code, string address_city, string tax_identification_number, string business_name, string primary_contact_title, string primary_contact_first_name, string primary_contact_last_name, string drivers_license_number, string first_name, string last_name, bool individualSearch)
        {
            var query = new QueryExecutor();
            string sqlText = individualSearch ? SqlTextAll.queryIndividualSearch : SqlTextAll.queryBusinessSearch;

            return query.SearchForCustomers(sqlText, phone_number, email, address_street, address_state, address_postal_code, address_city, tax_identification_number, business_name, primary_contact_title, primary_contact_first_name, primary_contact_last_name, drivers_license_number, first_name, last_name, individualSearch);
        }

    }

}


