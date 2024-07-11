using FridgeBE.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebUtilities;

namespace FridgeBE.Api.Filters
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // handle case ResponseModel contain ErrorMessage
            if (!(context.Result is ObjectResult))
                return;

            var objectResult = (ObjectResult)context.Result!;
            if (objectResult.Value is ResponseModelBase)
            {
                var responseModel = (ResponseModelBase)objectResult.Value;
                if (!string.IsNullOrEmpty(responseModel.ErrorMessage))
                {
                    int statusCode = (int)responseModel.StatusCode!;
                    string title = ReasonPhrases.GetReasonPhrase(statusCode);

                    var problemDetails = new ProblemDetails
                    {
                        Title = title,
                        Status = statusCode,
                        Detail = responseModel.ErrorMessage
                    };
                    objectResult.Value = problemDetails;
                }
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}