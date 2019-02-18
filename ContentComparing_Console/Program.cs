using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ContentComparing_Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            int resultPad = 5;
            start:
            Console.WriteLine("Press any key to choose folders...");
            Console.ReadKey();
            string directory1 = GetPath();
            Console.Clear();
            Console.WriteLine("Choose the second folder.");
            string directory2 = GetPath();
            Console.Clear();
            if (directory1 == null || directory2 == null)
                goto start;
            string[] fileNames1 = Directory.GetFiles(directory1).Select(x => x.Replace(directory1 + "\\", string.Empty)).ToArray(),
            fileNames2 = Directory.GetFiles(directory2).Select(x => x.Replace(directory2 + "\\", string.Empty)).ToArray(),
            matchedElements = fileNames1.Intersect(fileNames2).ToArray();
            Console.WriteLine($"{directory1}:{fileNames1.Length.ToString().PadLeft(resultPad)} files found.");
            Console.WriteLine($"{directory2}:{fileNames2.Length.ToString().PadLeft(resultPad)} files found.\n");

            if (matchedElements.Length != 0)
            {
                Console.Write($"Matched elements Found:");
                ColorWrite($"{matchedElements.Length}\n".PadLeft(resultPad), ConsoleColor.Green);
            }
            if (fileNames1.Length != matchedElements.Length)
            {
                Console.Write($"Mismatched elements from {directory1.Replace(directory1.Substring(0, directory1.LastIndexOf("\\")), string.Empty)}:");
                ColorWrite($"{fileNames1.Except(fileNames2).Count()}\n".PadLeft(resultPad), ConsoleColor.Red);
            }
            if (fileNames2.Length != matchedElements.Length)
            {
                Console.Write($"Mismatched elements from {directory2.Replace(directory2.Substring(0, directory2.LastIndexOf("\\")), string.Empty)}:");
                ColorWrite($"{fileNames2.Except(fileNames1).Count()}\n".PadLeft(resultPad), ConsoleColor.Red);
            }

            Console.ReadKey();
        }

        private static void ColorWrite(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private static string GetPath()
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            if (folderDialog.ShowDialog() == DialogResult.OK)
                return folderDialog.SelectedPath;
            return null;
        }
    }
}
