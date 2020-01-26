using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorjTardigradeWindowsGui
{
    static class Tools
    {
        internal static void PrintListOfDict(List<Dictionary<string, string>> d)
        {
            Console.WriteLine("\t==============");
            foreach (var _d in d)
            {
                foreach (var pair in _d)
                {
                    Console.WriteLine("\t" + pair.Key + " : " + pair.Value);
                }
            }
            Console.WriteLine();
        }

        internal static bool LoadSettings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\StorjTardigradeWindowsGui");
            if(key != null)
            {
                Program.UplinkCLIPath = (string) key.GetValue("UplinkCLIPath");
                if(key.GetValue("filePrompt-lastPath") != null)
                    DialogBox.lastPath = (string) key.GetValue("filePrompt-lastPath");

                if (Program.UplinkCLIPath == null)
                    return false;
                return true;
            }

            return false;
        }

        internal static void SaveSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\StorjTardigradeWindowsGui");
            key.SetValue("UplinkCLIPath", Program.UplinkCLIPath);
            key.SetValue("filePrompt-lastPath", DialogBox.lastPath);
        }

        internal static string JoinList(string sep, List<string> list)
        {
            string s = "";
            foreach (var el in list)
                s += el + sep;
            return s.Length> sep.Length ? s.Substring(0, s.Length - sep.Length) : s;
        }
    }
}
