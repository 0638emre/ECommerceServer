using ETicaretServer.Domain.Entities.Common;

namespace ETicaretServer.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
