using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> FindByNameAsync(params object[] keys);
        Task<T> FindByNameAsync(Expression<Func<T, bool>> predicate);
    }
}
