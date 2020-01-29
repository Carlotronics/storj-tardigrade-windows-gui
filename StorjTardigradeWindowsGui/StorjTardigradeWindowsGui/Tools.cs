using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorjTardigradeWindowsGui
{
    public static class Tools
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
            if (key != null)
            {
                Program.UplinkCLIPath = (string)key.GetValue("UplinkCLIPath");
                if (key.GetValue("filePrompt-lastPath") != null)
                    DialogBox.lastPath = (string)key.GetValue("filePrompt-lastPath");

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
            return s.Length > sep.Length ? s.Substring(0, s.Length - sep.Length) : s;
        }

        internal static string FormatSize(long size)
        {
            double len = (double)size;
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }

            string result = String.Format("{0:0.##} {1}", len, sizes[order]);
            return result;
        }

        internal static string FormatBucketName(string name)
        {
            return "sj://" + name + "/";
        }

        internal static string JoinArrayBetweenIndexes(string[] arr, int beg, int end=-1)
        {
            if (end == -1)
                end = arr.Length;
            int len = end - beg;
            string[] _arr = new string[len];

            for (var i = 0; i < len; ++i)
                _arr[i] = arr[beg + i];

            return String.Join(" ", _arr);
        }

        internal static string SubString(string str, int beg, int end)
        {
            if (end < 0)
                end = (str.Length + end) % str.Length;
            
            string final = "";
            for (int i = beg; i < end; ++i)
                final += "" + str[i];

            return final;
        }

        internal static string RemoveBucketNameFromPath(string path)
        {
            int beginIndex = 3;
            string[] parts = path.Split('/');
            string[] usefulParts = new string[parts.Length - beginIndex];
            for (int i = 0; i < parts.Length - beginIndex; ++i)
                usefulParts[i] = parts[i + beginIndex];
            return String.Join("/", usefulParts);
        }
    }
}
