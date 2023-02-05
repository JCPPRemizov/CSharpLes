namespace MultiApp
{
    internal class Program
    {
        static bool check(string CheckNumber, out int number)
        {

            try
            {
                int.Parse(CheckNumber);
                number = int.Parse(CheckNumber);
                return true;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка! Введите число!");
                Console.ResetColor();
                number = 0;
                return false;
            }

        }
        static void RandomGame()
        {
            Random rnd = new Random();
            long random_number = rnd.NextInt64(0, 100);
            int number = -1;
            while (number != random_number)
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Введите число(1-100): ");
                    Console.ResetColor();
                    string CheckNumber = Console.ReadLine();
                    if (check(CheckNumber, out number) == false)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (number == random_number)
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Поздравляю! Вы угадали число!");
                    Console.ResetColor();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы не угадали число!");
                    Console.ResetColor();
                }

            }
        }
        static void MulTable()
        {
            int[,] table =
            {
                {1,2,3,4,5,6,7,8,9,10},
                {1,2,3,4,5,6,7,8,9,10}
            };
            for (int i = 0; i < table.GetLength(1); i++)
            {
                int SecondColumn = table[0, i];
                for (int k = 0; k < table.GetLength(1); k++)
                {
                    int FirstColumn = table[1, k];
                    Console.Write(FirstColumn + "*" + SecondColumn + "=" + FirstColumn * SecondColumn + "\t");
                }
                Console.WriteLine();
            }
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nДля возврата в меню нажмите клавишу с буквой 'B'(eng)");
                Console.ResetColor();
                ConsoleKeyInfo user_key = Console.ReadKey(true);
                if (user_key.Key == ConsoleKey.B) { break; }
            }

        }
        static void DivNumber()
        {
            int number;
            int amount = 0;
            List<int> list = new List<int>();
            ConsoleKeyInfo user_key;
            while (true)
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Введите число: ");
                    Console.ResetColor();
                    string check_number = Console.ReadLine();
                    if (check(check_number, out number) == false) { continue; }
                    else { break; }
                }
                for (int i = 1; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        list.Add(number / i);
                        amount += 1;
                    }

                }
                Console.WriteLine($"Делители числа {number}: ");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(list[i]);
                    Console.ResetColor();
                }
                Console.WriteLine($"Всего делителей: {amount}");
                Console.WriteLine("Чтобы начать заново нажмите любую клавишу. Для возврата в меню нажмите клавишу с буквой - 'B'(eng)");
                user_key = Console.ReadKey(true);
                if (user_key.Key == ConsoleKey.B) { break; }

            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                int user_input;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Выберите программу: \n" +
                    "1.Игра 'Угадай число'\n" +
                    "2.Таблица умножения\n" +
                    "3.Вывод делителей числа\n" +
                    "Для выхода из основной программы введите цифру 4");
                Console.ResetColor();
                while (true)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Программа: ");
                        Console.ResetColor();
                        user_input = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка! Введите число!(1-4)");
                        Console.ResetColor();
                        continue;
                    }
                }
                switch (user_input)
                {
                    case 1:
                        RandomGame();
                        break;
                    case 2:
                        MulTable();
                        break;
                    case 3:
                        DivNumber();
                        break;
                }
            }
        }
    }
}