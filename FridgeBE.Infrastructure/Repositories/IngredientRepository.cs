using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeBE.Infrastructure.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}