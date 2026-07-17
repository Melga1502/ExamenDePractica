namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Resources;

/// <summary>
///     Resource used to create a telemetry data record.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class CreateTelemetryDataRecordResource
{
    /// <summary>
    ///     Device identifier.
    /// </summary>
    public long DeviceId { get; init; } = 1;

    /// <summary>
    ///     Heart rate value.
    /// </summary>
    public int HeartRate { get; init; } = 72;

    /// <summary>
    ///     Respiratory rate value.
    /// </summary>
    public int RespiratoryRate { get; init; } = 16;

    /// <summary>
    ///     Device battery level.
    /// </summary>
    public int BatteryLevel { get; init; } = 88;

    /// <summary>
    ///     Device status text.
    /// </summary>
    public string DeviceStatus { get; init; } = "NORMAL";

    /// <summary>
    ///     Telemetry record date in yyyy-MM-dd HH:mm:ss format.
    /// </summary>
    public string RecordedAt { get; init; } = "2026-07-17 14:45:00";
}
