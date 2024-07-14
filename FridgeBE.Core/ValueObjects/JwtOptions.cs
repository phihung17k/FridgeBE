namespace FridgeBE.Core.ValueObjects
{
    public record JwtOptions(
        string Key,
        string Issuer,
        string Audience,
        int AccessTokenExpirationSeconds,
        int RefreshTokenExpirationDays
    );
}