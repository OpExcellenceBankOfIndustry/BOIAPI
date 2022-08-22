using BOI.BOIApplications.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace BOI.BOIApplications.Persistence.Repository
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly BOIDbContext _dbContext;

        public BaseRepository(BOIDbContext dbContext)
        {   
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> FindByNameAsync(params object[] keys)
        {
            return await _dbContext.Set<T>().FindAsync(keys);
        }

        public virtual async Task<T> FindByNameAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
