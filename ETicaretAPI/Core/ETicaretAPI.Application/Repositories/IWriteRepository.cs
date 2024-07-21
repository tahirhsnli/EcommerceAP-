using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsync(List<T> entities);
        Task<T> RemoveAsync(T entity);
        Task<T> RemoveAsync(string Id);
        Task<T> UpdateAsync(T entity);

    }
}
