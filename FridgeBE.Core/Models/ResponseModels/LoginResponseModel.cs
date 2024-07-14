using System.Net;

namespace FridgeBE.Core.Models.ResponseModels
{
    public class LoginResponseModel : ResponseModelBase
    {
        public LoginResponseModel()
        { }

        public LoginResponseModel(HttpStatusCode statusCode, string errorMessage) : base(statusCode, errorMessage)
        { }

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; } = null!;

        public string AccessToken { get; set; } = null!;

        public string RefreshToken { get; set; } = null!;

        public DateTime AccessTokenExpireTime { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
    }
}