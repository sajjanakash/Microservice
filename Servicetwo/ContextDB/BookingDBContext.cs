using Microsoft.EntityFrameworkCore;
using Servicetwo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicetwo.ContextDB
{
    public class BookingDBContext:DbContext
    {
        public BookingDBContext()
        {

        }
        public BookingDBContext(DbContextOptions<BookingDBContext> options) : base(options)
        {
        }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source =DESKTOP-4UVUEQS\HARSHITHA;Initial Catalog=servicetwo;Integrated Security=True");
        }
    }
}
