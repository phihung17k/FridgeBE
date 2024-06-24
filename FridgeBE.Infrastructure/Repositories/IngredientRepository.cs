using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;

namespace FridgeBE.Infrastructure.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}