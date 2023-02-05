using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dir
{
    public class DirAction
    {
        private static int posY;
        private static int curPosY;
        private static string parentDir;
        private static string parentDirSub;
        private static bool curWindow = false;
        private static bool wasExecuted = false;
        private static void SetCursor(int y)
        {
            Console.SetCursorPosition(0, y);
        }
        private static void DirFilesOutCall()
        {
            wasExecuted = false;
            DirOut.FilesOut(parentDir);
        }
        private static void FileOutCall()
        {
            if (Directory.Exists(DirOut.allFiles[posY - 2]))
            {
                parentDir = DirOut.allFiles[posY - 2];
                parentDirSub = parentDir.Substring(0, parentDir.LastIndexOf("\\") + 1);
                curPosY = posY - 2;
                posY = 2;
                wasExecuted = false;
                DirOut.FilesNextOut(curPosY, parentDir);
            }
        }
        private static void BackKey()
        {
            parentDir = parentDirSub;
            DirOut.FilesOut(parentDirSub);
        }
        public static void FilesChoise()
        {
            if (wasExecuted == false && DirOut.allFiles.Count > 0)
            {
                posY = 2;
                SetCursor(posY);
                Console.WriteLine("->");
                wasExecuted = true;
            }
            while (true)
            {
                ConsoleKeyInfo userKey = Console.ReadKey(true);
                switch (userKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (posY > 2 && DirOut.allFiles.Count > 0)
                            {
                                SetCursor(posY);
                                Console.Write("  ");
                                posY--;
                                SetCursor(posY);
                                Console.Write("->");

                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (posY < DirOut.allFiles.Count + 1 && DirOut.allFiles.Count > 0)
                            {
                                SetCursor(posY);
                                Console.Write("  ");
                                posY++;
                                SetCursor(posY);
                                Console.Write("->");
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            curWindow = true;
                            if (DirOut.allFiles.Count > 0)
                            {
                                if (File.Exists(DirOut.allFiles[posY - 2]))
                                {
                                    try
                                    {
                                        Process.Start(new ProcessStartInfo { FileName = DirOut.allFiles[posY - 2], UseShellExecute = true });
                                    }
                                    catch { };

                                }
                                else
                                {
                                    FileOutCall();
                                }
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (curWindow == true)
                            {
                                foreach (var drive in DriveInfo.GetDrives())
                                {
                                    if (parentDir == drive.Name)
                                    {
                                        wasExecuted = false;
                                        posY = 2;
                                        DirOut.allFiles.Clear();
                                        DirOut.Dir_Out();
                                        break;
                                    }
                                }
                                BackKey();
                                FileOutCall();
                            }
                            break;
                        }
                    case ConsoleKey.F1:
                        {
                            MakeDir();
                            break;
                        }
                    case ConsoleKey.F2:
                        {
                            DelDirAndFile();
                            break;
                        }
                    case ConsoleKey.F3:
                        {
                            MakeFile();
                            break;
                        }
                }
                continue;
            }
        }
        private static void MakeDir()
        {
            if (curWindow == true)
            {
                try
                {
                    Console.SetCursorPosition(60, 0);
                    Console.Write("Введите название папки: ");
                    string name = Console.ReadLine();
                    Directory.CreateDirectory(parentDir + name);
                    DirFilesOutCall();
                }
                catch
                {
                    DirFilesOutCall();
                }

            }


        }
        private static void DelDirAndFile() 
        {
            if (curWindow == true)
            {
                if (Directory.Exists(DirOut.allFiles[posY - 2]))
                {
                    try
                    {
                        Directory.Delete(DirOut.allFiles[posY - 2],true);
                        DirFilesOutCall();
                    }
                    catch { DirFilesOutCall(); }
                }
                else if (File.Exists(DirOut.allFiles[posY-2]))
                {
                    try
                    {
                        File.Delete(DirOut.allFiles[posY - 2]);
                        DirFilesOutCall();
                    }
                    catch { DirFilesOutCall(); }
                }

            }
        }
        private static void MakeFile() 
        {
            if (curWindow == true)
            {
                try
                {
                    Console.SetCursorPosition(40, 0);
                    Console.Write("Введите название файла(с расширением (.txt,.json и т.д)): ");
                    Console.WriteLine(parentDir);
                    string name = Console.ReadLine();
                    var file = File.Create(parentDir + name);
                    file.Close();
                    DirFilesOutCall();
                }
                catch { DirFilesOutCall(); }

            }
        }


    }
}
