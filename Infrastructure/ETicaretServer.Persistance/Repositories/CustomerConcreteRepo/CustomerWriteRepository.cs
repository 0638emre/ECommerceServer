using ETicaretServer.Application.Repositories.CustomerAbstractRepo;
using ETicaretServer.Domain.Entities;
using ETicaretServer.Persistance.Contexts;

namespace ETicaretServer.Persistance.Repositories.CustomerConcreteRepo
{
    public class CustomerWriteRepository:WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ETicaretServerDBContext context):base(context)
        {

        }
    }
}
