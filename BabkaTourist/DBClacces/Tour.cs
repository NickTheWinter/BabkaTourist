namespace BabkaTourist.DBClacces
{
    internal class Tour
    {
        public int Id { get; set; }
        public int TicketCount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public bool isActual { get; set; }
        public Tour(int id, int ticketCount, string name, string description, string image, float price, bool isActual)
        {
            Id = id;
            TicketCount = ticketCount;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
            this.isActual = isActual;
        }
    }
}
