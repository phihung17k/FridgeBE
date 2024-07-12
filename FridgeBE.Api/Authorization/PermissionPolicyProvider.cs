using FridgeBE.Api.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Concurrent;

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
        public DefaultAuthorizationPolicyProvider _defaultAuthorizationPolicyProvider;
        private readonly ConcurrentDictionary<string, AuthorizationPolicy> _policies;

        public PermissionPolicyProvider(DefaultAuthorizationPolicyProvider defaultAuthorizationPolicyProvider)
        {
            _defaultAuthorizationPolicyProvider = defaultAuthorizationPolicyProvider;
            _policies = new ConcurrentDictionary<string, AuthorizationPolicy>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the default authorization policy (the policy used for [Authorize] attributes without a policy specified)</returns>
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => _defaultAuthorizationPolicyProvider.GetDefaultPolicyAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the fallback authorization policy (the policy used by the Authorization Middleware when no policy is specified)</returns>
        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => _defaultAuthorizationPolicyProvider.GetFallbackPolicyAsync();

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

            AuthorizationPolicy? policy = _policies.GetValueOrDefault(policyName);

            if (policy != null)
                return Task.FromResult<AuthorizationPolicy?>(policy);

            var policyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);

            string[] permissions = policyName.Substring(PermissionConstants.ClaimType.Length).Trim(':').Split(',');
            foreach (string permission in permissions)
            {
                policyBuilder.Requirements.Add(new PermissionRequirement(PermissionConstants.ClaimType, permission));
            }

            policy = policyBuilder.Build();
            _policies.TryAdd(policyName, policy);

            return Task.FromResult<AuthorizationPolicy?>(policyBuilder.Build());
        }
    }
}