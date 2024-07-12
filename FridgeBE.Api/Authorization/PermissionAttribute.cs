using FridgeBE.Api.Constants;
using Microsoft.AspNetCore.Authorization;

namespace FridgeBE.Api.Authorization
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        public PermissionAttribute(params string[] policy)
        {
            base.Policy = $"{PermissionConstants.ClaimType}:{string.Join(",", policy)}";
        }
    }
}