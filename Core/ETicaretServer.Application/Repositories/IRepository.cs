using ETicaretServer.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretServer.Application.Repositories
{
    //burada T koşuluna BaseEntity koymamızın sebebi marker design patterninden dolayıdır. 
    //repository concrete classlarını yazarken bir metoda şart tanımlamamız gerektiğinde ID ihtiyacı doğacaktır.
    //fakat biz bu BaseEntity yerine sadece dar bir CLASS verirsek bu bizim ID ihtiyacımızı karşılamaz.
    //bunun yerine BaseEntity'i veririz ki; BaseEntity zaten bir class olmanın yanında içinde ID'ye de kapsar.
    public interface IRepository<T> where T:BaseEntity
    {
        DbSet<T> Table { get; } 
    }
}
