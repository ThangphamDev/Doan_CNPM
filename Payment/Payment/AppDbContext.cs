using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public AppDbContext()
            : base(new DbContextOptionsBuilder<AppDbContext>()
                  .UseInMemoryDatabase("PaymentAppDb")
                  .Options)
        {
        }
    }
}
