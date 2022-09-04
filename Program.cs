namespace twiist
{
    internal class Program
    {
        static DriveInfo[] drives = DriveInfo.GetDrives();
        static string[] files = { };
        static List<DateTime> dates = new List<DateTime>();
        static private DateTime recent_date;

        static string destination_parent = @"D:/";
        static string folder_name = @"Test";
        static string destination_folder = Path.Combine(destination_parent, folder_name);

        static void Main()
        {


            foreach (DriveInfo drive in drives)
            {
                if(drive.IsReady == true && drive.VolumeLabel == "NIKON")
                {
                    files = Directory.GetFiles(drive.Name, "*.NEF", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        dates.Add(File.GetCreationTime(file).Date);
                    }
                    recent_date = dates.Max();
                }
            }

            Console.WriteLine(recent_date);
            Directory.CreateDirectory(destination_folder);
            foreach(string f in files)
            {
                if(File.GetCreationTime(f).Date == recent_date)
                {
                    Console.WriteLine(f);
                    File.Copy(f, @"D://Test/" + Path.GetFileName(f), true);
                }
            }
        }
    }
}