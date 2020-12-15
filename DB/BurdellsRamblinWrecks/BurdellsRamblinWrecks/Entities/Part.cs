using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Entities
{
    public class Part
    {
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
    }
}

