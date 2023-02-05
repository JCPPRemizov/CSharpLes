using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingTest
{
    public static class PlayerTable
    {
        public static void TableOut()
        {
            Console.Clear();
            foreach(var item in PlayerInfo.players)
            {
                Console.WriteLine($"Имя: {item.name}\tСимволы в секунду: {item.SPS}\tСимволы в минуту: {item.SPM}");
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(true);
            Console.Clear();
        }

    }
}
