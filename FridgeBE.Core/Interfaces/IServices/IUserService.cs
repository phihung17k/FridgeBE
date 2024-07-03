using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;

namespace FridgeBE.Core.Interfaces.IServices
{
    public interface IUserService
    {
        IUserAccountRepository UserAccountRepository { get; set; }
        IUserLoginRepository UserLoginRepository { get; set; }

        Task<UserAccountModel> CreateUser(UserRegisterRequest request);
    }
}