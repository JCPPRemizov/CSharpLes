using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    internal class Program
    {

        static int[][] all_octav = new int[][]
        {
            new int []{ 130, 138, 146, 155, 164, 174, 185, 196, 207, 220, 233, 246},
            new int []{ 261, 277, 293, 311, 329, 349, 370, 392, 415, 440, 466, 493}
        };

        static int[] Change_Octav(ConsoleKeyInfo Key)
        {
            switch (Key.Key)
            {
                case ConsoleKey.F6:
                    {
                        return all_octav[0];
                    }
                case ConsoleKey.F7:
                    {
                        return all_octav[1];
                    }
                default: return all_octav[0];
            }
        }
        static void SoundOut(ConsoleKeyInfo Key)
        {
            int[] Octavv = Change_Octav(Key);
            switch (Key.Key)
            { //Реализация звука для белых клавиш
                case ConsoleKey.C:
                    {
                        Console.Beep(Octavv[0], 100);
                        break;
                    }
                case ConsoleKey.D:
                    {
                        Console.Beep(Octavv[2], 100);
                        break;
                    }
                case ConsoleKey.E:
                    {
                        Console.Beep(Octavv[4], 100);
                        break;
                    }
                case ConsoleKey.F:
                    {
                        Console.Beep(Octavv[5], 100);
                        break;
                    }
                case ConsoleKey.G:
                    {
                        Console.Beep(Octavv[7], 100);
                        break;

                    }
                case ConsoleKey.A:
                    {
                        Console.Beep(Octavv[9], 100);
                        Console.WriteLine("ddwwd");
                        break;
                    }
                case ConsoleKey.B:
                    {
                        Console.Beep(Octavv[11], 100);
                        break;
                    } // Реализация для черных клавиш
                case ConsoleKey.N:
                    {
                        Console.Beep(Octavv[1], 100);
                        break;
                    }
                case ConsoleKey.M:
                    {
                        Console.Beep(Octavv[3], 100);
                        break;
                    }
                case ConsoleKey.L:
                    {
                        Console.Beep(Octavv[6], 100);
                        break;
                    }
                case ConsoleKey.Q:
                    {
                        Console.Beep(Octavv[8], 100);
                        break;
                    }

                case ConsoleKey.W:
                    {
                        Console.Beep(Octavv[10], 100);
                        break;
                    }

            }

        }



        static void Main(string[] args)
        {

            Console.WriteLine("Нажмите клавишу для игры в пианино");
            while (true)
            {
                SoundOut(Console.ReadKey());
            }


































        }
    }
}
