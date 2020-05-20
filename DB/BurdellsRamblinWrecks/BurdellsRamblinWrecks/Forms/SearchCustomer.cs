using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BurdellsRamblinWrecks.Entities;
using BurdellsRamblinWrecks.Tasks;


namespace BurdellsRamblinWrecks.Forms
{
    public partial class SearchCustomer : Form
    {
        protected List<Customer> CustomerResults = null;
        public SearchCustomer()
        {
            InitializeComponent();

            InitialDisplay();
        }

        public void InitialDisplay()
        {

            this.txtbxID.Text = "Insert Driver Licence";
            this.txtbxName.Text = "Insert First Name Here";
            this.txtbxNamelast.Text = "Insert Last Name Here";
            this.radiobtnBus.Checked = true;
            
            txtbxID.ForeColor = Color.Gray;
            txtbxName.ForeColor = Color.Gray;
            txtbxNamelast.ForeColor = Color.Gray;
            // Business Attributes
            //this.txtbxContact.Visible = false;
            //this.txtbxTitle.Visible = false;
            //this.lblContact.Visible = false;
           // this.lblTitle.Visible = false;
           // this.txtbxIDBus.Visible = false;
           // this.lblIDBus.Visible = false;
           // this.txtbxNameBus.Visible = false;
            //this.lblNameBus.Visible = false;
            //this.txtbxNamelastBus.Visible = false;
           // this.lblNamelastBus.Visible = false;

            //var searchTask = new Tasks.SearchForCustomers();
        }
       // private void AddCustomers_Load(object sender, EventArgs e)
       // {
           
      //  }

        private void radiobtnIndiv_CheckedChanged(object sender, EventArgs e)
        {
           
            if (radiobtnIndiv.Checked) { 
            txtbxID.Text = "Insert Driver Licence";
            
            // Business Attributes
            txtbxContact.Visible = false;
            txtbxTitle.Visible = false;
            lblContact.Visible = false;
            lblTitle.Visible = false;
            txtbxIDBus.Visible = false;
            lblIDBus.Visible = false;
            txtbxNameBus.Visible = false;
            lblNameBus.Visible = false;
            txtbxNamelastBus.Visible = false;
            lblNamelastBus.Visible = false;
                // Individual Attributes
            txtbxID.Visible = true;
            lblID.Visible = true;
            txtbxName.Visible = true;
            lblName.Visible = true;
            txtbxNamelast.Visible = true;
            lblNamelast.Visible = true;


            }
        }
        public bool IsradiobtnBusChecked()
        {
            //RadioButton radiobtnBus = new RadioButton();
            return radiobtnBus.Checked;
        }

        public bool IsradiobtnIndivChecked()
        {
            //RadioButton radiobtnIndiv = new RadioButton();
            return radiobtnIndiv.Checked;
        }

        private void radiobtnBus_CheckedChanged(object sender, EventArgs e)
        {
           
            if (radiobtnBus.Checked)
            {
               
                txtbxIDBus.Text = "Insert Tax Identification Number";
                txtbxNameBus.Text = "Insert Contact First Name";
                txtbxNamelastBus.Text = "Instert Contact Last Name";
                txtbxIDBus.ForeColor = Color.Gray;
                txtbxNamelastBus.ForeColor = Color.Gray;
                txtbxNameBus.ForeColor = Color.Gray;
                // Business Attributes
                txtbxContact.Visible = true;
                txtbxTitle.Visible = true;
                lblContact.Visible = true;
                lblTitle.Visible = true;
                txtbxContact.Visible = true;
                txtbxTitle.Visible = true;
                lblContact.Visible = true;
                lblTitle.Visible = true;
                txtbxIDBus.Visible = true;
                lblIDBus.Visible = true;
                txtbxNameBus.Visible = true;
                lblNameBus.Visible = true;
                txtbxNamelastBus.Visible = true;
                lblNamelastBus.Visible = true;
                // Individual Attributes
                txtbxID.Visible = false;
                lblID.Visible = false;
                txtbxName.Visible = false;
                lblName.Visible = false;
                txtbxNamelast.Visible = false;
                lblNamelast.Visible = false;

            }
            
        }

