using FridgeBE.Core.Entities.Common;
using FridgeBE.Core.Models;
using System.Linq.Expressions;

namespace FridgeBE.Core.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        T Create(T entity);
        bool Update(T entity);
        bool UpdateRange(IEnumerable<T> entity);
        bool Delete(T entity);
        bool DeleteRange(IEnumerable<T> entity);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);

        Task<T?> GetById<Tid>(Tid id);
        IList<T> GetAll();
        Task<IList<T>> GetAllAsync();

        List<T> Get(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes);

        IReadOnlyList<T> GetReadOnlyList();
        Task<IReadOnlyList<T>> GetReadOnlyListAsync();
        Task<Pagination<T>> GetPaginationAsync(Expression<Func<T, bool>> predicate, int pageIndex = 0, int pageSize = 10);
    }
}