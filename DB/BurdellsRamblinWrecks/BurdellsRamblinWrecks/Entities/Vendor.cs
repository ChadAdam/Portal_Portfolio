using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Entities
{
    public class Vendor
    {
        public string vendor_name { get; set; }
        public string address_street { get; set; }
        public string address_city { get; set; }
        public string address_state { get; set; }
        public string address_postal_code { get; set; }
        public string phone_number { get; set; }
    }
}
