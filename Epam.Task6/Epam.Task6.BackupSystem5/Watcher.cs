using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem5
{
    class Watcher
    {
        private static FileSystemWatcher watcher;
        private static bool work = false;
        private static string last;
        //private static Dictionary<DateTime, string> eventBuffer = 
        // new Dictionary<DateTime, string>();
        private volatile static List<long> timeList = new List<long>();
        private volatile static List<string> pathList = new List<string>();
        private static bool isInterrupted = false;
        private static int defaultDelay = 15;
        private static int summPeriod = defaultDelay;

        private static void RunAndSumm()
        {
            string fullPath;
            while (!isInterrupted)
            {
                Thread.Sleep(summPeriod);
                //last = pathList.Count;
                if (pathList.Count > 1)
                {
                    fullPath = pathList[0];
                    if (!fullPath.Equals(pathList[1]))
                    {
                        long time = timeList[0];
                        timeList.RemoveAt(0);
                        pathList.RemoveAt(0);
                        Backupper.EventHandle(fullPath, time);
                     //   if (timeList[0] + 15 > timeList[1])
                    //    {
                     //   }
                    }
                    else if (timeList[1] - 15 < timeList[0])
                    {
                        timeList.RemoveAt(0);
                        pathList.RemoveAt(0);
                    }

                }
                else if (pathList.Count == 1)
                {
                    fullPath = pathList[0];
                    long time = timeList[0];
                    timeList.RemoveAt(0);
                    pathList.RemoveAt(0);
                    Backupper.EventHandle(fullPath, time);
                }
                if (pathList.Count > 5)
                {
                    summPeriod = 0;
                }
                else
                {
                    summPeriod = defaultDelay;
                }
            }
        }



        public static void RunWatch(string path)
        {
            watcher = new FileSystemWatcher();
            watcher.InternalBufferSize = 64000;
            watcher.IncludeSubdirectories = true;
            watcher.Path = path;
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter = NotifyFilters.LastWrite
            | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.txt";

            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            Console.WriteLine("Press \'q\' to quit.");
            Thread thread = new Thread(() => RunAndSumm());
            thread.Start();
            while (Console.Read() != 'q');
            watcher.EnableRaisingEvents = false;
            summPeriod = 0;
            while (pathList.Count != 0)
            {
                Thread.Sleep(5);
            }
            isInterrupted = true;
        }

        static void OnCreated(object source, FileSystemEventArgs e)
        {
            string fullPath = e.FullPath;
            long time = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            timeList.Add(time);
            pathList.Add(fullPath);
            Console.WriteLine("***Created***");
        }

        static void OnDeleted(object source, FileSystemEventArgs e)
        {
            Backupper.DeleteEventHandle(e);
            Console.WriteLine("***Deleted***");
        }

        static void OnChanged(object source, FileSystemEventArgs e)
        {
            string fullPath = e.FullPath;
            long time = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            timeList.Add(time);
            pathList.Add(fullPath);
            Console.WriteLine("***Changed***");
        }

        static void OnRenamed(object source, RenamedEventArgs e)
        {
            Backupper.RenameEventHandle(e);
            Console.WriteLine("***Renamed***");
        }
    }
}
