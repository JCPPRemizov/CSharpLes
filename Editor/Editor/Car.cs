using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Car
    {
        private string brand, color;
        private int speed;
        public Car(string brand, string color, int speed)
        {
            this.brand = brand;
            this.color = color;
            this.speed = speed;
        }
        public Car() { }
        public string _brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string _color
        {
            get { return color; }
            set { color = value; }
        }
        public int _speed
        {
            get { return speed; }
            set { speed = value; }
        }
    }
}
