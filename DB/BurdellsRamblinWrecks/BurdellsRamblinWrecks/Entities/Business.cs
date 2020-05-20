using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Entities
{
    class Business
    {
        [DisplayName("Tax ID Number")]
        public string taxID { get; set; }
        [DisplayName("Business Name")]
        public string business_name { get; set; }
        [DisplayName("Contact First Name")]
        public string fName { get; set; }
        [DisplayName("Contact Last Name")]
        public string lName { get; set; }
        [DisplayName("Customer ID")]
        public string cust_id { get; set; }
        [DisplayName("Contact Person Title")]
        public string contact_person_title { get; set; }
    }
}
