using FridgeBE.Api.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace FridgeBE.Api.Authorization
{
    /// <summary>
    /// Same AddPolicy in AddAuthorization (Startup)
    /// 
    /// Generate authorization policies by
    /// - Parsing from the policy name in AuthorizeAttribute
    /// - Using AuthorizationPolicyBuilder to create a new AuthorizationPolicy
    /// - Adding requirements to the policy based with AuthorizationPolicyBuilder.AddRequirements. In other scenarios, you might use RequireClaim, RequireRole, or RequireUserName instead.
    /// 
    /// Try to handle all policy names is used in AuthorizeAttribute
    /// </summary>
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider DefaultAuthorizationPolicyProvider { get; }

        public PermissionPolicyProvider(DefaultAuthorizationPolicyProvider defaultAuthorizationPolicyProvider)
        {
            DefaultAuthorizationPolicyProvider = defaultAuthorizationPolicyProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the default authorization policy (the policy used for [Authorize] attributes without a policy specified)</returns>
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return DefaultAuthorizationPolicyProvider.GetDefaultPolicyAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the fallback authorization policy (the policy used by the Authorization Middleware when no policy is specified)</returns>
        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        {
            return DefaultAuthorizationPolicyProvider.GetFallbackPolicyAsync();
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="policyName">policyName in Authorize(policyName)</param>
        /// <returns>Returns an authorization policy for a given name</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (!policyName.StartsWith(PermissionConstants.ClaimType, StringComparison.InvariantCultureIgnoreCase))
                return Task.FromResult<AuthorizationPolicy?>(null);

            var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
            policy.Requirements.Add(new PermissionRequirement(PermissionConstants.ClaimType, policyName));

            return Task.FromResult<AuthorizationPolicy?>(policy.Build());
        }
    }
}