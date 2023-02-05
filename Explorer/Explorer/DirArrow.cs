using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    public class DirArrow
    {
        private static int posY;
        private static int curPosY;
        private static void SetCursor(int y)
        {
            Console.SetCursorPosition(0, y);
        }
        private static void FilesChoise()
        {
            ConsoleKeyInfo userKey = Console.ReadKey(true);
            switch (userKey.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (posY > 0)
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
                        if (posY < allFiles.Count - 1)
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
                        curWindow = 1;
                        Console.Clear();
                        wasExecuted = false;
                        curPosY = posY;
                        posY = 0;
                        currentFiles = 0;
                        filesCount = 0;
                        FilesOut();
                        break;
                    }
            }
        }
    }
}
