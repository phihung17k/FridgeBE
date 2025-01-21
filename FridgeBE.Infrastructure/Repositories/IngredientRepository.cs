using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Models;
using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FridgeBE.Infrastructure.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public async Task<Pagination<Ingredient>?> GetPaginationIncludeFirstAsync(
            Expression<Func<Ingredient, bool>>? predicate, 
            Func<IQueryable<Ingredient>, IOrderedQueryable<Ingredient>>? orderBy, 
            int pageIndex, 
            int pageSize, 
            params Expression<Func<Ingredient, object>>[]? includes)
        {
            IQueryable<Ingredient> items = DbSet;
            items = Include(items, includes);
            items = Where(items, predicate);

            int pageCount = (int) Math.Ceiling((double) items.Count() / pageSize);
            if (pageIndex < 1 || pageIndex > pageCount)
                return null;

            if (orderBy != null)
            {
                items = orderBy(items);
            }

            int itemCount = await items.CountAsync();
            items = Paginate(items, pageIndex, pageSize);

            return new Pagination<Ingredient>
            {
                TotalItemsCount = itemCount,
                PageSize = pageSize,
                PageIndex = pageIndex,
                Items = items
            };
        }
    }
}