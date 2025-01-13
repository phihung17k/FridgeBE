using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Exceptions;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Interfaces.IUtils;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;
using FridgeBE.Infrastructure.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.RegularExpressions;

namespace FridgeBE.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserAccount> _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly ITokenUtils _tokenUtils;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<UserAccount> passwordHasher, IConfiguration configuration, ITokenUtils tokenUtils)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _tokenUtils = tokenUtils;

            UserAccountRepository = (_unitOfWork.Repository<UserAccount>() as IUserAccountRepository)!;
            UserLoginRepository = (_unitOfWork.Repository<UserLogin>() as IUserLoginRepository)!;
        }

        public IUserAccountRepository UserAccountRepository { get; set; }
        public IUserLoginRepository UserLoginRepository { get; set; }

        public async Task<RegisterResponseModel> CreateUser(UserRegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return new RegisterResponseModel(HttpStatusCode.BadRequest, ErrorMessages.EmailPasswordRequire);

            if (!Regex.IsMatch(request.Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                return new RegisterResponseModel(HttpStatusCode.BadRequest, ErrorMessages.EmailInvalid);

            // if email is existed, send mail to confirm "Somebody tried to register your account.
            //      If this was you please ignore this mail. If you forgot your password, use the forgot password link on the login page"
            // error: Unrecognized email or password 
            UserAccount? userAccount = UserAccountRepository.GetByEmail(request.Email);

            if (userAccount != null)
                return new RegisterResponseModel(HttpStatusCode.BadRequest, ErrorMessages.UnrecognizedEmailPassword);

            PasswordUtils.HashPassword(request.Password, out string passwordHash, out string passwordSalt);

            userAccount = new UserAccount
            {
                Name = RandomUtils.RandomName(),
                UserLogin = new UserLogin
                {
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                }
            };

            await UserAccountRepository.UpdateAndSaveAsync(userAccount);
            return _mapper.Map<RegisterResponseModel>(userAccount);
        }

        public async Task<LoginResponseModel> SignInByPassword(UserLoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return new LoginResponseModel(HttpStatusCode.BadRequest, ErrorMessages.EmailPasswordRequire);

            UserAccount? userAccount = UserAccountRepository.GetByEmail(request.Email, includeUserLogin: true);
            if (userAccount == null)
                return new LoginResponseModel(HttpStatusCode.BadRequest, ErrorMessages.UnrecognizedEmailPassword);

            bool result = PasswordUtils.VerifyPasswordHash(request.Password, userAccount.UserLogin.PasswordHash, userAccount.UserLogin.PasswordSalt);

            if (!result)
                return new LoginResponseModel(HttpStatusCode.Unauthorized, ErrorMessages.InvalidEmailPassword);

            // create token
            Tuple<string, DateTime> accessToken = _tokenUtils.GenerateAccessToken(userAccount.Id.ToString(), userAccount.Name, userAccount.UserLogin.Email);

            Tuple<string, DateTime> refreshToken = _tokenUtils.GenerateRefreshToken(userAccount.Id.ToString());
            userAccount.UserLogin.RefreshToken = refreshToken.Item1;
            userAccount.UserLogin.RefreshTokenExpireTime = refreshToken.Item2;
            await _unitOfWork.SaveChangeAsync();

            LoginResponseModel model = _mapper.Map<LoginResponseModel>(userAccount);
            model.AccessToken = accessToken.Item1;
            model.AccessTokenExpireTime = accessToken.Item2;
            return model;
        }

        public async Task<RefreshTokenModel> RefreshToken(RefreshTokenRequest request)
        {
            UserAccount? userAccount = UserAccountRepository.GetByToken(request.UserId, request.RefreshToken);

            if (userAccount == null)
                return new RefreshTokenModel(HttpStatusCode.BadRequest, ErrorMessages.UserNotExisted);

            bool isValidToken = await _tokenUtils.ValidateRefreshToken(request.RefreshToken);

            if (!isValidToken)
                return new RefreshTokenModel(HttpStatusCode.BadRequest, ErrorMessages.InvalidToken);

            Tuple<string, DateTime> accessToken = _tokenUtils.GenerateAccessToken(userAccount.Id.ToString(), userAccount.Name, userAccount.UserLogin.Email);

            return new RefreshTokenModel
            {
                AccessToken = accessToken.Item1,
                RefreshToken = userAccount.UserLogin.RefreshToken!,
                AccessTokenExpireTime = accessToken.Item2
            };
        }
    }
}