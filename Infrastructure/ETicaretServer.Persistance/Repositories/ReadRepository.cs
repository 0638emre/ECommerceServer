using ETicaretServer.Application.Repositories;
using ETicaretServer.Domain.Entities.Common;
using ETicaretServer.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETicaretServer.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretServerDBContext _context;
        public ReadRepository(ETicaretServerDBContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
            => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            => Table.Where(method);

        public async Task<T> GetByIdAsync(string id)
            => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        

    }
}
