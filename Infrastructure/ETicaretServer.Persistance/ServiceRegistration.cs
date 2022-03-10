using ETicaretServer.Application.Abstractions;
using ETicaretServer.Persistance.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretServer.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
