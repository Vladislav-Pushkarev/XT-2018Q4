using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.Task6.BackupSystem5
{
    public class Backupper
    {
        public static string defaultBackupPath = Path.Combine(Directory.GetCurrentDirectory(), "DefaultBackup");
        public static string BackupPath = Path.Combine(Directory.GetCurrentDirectory(), "FilesBackup");
        public static Dictionary<string, string> files = new Dictionary<string, string>();
        public static string targetPath;

        public static void PrepareToWork()
        {
            Console.WriteLine("Preparing...");
            if (Directory.Exists(defaultBackupPath))
            {
                Directory.Delete(defaultBackupPath, true);
                Directory.CreateDirectory(defaultBackupPath);
            }

            if (Directory.Exists(BackupPath))
            {
                Directory.Delete(BackupPath, true);
                Directory.CreateDirectory(BackupPath);
            }

            if (File.Exists(Logger.fullPath))
            {
                File.Delete(Logger.fullPath);
            }
        }

        public static void Restore(long recovTime)
        {
            string name;
            string backuppedName;
            string status;
            using (StreamReader file = new StreamReader(Logger.fullPath))
            {
                while ((status = file.ReadLine()) != null) //1
                {
                    if (long.Parse(status) <= recovTime)
                    {
                        name = file.ReadLine();//2
                        backuppedName = file.ReadLine();//3
                        status = file.ReadLine();//4
                        if (files.ContainsKey(name))
                        {
                            files[name] = backuppedName;
                        }

                        else
                        {
                            files.Add(name, backuppedName);
                        }
                        
                        if (status == "Renamed")
                        {

                            if (files.ContainsKey(backuppedName))
                            {
                                files[backuppedName] = name;
                            }
                            else
                            {
                                files.Add(backuppedName, name);
                            }
                            files.Remove(name);
                        }
                        file.ReadLine();// можно убрать если убрать разделительный астериск в логе
                    }
                    else 
                    {
                        break;
                    }

                }
            }
            
            DeleteFiles();
            CopyFromBackup();
        }

        public static void CopyFromBackup()
        {
            foreach(var pair in files)
            {
                string directoryPath = Path.GetDirectoryName(pair.Key);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                File.Copy(pair.Value, pair.Key, true);
            }
        }

        public static void DeleteFiles()
        {
            foreach (var pair in files.Where(pair2 => pair2.Value == "deleted").ToList())
            {
                files.Remove(pair.Key);
            }
        }

        public static void EventHandle(string fullPath, long time)
        {
            //string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            string newFileName = CreateFileName(time);
            BackupFile(fullPath, newFileName);
            Logger.Log($"{time}{Environment.NewLine}{fullPath}{Environment.NewLine}{newFileName}" +
                $"{Environment.NewLine}notRenamed{Environment.NewLine}*");
        }

        public static void DeleteEventHandle(FileSystemEventArgs e)
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            Logger.Log($"{time}{Environment.NewLine}{e.FullPath}{Environment.NewLine}deleted" +
                $"{Environment.NewLine}notRenamed{Environment.NewLine}*");
        }

        public static void RenameEventHandle(RenamedEventArgs e)
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            Logger.Log($"{time}{Environment.NewLine}{e.OldFullPath}{Environment.NewLine}{e.FullPath}" +
                $"{Environment.NewLine}Renamed{Environment.NewLine}*");
        }

        public static string CreateFileName(long time)
        {
            string fileName = $"{time}{Guid.NewGuid()}.txt";
            fileName = Path.Combine(BackupPath, fileName);
            return fileName;
        }

        public static void CopyAll(string fromPath)
        {
            foreach (string directoryPath in Directory.GetDirectories(fromPath, "*",
                    SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(directoryPath.Replace(fromPath, defaultBackupPath));
            }

            foreach (string FileDirectory in Directory.GetFiles(fromPath, "*.*",
                    SearchOption.AllDirectories))
            {
                string backuppedFile = FileDirectory.Replace(fromPath, defaultBackupPath);
                files.Add(FileDirectory, backuppedFile);
                File.Copy(FileDirectory, backuppedFile, true);
            }
                
        }

        public static void BackupFile(string fullFileName,string newFileName)
        {
                if (!Directory.Exists(BackupPath))
                {
                    Directory.CreateDirectory(BackupPath);
                }
                File.Copy(fullFileName, newFileName, true);
        }


    }
}
