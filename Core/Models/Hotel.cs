using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Hotel
    {
        public int _id = 1;
        public int Id;
        public string Name { get; set; }

        public Hotel(string name)
        {
            Id = _id++;
            Name = name;
        }

    }
}
