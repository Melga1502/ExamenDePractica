using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Pipeline.Middleware.Components;

/// <summary>
///     Handles unexpected exceptions and returns a Problem Details response.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
{
    /// <summary>
    ///     Executes the middleware logic for the current request.
    /// </summary>
    /// <param name="context">Current HTTP context.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unhandled request exception");
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problem = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Detail = "An unexpected error occurred while processing the request."
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
        }
    }
}
