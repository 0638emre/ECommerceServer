using ETicaretServer.Domain.Entities;
using ETicaretServer.Domain.Entities.Common;
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


        //burada bir interceptor kullanıyoruz. araya girecek olan bu override metot gelen istek insert ise created date fieldını, update ise updateddate fieldını tetikleyecek.
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker  = Enttiyler üzerinde yapıaln değişikliklerin ya da yeni eklenen verilerin yakalnmasını sağlayan propertylerdir. update operasyonlarında track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
