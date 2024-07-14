using FridgeBE.Api.Constants;
using FridgeBE.Core.Exceptions;
using FridgeBE.Core.Interfaces.IUtils;
using FridgeBE.Core.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static FridgeBE.Api.Constants.PermissionConstants;

namespace FridgeBE.Infrastructure.Utils
{
    public class TokenUtils : ITokenUtils
    {
        private readonly JwtOptions _jwtOptions;

        public TokenUtils(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public Tuple<string, DateTime> GenerateAccessToken(string userId, string name, string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email),
                new Claim(PermissionConstants.ClaimType, View.AllIngredients),
                new Claim(PermissionConstants.ClaimType, Edit.Ingredient)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

            DateTime expireTime = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpirationSeconds);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: expireTime,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Tuple.Create(tokenString, expireTime);
        }

        public Tuple<string, DateTime> GenerateRefreshToken(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

            DateTime expireTime = DateTime.Now.AddDays(_jwtOptions.RefreshTokenExpirationDays);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: expireTime,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Tuple.Create(tokenString, expireTime);
        }

        public async Task<bool> ValidateRefreshToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationResult tokenResult = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                //ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)),
                RequireExpirationTime = true,
                ClockSkew = TimeSpan.Zero,
            });

            return tokenResult.IsValid;
        }
    }
}