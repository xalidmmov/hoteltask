using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Hotel(string name)
        {
            Name = name;
            
        }
        public override string ToString()
        {
            return Name; 
        }
    }
}
