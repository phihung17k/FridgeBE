﻿using AutoMapper;
using FridgeBE.Core.Entities;
using FridgeBE.Core.Exceptions;
using FridgeBE.Core.Interfaces.IRepositories;
using FridgeBE.Core.Interfaces.IServices;
using FridgeBE.Core.Models.RequestModels;
using FridgeBE.Core.Models.ResponseModels;
using FridgeBE.Infrastructure.Repositories;
using FridgeBE.Infrastructure.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace FridgeBE.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserAccount> _passwordHasher;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<UserAccount> passwordHasher, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _configuration = configuration;

            UserAccountRepository = (_unitOfWork.Repository<UserAccount>() as IUserAccountRepository)!;
            UserLoginRepository = (_unitOfWork.Repository<UserLogin>() as IUserLoginRepository)!;
        }

        public IUserAccountRepository UserAccountRepository { get; set; }
        public IUserLoginRepository UserLoginRepository { get; set; }

        public async Task<UserAccountModel> CreateUser(UserRegisterRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return new UserAccountModel(HttpStatusCode.BadRequest, "Email and Password are required");

            if (!Regex.IsMatch(request.Email, "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$"))
                return new UserAccountModel(HttpStatusCode.BadRequest, "Email is invalid");

            // if email is existed, send mail to confirm "Somebody tried to register your account.
            //      If this was you please ignore this mail. If you forgot your password, use the forgot password link on the login page"
            // error: Unrecognized email or password 
            UserAccount? userAccount = UserAccountRepository.GetByEmail(request.Email);

            if (userAccount != null)
                return new UserAccountModel(HttpStatusCode.BadRequest, "Unrecognized email or password");

            PasswordUtils.HashPassword(request.Password, out string passwordHash, out string passwordSalt);

            userAccount = new UserAccount
            {
                UserLogin = new UserLogin
                {
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                }
            };

            await UserAccountRepository.UpdateAndSaveAsync(userAccount);
            return _mapper.Map<UserAccountModel>(userAccount);
        }

        public async Task<UserAccountModel> SignInByPassword(UserLoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                return new UserAccountModel(HttpStatusCode.BadRequest, "Email and Password are required");

            UserAccount? userAccount = UserAccountRepository.GetByEmail(request.Email, includeUserLogin: true);
            if (userAccount == null)
                return new UserAccountModel(HttpStatusCode.BadRequest, "Unrecognized email or password");

            bool result = PasswordUtils.VerifyPasswordHash(request.Password, userAccount.UserLogin.PasswordHash, userAccount.UserLogin.PasswordSalt);

            if (!result)
                return new UserAccountModel(HttpStatusCode.Unauthorized, "Invalid email or password");

            // create token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("user_identifier", userAccount.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userAccount.Name),
                new Claim(ClaimTypes.Email, request.Email),
            };

            return _mapper.Map<UserAccountModel>(userAccount);
        }
    }
}