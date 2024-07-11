using Microsoft.AspNetCore.Authorization;

namespace FridgeBE.Api.Authorization
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        const string PemissionPrefix = "Permission";

        public PermissionAttribute(string policy) : base(policy)
        { }
    }
}