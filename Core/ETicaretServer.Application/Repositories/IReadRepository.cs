using ETicaretServer.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ETicaretServer.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T:BaseEntity
    {
        //Burada çoğu zaman List<T> şeklinde kullanılır. List şeklinde sonuç döndürmek demek sorgunun in memory'e çekilip orada şart yazılması demektir. Fakat IQueryable de ise sorgu ya da şartlı sorgular direkt olarak serverside tarafında(sql server) yazılıp sonuç öyle döndürür. Bu da işlemin performansını olumlu etkiler. :) güzel not.

        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
