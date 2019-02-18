using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentComparing_Console
{
    internal static class ExtensionClass
    {

        public static void PrintElements(this object[] Array, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (var a in Array)
                Console.WriteLine(a);
            Console.ResetColor();
        }
    }
}
