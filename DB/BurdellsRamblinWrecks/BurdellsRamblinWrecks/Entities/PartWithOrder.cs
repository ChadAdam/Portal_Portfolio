using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Entities
{
    public class PartWithOrder
    {
        [DisplayName("Vendor Name")]
        public string vendor_name { get; set; }
        [DisplayName("PO Number")]
        public string po_number { get; set; }
        [DisplayName("Part Number")]
        public string partnumber { get; set; }
        [DisplayName("Order ID")]
        public string orderid { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Cost")]
        public decimal cost { get; set; }
        [DisplayName("Status ID")]
        public string statusid { get; set; }
        [System.ComponentModel.Browsable(false)]
        public string username { get; set; }
    }
}


