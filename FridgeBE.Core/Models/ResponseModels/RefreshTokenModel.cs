using System.Net;

namespace FridgeBE.Core.Models.ResponseModels
{
    public class RefreshTokenModel : ResponseModelBase
    {
        public RefreshTokenModel()
        { }

        public RefreshTokenModel(HttpStatusCode statusCode, string errorMessage) : base(statusCode, errorMessage)
        { }

        public string AccessToken { get; set; } = null!;

        public string RefreshToken { get; set; } = null!;

        public DateTime AccessTokenExpireTime { get; set; }
    }
}