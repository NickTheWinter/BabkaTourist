using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkaTourist.DBClacces
{
    internal class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountStars { get; set; }
        public Country Country { get; set; }
        public Hotel(int id, string name, int countStars, Country country)
        {
            Id = id;
            Name = name;
            CountStars = countStars;
            Country = country;
        }
    }
}
