using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;

namespace FridgeBE.Infrastructure.Repositories
{
    public class CategoryResponsitory : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryResponsitory(ApplicationDbContext dbContext) : base(dbContext)
        { }
    }
}