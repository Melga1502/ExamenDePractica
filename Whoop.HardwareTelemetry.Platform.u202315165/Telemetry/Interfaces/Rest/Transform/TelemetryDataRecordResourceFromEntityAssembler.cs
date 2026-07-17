using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Resources;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Transform;

/// <summary>
///     Assembles telemetry resources from telemetry aggregates.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public static class TelemetryDataRecordResourceFromEntityAssembler
{
    /// <summary>
    ///     Converts a telemetry aggregate into a response resource.
    /// </summary>
    /// <param name="record">Telemetry aggregate.</param>
    /// <returns>Telemetry resource.</returns>
    public static TelemetryDataRecordResource ToResourceFromEntity(TelemetryDataRecord record)
    {
        return new TelemetryDataRecordResource(
            record.Id,
            record.DeviceId,
            record.VitalSignData.HeartRate,
            record.VitalSignData.RespiratoryRate,
            record.DeviceHealthData.BatteryLevel,
            record.DeviceHealthData.DeviceStatus,
            record.RecordedAt);
    }
}
