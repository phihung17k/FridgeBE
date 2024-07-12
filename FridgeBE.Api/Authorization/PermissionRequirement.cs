using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace FridgeBE.Api.Authorization
{
    public class PermissionRequirement : ClaimsAuthorizationRequirement
    {
        public PermissionRequirement(string claimType, params string[] allowedValues) : base(claimType, allowedValues) 
        { }

        //[Obsolete("Error: HandleRequirementAsync call multiple times, use PermissionHandler instead")]
        //protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClaimsAuthorizationRequirement requirement)
        //{
        //    if (context.User.HasClaim(c => c.Type.Equals(requirement.ClaimType, StringComparison.InvariantCultureIgnoreCase) && requirement.AllowedValues!.Contains(c.Value, StringComparer.InvariantCultureIgnoreCase)))
        //    {
        //        context.Succeed(requirement);
        //    }
        //    else
        //    {
        //        context.Fail();
        //    }
        //    return Task.CompletedTask;
        //}
    }
}