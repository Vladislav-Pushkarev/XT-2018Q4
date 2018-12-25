using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem5
{
    class Program
    {
        static void Main(string[] args)
        {
            long t = DateTime.Now.Millisecond;
            Logger.CreateLogFile();
            Console.WriteLine("Enter directory to watch.");
            string targetPath = Console.ReadLine();
            try
            {
                Backupper.CopyAll(@targetPath);
                Watcher.RunWatch(@targetPath);


                Console.WriteLine("Enter Date and Time of recovery.");
                string s = Console.ReadLine();
                s = Console.ReadLine();
                long parsed = long.Parse(s);
                long recovTime = parsed;
                Backupper.Restore(recovTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }
    }
}
