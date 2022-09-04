namespace twiist
{
    internal class Program
    {

        static void Main()
        {
            //drive manipulation, searching for files and searching for most recent date
            SearchEngine SE = new SearchEngine();
            string drive = SE.DetectDrive();
            string[] files = SE.FindFiles(drive);
            DateTime recent_date = SE.RecentDate(files);

            //file manipulation
            string folder = FileEngine.CreateFolder();

            Console.WriteLine("Recent Date found: " + recent_date);

            FileEngine.CopyFiles(folder, files, recent_date);
        }
    }
}