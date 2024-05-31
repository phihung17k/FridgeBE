using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FridgeBE.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public Task<T> Create(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(T model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById<Tid>(Tid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Where(Func<T, bool> predicate)
        {
            //var compiledQuery = EF.CompileAsyncQuery((ApplicationDbContext context) => context.Set<T>().Where(predicate));
            Func<ApplicationDbContext, Task<IEnumerable<T>>> compiledQuery = EF.CompileAsyncQuery((ApplicationDbContext _) => _dbSet.Where(predicate));
            return compiledQuery.Invoke(_dbContext);
        }

        public Task<IReadOnlyList<T>> GetPaginatedData()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<T> GetReadOnlyList()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<IReadOnlyList<T>> GetReadOnlyListAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public Task<bool> IsExists()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}