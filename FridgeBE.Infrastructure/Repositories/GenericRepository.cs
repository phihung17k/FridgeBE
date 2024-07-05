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

        public DbSet<T> DbSet { get { return _dbSet; } }

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public virtual T Create(T entity)
        {
            EntityEntry<T> entityEntry = _dbSet.Add(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<T> CreateAndSaveAsync(T entity)
        {
            EntityEntry<T> entityEntry = _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual T Update(T entity)
        {
            EntityEntry<T> entityEntry = _dbSet.Update(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<T> UpdateAndSaveAsync(T entity)
        {
            EntityEntry<T> entityEntry = _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public virtual async Task<bool> UpdateRangeAndSaveAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual T Delete(T entity)
        {
            EntityEntry<T> entityEntry = _dbSet.Remove(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<T> DeleteAndSaveAsync(T entity)
        {
            EntityEntry<T> entityEntry = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual async Task<T?> DeleteById<TKey>(TKey id)
        {
            T? entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            EntityEntry<T> entityEntry = _dbSet.Remove(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<T?> DeleteByIdAndSaveAsync<TKey>(TKey id)
        {
            T? entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return null;

            EntityEntry<T> entityEntry = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public virtual async Task<bool> DeleteRangeAndSaveAsync(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
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

        public async Task<Pagination<T>> GetPaginationAsync(Expression<Func<T, bool>> predicate, int pageIndex = 1, int pageSize = 10)
        {
            IQueryable<T> filteredItems = _dbSet.Where(predicate);

            Task<int> itemCountTask = filteredItems.CountAsync();
            Task<List<T>> itemsTask = filteredItems.Skip((pageIndex - 1) * pageSize)
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