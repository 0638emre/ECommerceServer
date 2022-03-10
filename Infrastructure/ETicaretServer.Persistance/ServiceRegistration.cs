using ETicaretServer.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ETicaretServer.Persistance
{
    public static class ServiceRegistration
    {
        //IoC ye buradan extend et. ne istersen extend et.
        public static void AddPersistenceServices(this IServiceCollection services)
        {
           
            //yukarıda .net 6 nın getirdiği appsettings çağırma işlemini yapıyoruz
            //services.AddSingleton<IProductService, ProductService>();
            //burada postgre sql connection string veriyoruz.
            services.AddDbContext<ETicaretServerDBContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        }
    }
}
