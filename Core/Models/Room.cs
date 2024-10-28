using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Room
    {
        static int _id = 1;
        public int Id;
        public string Name { get; set; }

        double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }
        public int PersonCapacity;

        public bool IsAvailable = true;

        public Room(string name, double price, int personCapacity)
        {
            Id = _id++;
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
        }

        public void ShowInfo()
        {
            if (!IsAvailable)
            {
                Console.WriteLine($"Id: {Id}, Name: {Name}, Price: {Price}, Person Capacity: {PersonCapacity}, Rezervasiya: Olunub");
            }
            else
            {
                Console.WriteLine($"Id: {Id}, Name: {Name}, Price: {Price}, Person Capacity: {PersonCapacity}, Rezervasiya: Olunmayib");
            }
        }


    }
}
