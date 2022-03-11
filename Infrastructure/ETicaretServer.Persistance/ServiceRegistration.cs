using ETicaretServer.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ETicaretServer.Application.Repositories.CustomerAbstractRepo;
using ETicaretServer.Persistance.Repositories.CustomerConcreteRepo;
using ETicaretServer.Application.Repositories.OrderAbstractRepo;
using ETicaretServer.Persistance.Repositories.OrderConcreteRepo;
using ETicaretServer.Application.Repositories.ProductAbstractRepo;
using ETicaretServer.Persistance.Repositories.ProductConcreteRepo;

namespace ETicaretServer.Persistance
{
    //IOC
    public static class ServiceRegistration
    {
        //IoC ye buradan extend et. ne istersen extend et.
        public static void AddPersistenceServices(this IServiceCollection services)
        {
          
            //yukarıda .net 6 nın getirdiği appsettings çağırma işlemini yapıyoruz
            //services.AddSingleton<IProductService, ProductService>();
            //burada postgre sql connection string veriyoruz.
            services.AddDbContext<ETicaretServerDBContext>(options => options.UseNpgsql(Configuration.ConnectionString) , ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
