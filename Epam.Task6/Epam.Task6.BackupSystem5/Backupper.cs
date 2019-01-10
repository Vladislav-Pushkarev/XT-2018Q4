using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.Task6.BackupSystem5
{
    public class Backupper
    {
        private static string defaultBackupPath = Path.Combine(Directory.GetCurrentDirectory(), "DefaultBackup");
        private static string backupPath = Path.Combine(Directory.GetCurrentDirectory(), "FilesBackup");
        private static Dictionary<string, string> files = new Dictionary<string, string>();
        private static string targetPath;

        public static string DefaultBackupPath { get => defaultBackupPath; set => defaultBackupPath = value; }

        public static string BackupPath { get => backupPath; set => backupPath = value; }

        public static Dictionary<string, string> Files { get => files; set => files = value; }

        public static string TargetPath { get => targetPath; set => targetPath = value; }

        public static void PrepareToWork()
        {
            Console.WriteLine("Preparing...");
            if (Directory.Exists(DefaultBackupPath))
            {
                Directory.Delete(DefaultBackupPath, true);
                Directory.CreateDirectory(DefaultBackupPath);
            }

            if (Directory.Exists(BackupPath))
            {
                Directory.Delete(BackupPath, true);
                Directory.CreateDirectory(BackupPath);
            }

            if (File.Exists(Logger.FullPath))
            {
                File.Delete(Logger.FullPath);
            }
        }

        public static void Restore(long recovTime)
        {
            string name;
            string backuppedName;
            string status;
            using (StreamReader file = new StreamReader(Logger.FullPath))
            {
                while ((status = file.ReadLine()) != null)
                {
                    if (long.Parse(status) <= recovTime)
                    {
                        name = file.ReadLine();
                        backuppedName = file.ReadLine();
                        status = file.ReadLine();
                        if (Files.ContainsKey(name))
                        {
                            Files[name] = backuppedName;
                        }
                        else
                        {
                            Files.Add(name, backuppedName);
                        }

                        if (status == "Renamed")
                        {
                            if (Files.ContainsKey(backuppedName))
                            {
                                Files[backuppedName] = name;
                            }
                            else
                            {
                                Files.Add(backuppedName, name);
                            }

                            Files.Remove(name);
                        }

                        file.ReadLine();
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
            foreach (var pair in Files)
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
            foreach (var pair in Files.Where(pair2 => pair2.Value == "deleted").ToList())
            {
                Files.Remove(pair.Key);
            }
        }

        public static void EventHandle(string fullPath, long time)
        {
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
            foreach (string directoryPath in Directory.GetDirectories(fromPath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(directoryPath.Replace(fromPath, DefaultBackupPath));
            }

            foreach (string fileDirectory in Directory.GetFiles(fromPath, "*.*", SearchOption.AllDirectories))
            {
                string backuppedFile = fileDirectory.Replace(fromPath, DefaultBackupPath);
                Files.Add(fileDirectory, backuppedFile);
                File.Copy(fileDirectory, backuppedFile, true);
            }
        }

        public static void BackupFile(string fullFileName, string newFileName)
        {
            if (!Directory.Exists(BackupPath))
            {
                Directory.CreateDirectory(BackupPath);
            }

            File.Copy(fullFileName, newFileName, true);
        }
    }
}