using FridgeBE.Core.Entities;

namespace FridgeBE.Core.Interfaces.IRepositories
{
    public interface IUserAccountRepository : IGenericRepository<UserAccount>
    {
        UserAccount? GetByEmail(string email, bool includeUserLogin = false);
    }
}