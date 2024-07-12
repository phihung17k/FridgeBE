using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace FridgeBE.Api.Authorization
{
    /// <summary>
    /// Customize the behavior of AuthorizationMiddleware includes response, statusCode
    /// </summary>
    public class PermissionAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler _defaultHandler = new();

        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Forbidden && authorizeResult.AuthorizationFailure != null)
            {
                int statusCode = StatusCodes.Status403Forbidden;
                string title = ReasonPhrases.GetReasonPhrase(statusCode);

                var problemDetails = new ProblemDetails
                {
                    Title = title,
                    Status = statusCode,
                    Detail = HttpStatusCode.Forbidden.ToString()
                };
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(problemDetails);
                return;
            }
            
            await _defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
}