using FridgeBE.Core.Entities.Common;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Models;
using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace FridgeBE.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public T Create(T entity)
        {
            EntityEntry<T> entityEntry = _dbSet.Add(entity);
            _context.SaveChanges();

            // get id
            // context.Entry(blog).Property(e => e.Id).CurrentValue
            return entityEntry.Entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            EntityEntry<T> entityEntry = _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            //_dbSet.UpdateRange(entity);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateRange(IEnumerable<T> entity)
        {
            _dbSet.UpdateRange(entity);
            //_dbSet.UpdateRange(entity);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<T?> GetById<TKey>(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        //IEnumerable = _dbSet.Where(Func<T, bool> predicate)
        //IQueryable = _dbSet.Where(Expression<Func<T, bool>> predicate)
        public virtual async Task<List<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = _dbSet;

            if(predicate != null)
            {
                result = _dbSet.Where(predicate);
            }

            foreach (var include in includes)
            {
                result = result.Include(include);
            }

            if(orderBy != null)
            {
                return await orderBy(result).ToListAsync();
            }

            return await result.ToListAsync();
        }

        public IReadOnlyList<T> GetReadOnlyList()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<IReadOnlyList<T>> GetReadOnlyListAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Pagination<T>> GetPaginationAsync(Expression<Func<T, bool>> predicate, int pageIndex = 0, int pageSize = 10)
        {
            Task<int> itemCountTask = _dbSet.CountAsync();
            Task<List<T>> itemsTask = _dbSet.Where(predicate)
                              .Skip(pageIndex * pageSize)
                              .Take(pageSize)
                              .AsNoTracking()
                              .ToListAsync();
            await Task.WhenAll(itemCountTask, itemsTask);

            var result = new Pagination<T>
            {
                TotalItemsCount = await itemCountTask,
                PageSize = pageSize,
                PageIndex = pageIndex,
                Items = await itemsTask
            };

            return result;
        }
    }
}