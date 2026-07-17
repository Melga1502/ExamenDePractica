namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Commands;

/// <summary>
///     Command used to create a telemetry data record.
/// </summary>
/// <param name="DeviceId">Device identifier.</param>
/// <param name="HeartRate">Heart rate value.</param>
/// <param name="RespiratoryRate">Respiratory rate value.</param>
/// <param name="BatteryLevel">Battery level value.</param>
/// <param name="DeviceStatus">Device status text.</param>
/// <param name="RecordedAt">Telemetry record date.</param>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public record CreateTelemetryDataRecordCommand(
    long DeviceId,
    int HeartRate,
    int RespiratoryRate,
    int BatteryLevel,
    string DeviceStatus,
    DateTime RecordedAt);
