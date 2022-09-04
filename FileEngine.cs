using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twiist
{
    internal class FileEngine
    {
        static string destination_parent = @"D:/";

        public static string CreateFolder()
        {
            Console.Write("Provide a name for your desired folder: ");
            string folder_name = Console.ReadLine();
            while (string.IsNullOrEmpty(folder_name))
            {
                folder_name = Console.ReadLine();
            }
            Directory.CreateDirectory(Path.Combine(destination_parent, folder_name));
            Console.Clear();
            return folder_name;
        }

        public static void CopyFiles(string folder_name, string[] files, DateTime recent_date)
        {
            GUI gui = new GUI();
            string destination_folder = Path.Combine(destination_parent, folder_name);
            var totalSize = GetTotalFileSize(files, recent_date);
            float processed = 0;
            foreach (string f in files)
            {
                if (File.GetCreationTime(f).Date == recent_date)
                {
                    processed += new FileInfo(f).Length / 1024 / 1024;
                    Console.SetCursorPosition(0, 2);
                    Console.Write(Math.Round(processed, 2) + "/" + totalSize + "MB");
                    Console.SetCursorPosition(0, 1);
                    gui.ProgressBar(totalSize, processed);
                    File.Copy(f, (destination_folder + "/" + Path.GetFileName(f)), true);
                }
            }
            Console.SetCursorPosition(0, 2);
            Console.WriteLine(totalSize + "/" + totalSize + "MB");
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("DONE!");
        }

        public static float GetTotalFileSize(string[] files, DateTime recent_date)
        {
            long s = 0;
            foreach(string f in files)
            {
                if (File.GetCreationTime(f).Date == recent_date)
                {
                    s += new FileInfo(f).Length;
                }
            }
            return s / 1024/ 1024;
        }
    }
}
