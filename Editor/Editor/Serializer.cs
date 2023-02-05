using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Editor
{
    public class Serializer
    {
        private static List<Car> carList = new List<Car>();
        public static void Serialize(string path, string ex)
        {
            try
            {
                switch (ex)
                {
                    case ".txt":
                        {


                            string save = "";
                            carList.ForEach(c => save += $"{c._brand}\n{c._color}\n{c._speed}");
                            File.WriteAllText(path, save);
                            break;
                        }
                    case ".json":
                        {
                            string json = JsonConvert.SerializeObject(carList);
                            File.WriteAllText(path, json);
                            break;
                        }
                    case ".xml":
                        {
                            XmlSerializer xml = new XmlSerializer(typeof(List<Car>));
                            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                            {
                                xml.Serialize(fs, carList);
                                fs.Close();
                            }
                            break;
                        }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка сериализации!");
            }
        }
        public static void Deserialize(string path, string ex)
        {
            carList.Clear();
            try
            {
                string fileText = File.ReadAllText(path);
                switch (ex)
                {
                    case ".txt":
                        {
                            string[] spl = fileText.Split('\n');
                            for (int j = 2; j < spl.Length; j += 3)
                            {

                                carList.Add(new Car(spl[j - 2], spl[j - 1], Convert.ToInt32(spl[j])));

                            }
                            break;
                        }
                    case ".json":
                        {
                            carList.AddRange(JsonConvert.DeserializeObject<List<Car>>(fileText));
                            break;
                        }
                    case ".xml":
                        {
                            XmlSerializer xml = new XmlSerializer(typeof(List<Car>));
                            using (var fs = new FileStream(path, FileMode.Open))
                            {
                                carList.Add(xml.Deserialize(fs) as Car);
                                fs.Close();
                            }
                            break;
                        }
                }
            }
            catch { Console.WriteLine("Ошибка десериализации!"); }
        }
        public static void CarListOut()
        {
            Console.Clear();
            carList.ForEach(c => Console.WriteLine($"{c._brand}\n{c._color}\n{c._speed}"));
        }
        public static void CarMaker(string path, string ex)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите название машины:");
                string name = Console.ReadLine();
                if (name == "") { OutCars.outCars(); }
                Console.Write("Введите цвет машины:");
                string color = Console.ReadLine();
                if (color == "") { OutCars.outCars(); }
                Console.Write("Введите скорость машины:");
                int speed = 0;
                try
                {
                    speed = Convert.ToInt32(Console.ReadLine());
                    if (speed == 0) { OutCars.outCars(); }
                }
                catch { Console.WriteLine("Введите скорость!"); continue; }
                carList.Add(new Car(name, color, speed));
                Serialize(path, ex);
                break;
            }
        }
        public static void CarMaker()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите название машины:");
                string name = Console.ReadLine();
                if (name == "") { OutCars.outCars(); }
                Console.Write("Введите цвет машины:");
                string color = Console.ReadLine();
                if (color == "") { OutCars.outCars(); }
                Console.Write("Введите скорость машины:");
                int speed = 0;
                try
                {
                    speed = Convert.ToInt32(Console.ReadLine());
                    if (speed == 0) { OutCars.outCars(); }
                }
                catch { Console.WriteLine("Введите скорость!"); continue; }
                carList.Add(new Car(name, color, speed));
                break;
            }
        }
        public static void CarChanger()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите какую машину хотите изменить (Для возвращения введите 0): ");
                int i = 1;
                foreach (var car in carList)
                {
                    Console.WriteLine(i + "." + car._brand);
                }
                try
                {
                    Console.Write("Ваш выбор: ");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    if (choise == 0)
                    {
                        break;
                    }
                    else if (choise <= carList.Count)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Введите название машины:");
                            string name = Console.ReadLine();
                            Console.Write("Введите цвет машины:");
                            string color = Console.ReadLine();
                            Console.Write("Введите скорость машины:");
                            int speed = 0;
                            try
                            {
                                speed = Convert.ToInt32(Console.ReadLine());
                            }
                            catch { Console.WriteLine("Введите скорость!"); continue; }
                            carList[choise - 1]._brand = name;
                            carList[choise - 1]._color = color;
                            carList[choise - 1]._speed = speed;
                            break;
                        }
                    }
                    else { continue; }
                }
                catch { continue; }
            }
        }
        public static int CarCount()
        {
            return carList.Count;
        }
        public static void CarsDel()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите какую машину хотите удалить (Для возвращения введите 0): ");
                int i = 1;
                foreach (var car in carList)
                {
                    Console.WriteLine(i + "." + car._brand);
                    i++;
                }
                try
                {
                    Console.Write("Ваш выбор: ");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    if (choise == 0)
                    {
                        break;
                    }
                    else if (choise <= carList.Count)
                    {
                        carList.RemoveAt(choise - 1);
                    }
                }
                catch { }
            }
        }
    }
}