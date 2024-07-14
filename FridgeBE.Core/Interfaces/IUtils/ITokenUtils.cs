namespace FridgeBE.Core.Interfaces.IUtils
{
    public interface ITokenUtils
    {
        Tuple<string, DateTime> GenerateAccessToken(string userId, string name, string email);
        Tuple<string, DateTime> GenerateRefreshToken(string userId);

        Task<bool> ValidateRefreshToken(string token);
    }
}