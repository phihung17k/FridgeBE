using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;

namespace FridgeBE.Infrastructure.Repositories
{
    public class UserLoginRepository : GenericRepository<UserLogin>, IUserLoginRepository
    {
        public UserLoginRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}