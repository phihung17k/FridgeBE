using Microsoft.AspNetCore.Authorization;

namespace FridgeBE.Api.Authorization
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type.Equals(requirement.ClaimType, StringComparison.InvariantCultureIgnoreCase) && requirement.AllowedValues!.Contains(c.Value, StringComparer.InvariantCultureIgnoreCase)))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail(new AuthorizationFailureReason(this, "User is not permitted"));
            }

            return Task.CompletedTask;
        }
    }
}