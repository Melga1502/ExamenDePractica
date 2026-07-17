namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.ValueObjects;

/// <summary>
///     Wearable health information reported with telemetry.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public record DeviceHealthData
{
    public int BatteryLevel { get; init; }
    public string DeviceStatus { get; init; } = string.Empty;

    private DeviceHealthData()
    {
    }

    /// <summary>
    ///     Creates and validates device health data.
    /// </summary>
    /// <param name="batteryLevel">Device battery level.</param>
    /// <param name="deviceStatus">Device status text sent by the wearable.</param>
    public DeviceHealthData(int batteryLevel, string deviceStatus)
    {
        if (batteryLevel is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(batteryLevel), "Battery level must be between 0 and 100.");
        if (string.IsNullOrWhiteSpace(deviceStatus))
            throw new ArgumentException("Device status is required.", nameof(deviceStatus));

        BatteryLevel = batteryLevel;
        DeviceStatus = deviceStatus;
    }
}
