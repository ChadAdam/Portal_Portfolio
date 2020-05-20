using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BurdellsRamblinWrecks.Global_Modules.GlobalFunctions;

namespace BurdellsRamblinWrecks
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Log("Burdells Ramblin Wrecks Starting...", entLogTypes.eNote);
            Application.Run(new Forms.VehicleSearch());
            //Application.Run(new Forms.SearchCustomer());
        }
    }
}
