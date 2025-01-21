using FridgeBE.Core.Entities;
using FridgeBE.Core.Models;
using System.Linq.Expressions;

namespace FridgeBE.Core.Interfaces.IRepositories
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
        Task<Pagination<Ingredient>?> GetPaginationIncludeFirstAsync(
            Expression<Func<Ingredient, bool>>? predicate = null,
            Func<IQueryable<Ingredient>, IOrderedQueryable<Ingredient>>? orderBy = null,
            int pageIndex = 1,
            int pageSize = 10, 
            params Expression<Func<Ingredient, object>>[]? includes);
    }
}