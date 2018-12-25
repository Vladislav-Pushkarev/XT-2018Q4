using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem5
{
    class Logger
    {
        public static FileInfo log;
        public static string name = "logs.txt";
        public static string path = Directory.GetCurrentDirectory();
        public static string fullPath = Path.Combine(path, name);
        public static void CreateLogFile()
        {
            log = new FileInfo(fullPath);
                log.Create().Close();
                Console.WriteLine($"\tFile {name} was created.");
        }

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(message);
                }
                Console.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
