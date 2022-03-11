using ETicaretServer.Application.Repositories.OrderAbstractRepo;
using ETicaretServer.Domain.Entities;
using ETicaretServer.Persistance.Contexts;

namespace ETicaretServer.Persistance.Repositories.OrderConcreteRepo
{
    public class OrderWriteRepository:WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ETicaretServerDBContext context) : base(context)
        {

        }
    }
}
