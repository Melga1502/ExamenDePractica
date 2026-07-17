using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Pipeline.Middleware.Components;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Pipeline.Middleware.Extensions;

/// <summary>
///     Provides middleware registration helpers.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public static class GlobalExceptionHandlerMiddlewareExtensions
{
    /// <summary>
    ///     Adds global exception handling to the request pipeline.
    /// </summary>
    /// <param name="builder">Application builder.</param>
    /// <returns>The same application builder.</returns>
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}
