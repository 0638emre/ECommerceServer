using ETicaretServer.Domain.Entities;

namespace ETicaretServer.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
