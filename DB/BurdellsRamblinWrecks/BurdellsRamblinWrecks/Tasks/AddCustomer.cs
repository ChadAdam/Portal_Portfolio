using BurdellsRamblinWrecks.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Tasks
{
    public class AddCustomer
    {
        public void AddNewCustomer(string phone_number, string email, string address_street, string address_state, string address_postal_code, string address_city, string tax_identification_number, string business_name, string primary_contact_title, string primary_contact_first_name, string primary_contact_last_name, string drivers_license_number, string first_name, string last_name, bool individual)
        {
            var query = new QueryExecutor();
            string customerid = Guid.NewGuid().ToString();
            query.InsertCustomer(customerid, phone_number, email, address_street, address_state, address_postal_code, address_city, tax_identification_number, business_name, primary_contact_title, primary_contact_first_name, primary_contact_last_name, drivers_license_number, first_name, last_name, individual);
        }
    }
}
