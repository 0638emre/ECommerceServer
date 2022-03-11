using ETicaretServer.Application.Repositories.CustomerAbstractRepo;
using ETicaretServer.Domain.Entities;
using ETicaretServer.Persistance.Contexts;

namespace ETicaretServer.Persistance.Repositories.CustomerConcreteRepo
{
    public class CustomerReadRepository:ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ETicaretServerDBContext context):base(context)
        {

        }
    }
}
