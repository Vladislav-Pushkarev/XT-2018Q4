using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Epam.Task6.BackupSystem5
{
    public class Watcher
    {
        private static FileSystemWatcher watcher;
        private static bool work = false;
        private static string last;
        private static volatile List<long> timeList = new List<long>();
        private static volatile List<string> pathList = new List<string>();
        private static bool isInterrupted = false;
        private static int defaultDelay = 15;
        private static int summPeriod = defaultDelay;
        private static bool stopped = false;

        public static bool Stopped { get => stopped; set => stopped = value; }

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

            Console.WriteLine("Tracking...");

            Thread thread = new Thread(() => RunAndSumm());
            thread.Start();
            Form3 f = new Form3();
            f.ShowDialog();
            while (!Stopped)
            {
            }

            Console.WriteLine("Tracking stopped.");
            watcher.EnableRaisingEvents = false;
            summPeriod = 0;
            while (pathList.Count != 0)
            {
                Thread.Sleep(5);
            }

            isInterrupted = true;
        }

        private static void RunAndSumm()
        {
            string fullPath;
            while (!isInterrupted)
            {
                Thread.Sleep(summPeriod);
                if (pathList.Count > 1)
                {
                    fullPath = pathList[0];
                    if (!fullPath.Equals(pathList[1]))
                    {
                        long time = timeList[0];
                        timeList.RemoveAt(0);
                        pathList.RemoveAt(0);
                        Backupper.EventHandle(fullPath, time);
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

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            string fullPath = e.FullPath;
            long time = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            timeList.Add(time);
            pathList.Add(fullPath);
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            Backupper.DeleteEventHandle(e);
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            string fullPath = e.FullPath;
            long time = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            timeList.Add(time);
            pathList.Add(fullPath);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Backupper.RenameEventHandle(e);
        }
    }
}
