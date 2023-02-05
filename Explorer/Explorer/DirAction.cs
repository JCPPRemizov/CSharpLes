using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    public static class DirAction
    {
        private static int currentFiles = 0;
        private static int posY = 0;
        private static int filesCount;
        private static int curWindow = 0;
        private static int curPosY;
        private static List<string> allFiles = new List<string>();
        private static bool wasExecuted = false;
        private static void FilesOut()
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(allFiles[curPosY]);
                filesCount = dir.GetDirectories().Length + dir.GetFiles().Length;
                if (currentFiles < filesCount)
                {
                    allFiles.Clear();
                    foreach (var file in dir.GetDirectories())
                    {
                        Console.WriteLine("  " + file.Name);
                        allFiles.Add(file.FullName);
                        currentFiles++;
                    }
                    foreach(var file in dir.GetFiles())
                    {
                        Console.WriteLine("  " + file.Name);
                        allFiles.Add(file.FullName);
                        currentFiles++;
                    }
                }
                else if ()
            }
            catch { }
            if (!wasExecuted)
            {
                SetCursor(0);
                Console.Write("->");
                wasExecuted = true;
            }
            FilesChoise();
        }
        public static void WinOut()
        {
            if(curWindow == 0)
            {
                DriveOut();
            }
            else
            {
                FilesOut();
            }
        }
       
        public static void DriveOut()
        {
            filesCount = DriveInfo.GetDrives().Length;
            if (currentFiles < filesCount)
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    Console.WriteLine("  " + drive + "  " + (drive.TotalFreeSpace / 1024) / 1024 / 1024 + " ГБ" + " свободно из " + (drive.TotalSize / 1024) / 1024 / 1024 + " ГБ");
                    allFiles.Add(drive.Name);
                    currentFiles++;
                }
            }
            if (!wasExecuted)
            {
                SetCursor(0);
                Console.Write("->");
                wasExecuted = true;
            }
            FilesChoise();
        }
    }
}
