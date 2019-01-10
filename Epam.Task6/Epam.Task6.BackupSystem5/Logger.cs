using System;
using System.IO;

namespace Epam.Task6.BackupSystem5
{
    public class Logger
    {
        private static FileInfo log1;
        private static string name = "logs.txt";
        private static string path = Directory.GetCurrentDirectory();
        private static string fullPath = System.IO.Path.Combine(Path, Name);

        public static FileInfo Log1 { get => log1; set => log1 = value; }

        public static string Name { get => name; set => name = value; }

        public static string Path { get => path; set => path = value; }

        public static string FullPath { get => fullPath; set => fullPath = value; }

        public static void CreateLogFile()
        {
            Log1 = new FileInfo(FullPath);
                Log1.Create().Close();
        }

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FullPath, true))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
