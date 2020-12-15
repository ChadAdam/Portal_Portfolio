using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Reports
{
    public class ReportClasses
    {
        public class PricePerConditionReport
        {
            [DisplayName("Vehicle Type")]
            public string VehicleType { get; set; }

            [DisplayName("Excellent")]
            public string cExcellent { get; set; }

            [DisplayName("Very Good")]
            public string cVeryGood { get; set; }

            [DisplayName("Good")]
            public string cGood { get; set; }

            [DisplayName("Fair")]
            public string cFair { get; set; }
        }

        public class MonthlySalesReport
        {
            [DisplayName("Sales Month")]
            public string sales_month { get; set; }

            [DisplayName("Sales Year")]
            public String sales_year { get; set; }

            [DisplayName("Vehicle Sold")]
            public String vehicle_amt { get; set; }

            [DisplayName("Sales Income")]
            public String sales_income { get; set; }

            [DisplayName("Net Income")]
            public String net_income { get; set; }    
        }

        public class MonthlySalesDrilldownReport
        {
            [DisplayName("Salesperson Name")]
            public string spname { get; set; }

            [DisplayName("Sales Month")]
            public string sales_month { get; set; }

            [DisplayName("Sales Year")]
            public String sales_year { get; set; }

            [DisplayName("Vehicle Sold")]
            public String vehicle_amt { get; set; }

            [DisplayName("Total Sales")]
            public String total_sales { get; set; }
        }

        public class SellerHistoryReport
        {
            [DisplayName("Name")]
            public string Name { get; set; }

            [DisplayName("Total Sold")]
            public string total_sold { get; set; }

            [DisplayName("Average Purchase Price")]
            public String average_purchase_price { get; set; }

            [DisplayName("Average # of Parts")]
            public String avg_num_parts { get; set; }

            [DisplayName("Average Part Cost")]
            public String avg_part_cost { get; set; }
        }
    }
}
