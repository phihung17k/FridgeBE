using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebUtilities;

namespace FridgeBE.Api.Middleware
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is BadRequestObjectResult)
            {
                BadRequestObjectResult result = (BadRequestObjectResult) context.Result!;
                int statusCode = (int) result.StatusCode!;
                string detail = (string) result.Value!;
                string title = ReasonPhrases.GetReasonPhrase(statusCode);

                var problemDetails = new ProblemDetails
                {
                    Title = title,
                    Status = statusCode,
                    Detail = detail
                };
                result.Value = problemDetails;
            }
        }
    }
}