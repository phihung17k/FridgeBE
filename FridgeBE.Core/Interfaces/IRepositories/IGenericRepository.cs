using FridgeBE.Core.Entities.Common;
using FridgeBE.Core.Models;
using System.Linq.Expressions;

namespace FridgeBE.Core.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        T Create(T entity);
        Task<T> CreateAndSaveAsync(T entity);

        T Update(T entity);
        Task<T> UpdateAndSaveAsync(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task<bool> UpdateRangeAndSaveAsync(IEnumerable<T> entities);

        T Delete(T entity);
        Task<T> DeleteAndSaveAsync(T entity);
        Task<T?> DeleteById<TKey>(TKey id);
        Task<T?> DeleteByIdAndSaveAsync<TKey>(TKey id);
        void DeleteRange(IEnumerable<T> entity);
        Task<bool> DeleteRangeAndSaveAsync(IEnumerable<T> entity);

        Task<T?> GetById<Tid>(Tid id);
        Task<T?> GetById(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]? includes);
        Task<IList<T>> GetAllAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> GetReadOnlyListAsync();
        Task<Pagination<T>> GetPaginationAsync(
            Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, 
            int pageIndex = 1, 
            int pageSize = 10,
            params Expression<Func<T, object>>[]? includes);
    }
}