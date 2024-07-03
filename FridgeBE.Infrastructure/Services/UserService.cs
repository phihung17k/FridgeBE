using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Exceptions;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;
using FridgeBE.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace FridgeBE.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserAccount> _passwordHasher;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<UserAccount> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;

            UserAccountRepository = (_unitOfWork.Repository<UserAccount>() as IUserAccountRepository)!;
            UserLoginRepository = (_unitOfWork.Repository<UserLogin>() as IUserLoginRepository)!;
        }

        public IUserAccountRepository UserAccountRepository { get; set; }
        public IUserLoginRepository UserLoginRepository { get; set; }

        public async Task<UserAccountModel> CreateUser(UserRegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                throw new RequestException(HttpStatusCode.BadRequest, "Email and Password are required");

            if (!Regex.IsMatch(request.Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                throw new RequestException(HttpStatusCode.BadRequest, "Email is invalid");

            var userAccount = new UserAccount
            {
                UserLogin = new UserLogin 
                { 
                    Email = request.Email,
                    PasswordHash = _passwordHasher.HashPassword(null, request.Password)
                }
            };

            await UserAccountRepository.UpdateAndSaveAsync(userAccount);
            return _mapper.Map<UserAccountModel>(userAccount);
        }
    }
}