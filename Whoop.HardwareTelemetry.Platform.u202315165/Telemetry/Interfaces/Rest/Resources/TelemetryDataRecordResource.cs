namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Resources;

/// <summary>
///     Resource returned for a telemetry data record.
/// </summary>
/// <param name="Id">Telemetry record id.</param>
/// <param name="DeviceId">Device identifier.</param>
/// <param name="HeartRate">Heart rate value.</param>
/// <param name="RespiratoryRate">Respiratory rate value.</param>
/// <param name="BatteryLevel">Device battery level.</param>
/// <param name="DeviceStatus">Device status text.</param>
/// <param name="RecordedAt">Telemetry record date.</param>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public record TelemetryDataRecordResource(
    long Id,
    long DeviceId,
    int HeartRate,
    int RespiratoryRate,
    int BatteryLevel,
    string DeviceStatus,
    DateTime RecordedAt);
