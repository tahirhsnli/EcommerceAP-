using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretDbContext _context;
        public ReadRepository(ETicaretDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var querry = Table.AsQueryable();
            if (!tracking)
            {
                querry = querry.AsNoTracking();
            }
            return querry;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var querry = Table.Where(method);
            if (!tracking)
            {
                querry = querry.AsNoTracking();
            }
            return querry;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var querry = Table.AsQueryable();
            if (!tracking)
            {
                querry = querry.AsNoTracking();
            }
            return await querry.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var querry = Table.AsQueryable();
            if (!tracking)
            {
                querry = querry.AsNoTracking();
            }
            return await querry.FirstOrDefaultAsync(p=>p.Id == Guid.Parse(id));
        }


    }
}
