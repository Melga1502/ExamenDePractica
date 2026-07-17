using System.Globalization;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Commands;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Resources;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Transform;

/// <summary>
///     Assembles telemetry commands from request resources.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public static class CreateTelemetryDataRecordCommandFromResourceAssembler
{
    private const string RecordedAtFormat = "yyyy-MM-dd HH:mm:ss";

    /// <summary>
    ///     Converts a request resource into a create command.
    /// </summary>
    /// <param name="resource">Request resource.</param>
    /// <returns>The create command.</returns>
    public static CreateTelemetryDataRecordCommand ToCommandFromResource(CreateTelemetryDataRecordResource resource)
    {
        var recordedAt = DateTime.ParseExact(
            resource.RecordedAt,
            RecordedAtFormat,
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

        return new CreateTelemetryDataRecordCommand(
            resource.DeviceId,
            resource.HeartRate,
            resource.RespiratoryRate,
            resource.BatteryLevel,
            resource.DeviceStatus,
            recordedAt);
    }
}
