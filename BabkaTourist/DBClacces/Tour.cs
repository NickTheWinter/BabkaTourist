using System.Collections.Generic;

namespace BabkaTourist.DBClacces
{
    public class Tour
    {
        public int Id { get; set; }
        public int TicketCount { get; set; } //da
        public string Name { get; set; } //da
        public string Description { get; set; } // da
        public string? Image { get; set; } //poher
        public float Price { get; set; } //da
        public bool isActual { get; set; }
        public List<Hotel> Hotels { get; set; } = new(); //dopustim
        public Type Type { get; set; }
        public Tour(int ticketCount, string name, string description, string image, float price, bool isActual, Type type,List<Hotel> hotels)
        {
            TicketCount = ticketCount;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            this.isActual = isActual;
            Type = type;
            Hotels = hotels;
        }
        public Tour()
        {

        }
    }
}