        private void txtbxID_TextChanged(object sender, EventArgs e)
        {
            this.txtbxID.GotFocus += new EventHandler(txtbxID_Focus);
        }
        protected void txtbxID_Focus(Object sender, EventArgs e)
        {
            txtbxID.Text = "";
            txtbxID.ForeColor = Color.Black;
        }

        protected void txtbxIDBus_Focus(Object sender, EventArgs e)
        {
            txtbxIDBus.Text = "";
            txtbxIDBus.ForeColor = Color.Black;
        }

        protected void txtbxName_Focus(Object sender, EventArgs e)
        {
            txtbxName.Text = "";
            txtbxName.ForeColor = Color.Black;
        }

        protected void txtbxNameBus_Focus(Object sender, EventArgs e)
        {
            txtbxNameBus.Text = "";
            txtbxNameBus.ForeColor = Color.Black;
        }

        protected void txtbxNamelast_Focus(Object sender, EventArgs e)
        {
            txtbxNamelast.Text = "";
            txtbxNamelast.ForeColor = Color.Black;
        }

        protected void txtbxNamelastBus_Focus(Object sender, EventArgs e)
        {
            txtbxNamelastBus.Text = "";
            txtbxNamelastBus.ForeColor = Color.Black;
        }
        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click_1(object sender, EventArgs e)
        {

        }

        private void txtbxContact_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtbxTitle_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lblContact_Click(object sender, EventArgs e)
        {
           
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            var searchTask = new Tasks.SearchForCustomers();
            this.CustomerResults = searchTask.Search( txtbxPhoneNum.Text, txtbxEmail.Text
                , txtbxStreet.Text
                , txtbxState.Text
                , txtbxPostal.Text, txtbxCity.Text, txtbxTitle.Text ,  txtbxID.Text, txtbxIDBus.Text, txtbxNameBus.Text, txtbxNamelastBus.Text, txtbxName.Text,txtbxNamelast.Text, this);

            searchTask.Search(txtbxPhoneNum.Text, txtbxEmail.Text, txtbxStreet.Text, txtbxState.Text, txtbxPostal.Text, txtbxCity.Text, txtbxIDBus.Text, txtbxNameBus.Text, txtbxTitle.Text, tbPrimary, primary_contact_last_name, drivers_license_number, first_name, last_name, individualSearch);
        }
       

        private void SearchCustomer_Load(object sender, EventArgs e)
        {

        }

        private void txtbxPhoneNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAdres_Click(object sender, EventArgs e)
        {

        }

        private void lblCity_Click(object sender, EventArgs e)
        {

        }

        private void txtbxCity_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lblPostal_Click(object sender, EventArgs e)
        {

        }

        private void txtbxNamelast_TextChanged(object sender, EventArgs e)
        {
            this.txtbxNamelast.GotFocus += new EventHandler(txtbxNamelast_Focus);
        }

        private void lblNamelast_Click(object sender, EventArgs e)
        {

        }

        private void lblNamelastBus_Click_1(object sender, EventArgs e)
        {

        }

        private void txtbxNamelastBus_TextChanged_3(object sender, EventArgs e)
        {
            this.txtbxNamelastBus.GotFocus += new EventHandler(txtbxNamelastBus_Focus);
        }

        private void lblIDBus_Click(object sender, EventArgs e)
        {

        }

        private void lblNameBus_Click(object sender, EventArgs e)
        {

        }

        private void lblPNumber_Click(object sender, EventArgs e)
        {

        }

        private void txtbxNameBus_TextChanged(object sender, EventArgs e)
        {
            this.txtbxNameBus.GotFocus += new EventHandler(txtbxNameBus_Focus);
        }

        private void txtbxName_TextChanged(object sender, EventArgs e)
        {
            this.txtbxName.GotFocus += new EventHandler(txtbxName_Focus);
        }

        private void txtbxIDBus_TextChanged(object sender, EventArgs e)
        {
            this.txtbxIDBus.GotFocus += new EventHandler(txtbxIDBus_Focus);
        }
    }
}
