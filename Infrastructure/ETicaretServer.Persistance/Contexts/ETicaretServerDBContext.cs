using ETicaretServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETicaretServer.Persistance.Contexts
{
    public class ETicaretServerDBContext:DbContext
    {
        public ETicaretServerDBContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
