using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorjTardigradeWindowsGui
{
    static class Program
    {
        public static CLIUplink cli;
        public static List<Dictionary<string, string>> Buckets = null;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            cli = new CLIUplink(@"C:\Users\Charles\storj-uplink");
            if (!cli.IsRegistered())
            {
                if(DialogBox.Alert("Log in to Tardigrade Network", "This client has to be used with Uplink CLI.\nPlease first login using your API token first.\n\nDetailled informations can be found at https://documentation.tardigrade.io/api-reference/uplink-cli.\n\n") == DialogResult.OK)
                {
                    cli.AuthenticateCLIUplink();
                    if(!cli.IsRegistered())
                        System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // For Form App
                    System.Windows.Forms.Application.Exit();
                    // For CLI app
                    // System.Environment.Exit(1);
                }
            }
            Application.Run(new MainGUI());
        }
    }
}
