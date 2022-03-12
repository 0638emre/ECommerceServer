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
            services.AddDbContext<ETicaretServerDBContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
