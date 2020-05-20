using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Entities
{
    class Individual
    {
        [DisplayName("First Name")]
        public string fName { get; set; }
        [DisplayName("Last Name")]
        public string lName { get; set; }
        [DisplayName("Customer ID")]
        public string cust_id { get; set; }
        [DisplayName("Driver License Number")]
        public string driver_license_num { get; set; }
    }
}
