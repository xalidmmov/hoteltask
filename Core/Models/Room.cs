using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Models
{
    public class Room
    {
        private static int _id = 0;
        public string _name { get; set; }   
        public int Id { get; }
        private double _price;
        public bool IsAvailable { get; set; } = true;
        public int PersonCapacity {  get; set; }   


        public double Price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Qiymet sifirdan boyuk olmalidir.");
                }
                _price = value;
            }
        }



        public Room(string name, double price, int personCapacity)
        {
            Id = ++_id;
            _name = name;
            Price = price;
            PersonCapacity = personCapacity;
        }


        public string ShowInfo()
        {
            return $"Id: {Id}, Ad: {_name}, Qiymet: {Price}, Tutum: {PersonCapacity}, Uygundur: {IsAvailable}";
        }

        public override string ToString()
        {
            return ShowInfo();
        }

    }
}
