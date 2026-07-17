namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Errors;

/// <summary>
///     Telemetry application error codes.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public enum TelemetryError
{
    DeviceAuthorizationFailed,
    InvalidRecordedAt,
    InvalidDateFormat,
    DatabaseError,
    InternalServerError
}
