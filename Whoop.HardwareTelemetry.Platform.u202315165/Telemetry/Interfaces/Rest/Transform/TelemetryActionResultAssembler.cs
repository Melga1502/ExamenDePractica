using Microsoft.AspNetCore.Mvc;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Application.Model;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Errors;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Transform;

/// <summary>
///     Converts telemetry application results into HTTP responses.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public static class TelemetryActionResultAssembler
{
    /// <summary>
    ///     Converts a create telemetry result into an action result.
    /// </summary>
    /// <param name="result">Application result.</param>
    /// <returns>HTTP action result.</returns>
    public static IActionResult ToActionResultFromCreateTelemetryDataRecordResult(Result<TelemetryDataRecord> result)
    {
        if (result.IsSuccess)
        {
            var resource = TelemetryDataRecordResourceFromEntityAssembler.ToResourceFromEntity(result.Value!);
            return new ObjectResult(resource) { StatusCode = StatusCodes.Status201Created };
        }

        var statusCode = result.Error switch
        {
            TelemetryError.DeviceAuthorizationFailed => StatusCodes.Status403Forbidden,
            TelemetryError.InvalidDateFormat => StatusCodes.Status400BadRequest,
            TelemetryError.InvalidRecordedAt => StatusCodes.Status400BadRequest,
            TelemetryError.DatabaseError => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };

        return new ObjectResult(new { message = result.Message }) { StatusCode = statusCode };
    }
}
