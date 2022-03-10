using ETicaretServer.Application.Abstractions;
using ETicaretServer.Domain.Entities;

namespace ETicaretServer.Persistance.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            => new()
            {
                new() { Id = Guid.NewGuid(),
                        Name = "Product1",
                        Stock = 10,
                        Price = 14
                },
                new() { Id = Guid.NewGuid(),
                        Name = "Product2",
                        Stock = 50,
                        Price = 23
                },
                new() { Id = Guid.NewGuid(),
                        Name = "Product3",
                        Stock = 75,
                        Price = 56
                },
                new() { Id = Guid.NewGuid(),
                        Name = "Product4",
                        Stock = 12,
                        Price = 24
                },
                new() { Id = Guid.NewGuid(),
                        Name = "Product5",
                        Stock = 98,
                        Price = 15
                },
            };
     }
}
