using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twiist
{
    internal class SearchEngine
    {
        private static DriveInfo[] drives = DriveInfo.GetDrives();

        public string DetectDrive()
        {
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady == true && drive.VolumeLabel == "NIKON")
                {
                    return drive.Name;
                }
            }
            throw new ArgumentException("No ready drive labeled as NIKON detected!");
        }

        public string[] FindFiles(string drive)
        {
            return Directory.GetFiles(drive, "*.NEF", SearchOption.AllDirectories);
        }

        public DateTime RecentDate(string[] files)
        {
            List<DateTime> dates = new();
            foreach (string file in files)
            {
                dates.Add(File.GetCreationTime(file).Date);
            }
            return dates.Max();
        }

    }
}
