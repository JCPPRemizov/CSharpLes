using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class OutCars
    {
        private static string filePath, fileEx,fileSave, fileExSave;
        private static void PathIn()
        {
            Console.Clear();
            Console.Write("Введите полный путь до файла: ");
            filePath = Console.ReadLine();
            if (filePath == "")
            {
                outCars();
            }
            else if (File.Exists(filePath) == false)
            {
                var t = File.Create(filePath);
                if (new FileInfo(filePath).Length == 0 && Serializer.CarCount() > 0)
                {
                    fileEx = Path.GetExtension(filePath);
                    Console.Clear();
                    Console.WriteLine("Желаете загрузить ваши машины в этот файл?(y/n):");
                    string choise = Console.ReadLine();
                    if (choise.ToLower() == "y")
                    {
                        t.Close();
                        Serializer.Serialize(filePath, fileEx);
                        outCars();
                    }
                    else
                    {
                        t.Close();
                        Serializer.Deserialize(filePath, fileEx);
                        outCars();
                    }
                }
            }
            else { fileEx = Path.GetExtension(filePath); Serializer.Deserialize(filePath, fileEx); outCars();}
        }
        private static void Action()
        {
            ConsoleKeyInfo userKey = Console.ReadKey(true);
            switch (userKey.Key)
            {
                case ConsoleKey.F3:
                    {
                        PathIn();
                        break;
                    }
                case ConsoleKey.F2:
                    {
                        Serializer.CarListOut();
                        break;

                    }
                case ConsoleKey.F1:
                    {
                        Serializer.Serialize(filePath, fileEx);
                        outCars();
                        break;
                    }
                case ConsoleKey.F4:
                    {
                        Serializer.CarChanger();
                        outCars();
                        break;
                    }
                case ConsoleKey.F5:
                    {
                        Serializer.CarMaker();
                        outCars();
                        break;
                    }
                case ConsoleKey.F6:
                    {
                        Serializer.CarsDel();
                        outCars();
                        break;

                    }
                case ConsoleKey.Backspace:
                    {
                        Console.Clear();
                        outCars();
                        break;
                    }
            }
        }
        public static void outCars()
        {
            Console.Clear();
            Console.WriteLine($"F1 - Сохранить файл\nF2 - Просмотр файла\nF3 - Открыть файл\nF4 - Изменить машину\nF5 - Создать машину\nF6 - Удалить машину\nВаш файл: {filePath}");
            while (true)
            {
                Action();
            }
        }
    }
}
