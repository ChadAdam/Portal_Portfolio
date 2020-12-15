using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Entities
{
    public class Vehicle
    {
        public string VIN { get; set; }
        [DisplayName("Vehicle Type")]
        public string vehicleTypeId { get; set; }
        [DisplayName("Model Year")]
        public string model_year { get; set; }
        [DisplayName("Manufacturer")]
        public string manufacturerId { get; set; }
        [DisplayName("Model")]
        public string model_name { get; set; }
        [DisplayName("Color(s)")]
        public string color { get; set; }
        [DisplayName("Mileage")]
        public string mileage { get; set; }
        [System.ComponentModel.Browsable(false)]
        public decimal purchase_price { get; set; }
        [DisplayName("Sales Price")]
        public decimal sales_price
        {
            get
            {
                try
                {
                    // 125% of purchase price
                    var calculatedSalesPrice = this.purchase_price * 1.25m;

                    // 110% of parts costs                
                    var totalPartsCost = total_parts_cost * 1.10m;
                    return Math.Round(calculatedSalesPrice + totalPartsCost, 2);
                }
                catch
                {
                    return 0m;
                }
            }
        }
        [System.ComponentModel.Browsable(false)]
        public string description { get; set; }
        [System.ComponentModel.Browsable(false)]
        public decimal total_parts_cost { get; set; }
    }
}
