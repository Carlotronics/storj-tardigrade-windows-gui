using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorjTardigradeWindowsGui
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CLIUplink cli = new CLIUplink(@"C:\Users\Charles\storj-uplink");
            /*var d1 = cli.ListFilesInBucket("test");
            var d2 = cli.ListFilesInBucket("first-bucket");
            Tools.PrintListOfDict(d1);
            Tools.PrintListOfDict(d2);
            */
            Console.WriteLine(cli.CreateBucket("test"));
            Console.WriteLine(cli.DeleteBucket("test"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGUI());
        }
    }
}
