using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace FridgeBE.Api.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, bool isDevelopment)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.ContentType = Application.Json;

                    var exceptionHandlerFeature = context.Features.GetRequiredFeature<IExceptionHandlerPathFeature>();
                    Exception exception = exceptionHandlerFeature.Error;

                    int statusCode = context.Response.StatusCode;
                    string title = ReasonPhrases.GetReasonPhrase(statusCode);
                    if (string.IsNullOrEmpty(title))
                    {
                        title = "Unknown";
                    }

                    var problemDetails = new ProblemDetails
                    {
                        Title = title,
                        Status = statusCode,
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
                    await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                });
            });
        }
    }
}