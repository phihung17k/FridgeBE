using Microsoft.AspNetCore.Authorization;

namespace FridgeBE.Api.Authorization
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string ClaimType { get; set; }
        public IEnumerable<string> AllowedValues { get; set; }

        public PermissionRequirement(string claimType, params string[] allowedValues)
        {
            ClaimType = claimType;
            AllowedValues = allowedValues;
        }
    }
}