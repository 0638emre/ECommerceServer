using ETicaretServer.Application.Repositories.ProductAbstractRepo;
using ETicaretServer.Domain.Entities;
using ETicaretServer.Persistance.Contexts;

namespace ETicaretServer.Persistance.Repositories.ProductConcreteRepo
{
    public class ProductWriteRepository:WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ETicaretServerDBContext context) : base(context)
        {

        }
    }
}
