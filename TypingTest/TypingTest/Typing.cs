using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TypingTest
{
    public class Typing
    {
        private static int posY, posX, seconds = 15, maxLines;
        private static string text;
        private static bool start = false, wasExecuted = false, startTp = true;
        private static StringBuilder corStr = new StringBuilder();
        private static PlayerInfo player = new PlayerInfo();
        private static Stopwatch stopWatch = new Stopwatch();
        private static Thread thread = new Thread(_ =>
        {
            while (true)
            {
                if (corStr.Length != text.Length && seconds >= 0 && start)
                {
                    stopWatch.Start();
                    Console.SetCursorPosition(0, maxLines + 1);
                    Console.ResetColor();
                    Console.Write("Оставшееся время: " + seconds + " ");
                    Thread.Sleep(1000);
                    seconds--;
                }
                else if (seconds == 0 || corStr.Length == text.Length)
                {
                    stopWatch.Stop();
                    start = false;
                    startTp = false;
                    corStr.Clear();
                    maxLines = 0;
                    posX = 0;
                    posY = 0;
                    seconds = 15;

                }
            }
        });
        private static string TextOut()
        {
            while (true)
            {
                Console.Clear();
                string text = Serializer.LoadText();
                if (text == null)
                {
                    Console.WriteLine("Файл с текстом не найден!\nФайл был создан! Напишите в нем текст!");
                    while (true)
                    {
                        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        else { continue; }
                    }
                }
                else if (text == string.Empty)
                {
                    Console.WriteLine("Файл пустой!");
                    while (true)
                    {
                        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        else { continue; }
                    }
                }
                else
                {
                    return text;
                    break;
                }
            }
        }
        private static void UserKey(in char s)
        {
            while (true)
            {
                if (posX < Console.WindowWidth)
                {
                    Console.SetCursorPosition(posX, posY);
                }
                else
                {
                    posY++;
                    posX = 0;
                    continue;
                }
                if (Console.ReadKey(true).KeyChar == s && seconds > 0 && startTp)
                {
                    if (seconds > 0 && startTp)
                    {
                        start = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(posX, posY);
                        corStr.Append(s);
                        Console.Write("");
                        Console.Write(corStr[^1]);
                        posX++;
                        if (!wasExecuted)
                        {
                            thread.Start();
                            wasExecuted = true;
                        }
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private static void NewPlayer()
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            player.name = name;
            Console.Clear();
        }
        public static void TpTest()
        {
            startTp = true;
            NewPlayer();
            text = TextOut();
            for (int i = 0; i < text.Length; i++)
            {
                if ((i + 1) % Console.WindowWidth == 0)
                {
                    maxLines++;
                }
            }
            Console.WriteLine(text);
            foreach (var chr in text)
            {
                UserKey(chr);
            }
            TimeSpan ts = stopWatch.Elapsed;
            player.SPS = corStr.Length / (float)ts.Seconds;
            player.SPM = player.SPS * 60;
            PlayerInfo.players.Add(new PlayerInfo(player));
            Serializer.Serialize(PlayerInfo.players);
            PlayerTable.TableOut();
        }
    }
}
