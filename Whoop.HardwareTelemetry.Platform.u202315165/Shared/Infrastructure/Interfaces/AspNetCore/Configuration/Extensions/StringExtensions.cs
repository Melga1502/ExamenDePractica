using System.Text.RegularExpressions;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Interfaces.AspNetCore.Configuration.Extensions;

/// <summary>
///     Provides naming helpers for ASP.NET Core routes.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public static partial class StringExtensions
{
    /// <summary>
    ///     Converts a PascalCase text to kebab-case.
    /// </summary>
    /// <param name="text">Text to transform.</param>
    /// <returns>The kebab-case text.</returns>
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return text;
        return KebabCaseRegex().Replace(text, "$1-$2").ToLowerInvariant();
    }

    [GeneratedRegex("([a-z0-9])([A-Z])")]
    private static partial Regex KebabCaseRegex();
}
