using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    public static class DirOut
    {
        public static List<string> allFiles = new List<string>();
        private static int DriveCount = 0;
        private static void Lines()
        {
            for (int i = 0; i < 120; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("");
        }

        public static void Dir_Out()
        {
            Console.Clear();
            while (true)
            {
                if (allFiles.Count == 0)
                {
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("Этот компьютер");
                    Lines();
                    foreach (var drive in DriveInfo.GetDrives())
                    {
                        allFiles.Add(drive.Name);
                        Console.WriteLine($"  {drive.Name} {drive.TotalFreeSpace / 1024 / 1024 / 1024}.ГБ доступно из {drive.TotalSize / 1024 / 1024 / 1024}.ГБ");
                        DriveCount++;
                    }
                }
                DirAction.FilesChoise();
            }
       }
        public static void FilesNextOut(int curPosY, string parentDir)
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"Родительский каталог: {parentDir}");
                Lines();
                DirectoryInfo dir = new DirectoryInfo(allFiles[curPosY]);
                allFiles.Clear();
                foreach (var file in dir.GetDirectories())
                {
                    Console.WriteLine("  " + file.Name);
                    allFiles.Add(file.FullName);
                }
                Console.WriteLine(allFiles.Count);
                int i = 2;
                foreach (var file in dir.GetDirectories())
                {
                    Console.SetCursorPosition(80, i);
                    Console.WriteLine(file.CreationTime);
                    i++;
                }
                foreach (var file in dir.GetFiles())
                {
                    Console.WriteLine("  " + file.Name);
                    allFiles.Add(file.FullName);
                }
                foreach (var file in dir.GetFiles())
                {
                    Console.SetCursorPosition(80, i);
                    Console.WriteLine(file.CreationTime);
                    i++;
                }
                DirAction.FilesChoise();
            }
            catch { }
        }
        public static void FilesOut(string parentDir)
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"Родительский каталог: {parentDir}");
                Lines();
                DirectoryInfo dir = new DirectoryInfo(parentDir);
                allFiles.Clear();
                foreach (var file in dir.GetDirectories())
                {
                    Console.WriteLine("  " + file.Name);
                    allFiles.Add(file.FullName);
                }
                int i = 2;
                foreach (var file in dir.GetDirectories())
                {
                    Console.SetCursorPosition(80, i);
                    Console.WriteLine(file.CreationTime);
                    i++;
                }
                foreach (var file in dir.GetFiles())
                {
                    Console.WriteLine("  " + file.Name);
                    allFiles.Add(file.FullName);
                }
                foreach (var file in dir.GetFiles())
                {
                    Console.SetCursorPosition(80, i);
                    Console.WriteLine(file.CreationTime);
                    i++;
                }
                DirAction.FilesChoise();
            }
            catch { }
        }
        
    }
}
