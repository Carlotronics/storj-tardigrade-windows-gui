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
            foreach (var _d in d)
            {
                foreach (var pair in _d)
                {
                    Console.WriteLine("\t" + pair.Key + " : " + pair.Value);
                }
            }
        }
    }
}
