using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;

namespace FridgeBE.Infrastructure.Repositories
{
    public class UserAccountRepository : GenericRepository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}