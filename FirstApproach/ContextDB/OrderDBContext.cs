using FirstApproach.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApproach.ContextDB
{
    public class OrderDBContext:DbContext
    {
        public OrderDBContext()
        {

        }
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options)
        {
        }
        public DbSet<Order> orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source =DESKTOP-4UVUEQS\HARSHITHA;Initial Catalog=OrderWebApiCoreCF;Integrated Security=True");
        }
    }

    
}
