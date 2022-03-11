using ETicaretServer.Application.Repositories.ProductAbstractRepo;
using ETicaretServer.Domain.Entities;
using ETicaretServer.Persistance.Contexts;

namespace ETicaretServer.Persistance.Repositories.ProductConcreteRepo
{
    public class ProductReadRepository:ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ETicaretServerDBContext context):base(context)
        {

        }
    }
}
