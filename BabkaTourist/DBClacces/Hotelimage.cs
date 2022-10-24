using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkaTourist.DBClacces
{
    public class Hotelimage
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public string Image { get; set; }
        public Hotelimage(int id, Hotel hotel, string image)
        {
            Id = id;
            this.Hotel = hotel;
            Image = image;
        }
        public Hotelimage()
        {

        }
    }
}
