using FridgeBE.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace FridgeBE.Api.Middlewares
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, bool isDevelopment)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                AllowStatusCode404Response = true,
                ExceptionHandler = async context =>
                {
                    HttpResponse response = context.Response;
                    response.ContentType = Application.Json;

                    IExceptionHandlerPathFeature exceptionHandlerFeature = context.Features.GetRequiredFeature<IExceptionHandlerPathFeature>();
                    Exception exception = exceptionHandlerFeature.Error;

                    if (exceptionHandlerFeature.Error is RequestException _exception)
                    {
                        // default 500
                        response.StatusCode = (int)_exception.StatusCode;
                    }

                    string title = ReasonPhrases.GetReasonPhrase(response.StatusCode);
                    if (string.IsNullOrEmpty(title))
                    {
                        title = "Unknown";
                    }

                    var problemDetails = new ProblemDetails
                    {
                        Title = title,
                        Status = response.StatusCode,
                        Detail = exception.Message,
                    };

                    if (isDevelopment)
                    {
                        problemDetails.Extensions = new Dictionary<string, object?>()
                        {
                            { "traceId", context.TraceIdentifier },
                            { "data", exception.Data },
                            { "stackTrace", exception.StackTrace },
                        };
                    }
                    await response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                }
            });
        }
    }
}