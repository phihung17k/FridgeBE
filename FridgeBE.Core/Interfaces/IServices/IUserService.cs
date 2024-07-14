using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;

namespace FridgeBE.Core.Interfaces.IServices
{
    public interface IUserService
    {
        IUserAccountRepository UserAccountRepository { get; set; }
        IUserLoginRepository UserLoginRepository { get; set; }

        Task<RegisterResponseModel> CreateUser(UserRegisterRequest request);
        Task<LoginResponseModel> SignInByPassword(UserLoginRequest request);
        Task<RefreshTokenModel> RefreshToken(RefreshTokenRequest request);
    }
}