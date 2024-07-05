using FridgeBE.Core.Entities;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FridgeBE.Infrastructure.Repositories
{
    public class UserAccountRepository : GenericRepository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public UserAccount? GetByEmail(string email, bool isIncludeUserLogin = false)
        {
            IQueryable<UserAccount> result = DbSet.Where(ua => ua.UserLogin.Email == email);

            if (isIncludeUserLogin)
            {
                result = result.Include(ua => ua.UserLogin);
            }

            return result.FirstOrDefault();
        }
    }
}