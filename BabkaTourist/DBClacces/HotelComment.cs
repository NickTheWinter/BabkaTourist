using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkaTourist.DBClacces
{
    internal class HotelComment
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime? Date { get; set; }
        public HotelComment(int id, Hotel hotel, string text, string author, DateTime? date)
        {
            Id = id;
            this.Hotel = hotel;
            Text = text;
            Author = author;
            Date = date;
        }
    }
}
