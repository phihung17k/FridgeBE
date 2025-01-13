using FridgeBE.Core.Entities.Common;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Models;
using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using System.Data;
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

        private static IQueryable<T> where(IQueryable<T> dataSet, Expression<Func<T, bool>>? predicate)
        {
            if (predicate == null)
                return dataSet;

            return dataSet.Where(predicate);
        }

        private static IQueryable<T> include(IQueryable<T> dataSet, Expression<Func<T, object>>[]? includes)
        {
            if (includes.IsNullOrEmpty())
                return dataSet;

            foreach (Expression<Func<T, object>> include in includes!)
            {
                dataSet = dataSet.Include(include);
            }
            return dataSet;
        }

        private static IQueryable<T> paginate(IQueryable<T> dataSet, int pageIndex = 1, int pageSize = 10, bool isTrack = false)
        {
            dataSet = dataSet.Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize);
            return isTrack ? dataSet : dataSet.AsNoTracking();
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

        public async Task<T?> GetById(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> result = _dbSet;
            result = where(result, predicate);
            result = include(result, includes);
            return await result.FirstOrDefaultAsync();
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetReadOnlyListAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        //IEnumerable = _dbSet.Where(Func<T, bool> predicate)
        //IQueryable = _dbSet.Where(Expression<Func<T, bool>> predicate)
        public virtual async Task<List<T>> GetAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> result = _dbSet;
            result = where(result, predicate);
            result = include(result, includes);

            return await result.ToListAsync();
        }

        public async Task<Pagination<T>?> GetPaginationAsync(
            Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            int pageIndex = 1, 
            int pageSize = 10, 
            params Expression<Func<T, object>>[]? includes)
        {
            int pageCount = (int) Math.Ceiling((double) _dbSet.Count() / pageSize);
            if (pageIndex < 1 || pageIndex > pageCount)
                return null;

            IQueryable<T> items = _dbSet;
            items = where(items, predicate);

            if (orderBy != null)
            {
                items = orderBy(items);
            }

            int itemCount = await items.CountAsync();
            items = paginate(items, pageIndex, pageSize);
            items = include(items, includes);

            return new Pagination<T>
            {
                TotalItemsCount = itemCount,
                PageSize = pageSize,
                PageIndex = pageIndex,
                Items = items
            };
        }
    }
}