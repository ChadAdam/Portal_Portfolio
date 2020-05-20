using BurdellsRamblinWrecks.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurdellsRamblinWrecks.Entities
{
    public class Customer
    {
        [DisplayName("Phone #")]
        public string phone_number { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Street")]
        public string address_street { get; set; }

        [DisplayName("City")]
        public string address_city { get; set; }

        [DisplayName("State")]
        public string address_state { get; set; }

        [DisplayName("Postal Code")]
        public string address_postal_code { get; set; }

        [System.ComponentModel.Browsable(false)]
        public string customerID { get; set; }

        [System.ComponentModel.Browsable(false)]
        public bool IsBusiness { get; set; }

        // Individual 

        [DisplayName("Driver's License #")]
        public string drivers_license_number { get; set; }

        [DisplayName("First")]
        public string first_name { get; set; }

        [DisplayName("Last")]
        public string last_name { get; set; }


        // Business
        [DisplayName("Tax ID #")]
        public string tax_identification_number { get; set; }

        [DisplayName("Business Name")]
        public string business_name { get; set; }

        [DisplayName("Primary Contact Title")]
        public string primary_contact_title { get; set; }

        [DisplayName("Primary Contact First")]
        public string primary_contact_first_name { get; set; }

        [DisplayName("Primary Contact Last")]
        public string primary_contact_last_name { get; set; }     


    }
}




//public static bool IsBusSubclass(AddCustomers c)
//{
   // bool IsBus = c.IsradiobtnIndivChecked();
    //bool IsIndiv = c.IsradiobtnBusChecked();
   // return IsBus;
//}
