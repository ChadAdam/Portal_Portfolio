using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurdellsRamblinWrecks.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            this.AcceptButton = btLoginAttempt;
        }

        private void btLoginAttempt_Click(object sender, EventArgs e)
        {
            BurdellsRamblinWrecks.Tasks.Login.GetLoginTask().LoginUser(tbUsername.Text, tbPassword.Text);
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
