using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabkaTourist.DBClacces
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Country> Countries{ get; set; } = null!;
        public DbSet<Hotel> Hotels{ get; set; } = null!;
        public DbSet<HotelComment> HotelComments{ get; set; } = null!;
        public DbSet<Hotelimage> Hotelimages { get; set; } = null!;
        public DbSet<Tour> Tours{ get; set; } = null!;
        public DbSet<Type> Types{ get; set; } = null!;
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ngknn.ru;Database=BabkaTourist;User Id=33П;Password=12357;");
        }
    }
}
