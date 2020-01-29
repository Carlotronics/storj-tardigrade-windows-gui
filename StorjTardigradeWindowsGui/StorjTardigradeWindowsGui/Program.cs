using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorjTardigradeWindowsGui
{
    static class Program
    {
        public static CLIUplink cli;
        public static UplinkWrapper Uplink;
        public static string UplinkCLIPath = @"%userprofile%\storj-uplink\uplink_windows_amd64.exe";

        public static List<Dictionary<string, string>> Buckets = null;
        public static List<Dictionary<string, string>> BucketFiles = null;

        public static Item Root;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Console.OutputEncoding = System.Text.Encoding.UTF8;
            Root = new Root();

            Uplink = new UplinkWrapper();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Tools.LoadSettings();

            while(UplinkCLIPath == null || !System.IO.File.Exists(UplinkCLIPath))
            {
                if (DialogBox.Alert("Uplink CLI location", "Please select the Uplink CLI file in the following window.") == DialogResult.OK)
                {
                    UplinkCLIPath = DialogBox.FilePrompt("Uplink CLI Path", "Application files (*.exe)|*.exe|All files (*.*)|*.*");
                }
                else
                    System.Environment.Exit(2);
            }
            Tools.SaveSettings();

            cli = new CLIUplink(UplinkCLIPath);

            /*
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
            */

            Application.Run(new MainGUI());
        }
    }
}
