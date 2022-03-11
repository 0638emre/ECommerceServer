using ETicaretServer.Application.Repositories.OrderAbstractRepo;
using ETicaretServer.Domain.Entities;
using ETicaretServer.Persistance.Contexts;

namespace ETicaretServer.Persistance.Repositories.OrderConcreteRepo
{
    public class OrderReadRepository:ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ETicaretServerDBContext context):base(context)
        {

        }
    }
}
