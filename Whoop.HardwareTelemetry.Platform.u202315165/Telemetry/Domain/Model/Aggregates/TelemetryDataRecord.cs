using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Model.Entities;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Commands;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.ValueObjects;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Aggregates;

/// <summary>
///     Aggregate root that represents biometric telemetry received from a wearable.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class TelemetryDataRecord : IAuditableEntity
{
    public long Id { get; private set; }
    public long DeviceId { get; private set; }
    public VitalSignData VitalSignData { get; private set; } = new(1, 1);
    public DeviceHealthData DeviceHealthData { get; private set; } = new(0, "UNKNOWN");
    public DateTime RecordedAt { get; private set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    private TelemetryDataRecord()
    {
    }

    /// <summary>
    ///     Creates a telemetry data record from a command.
    /// </summary>
    /// <param name="command">Command with telemetry data.</param>
    public TelemetryDataRecord(CreateTelemetryDataRecordCommand command)
    {
        if (command.DeviceId <= 0) throw new ArgumentOutOfRangeException(nameof(command.DeviceId), "Device id must be positive.");
        if (command.RecordedAt > DateTime.UtcNow)
            throw new ArgumentException("RecordedAt cannot be later than the current UTC date and time.", nameof(command.RecordedAt));

        DeviceId = command.DeviceId;
        VitalSignData = new VitalSignData(command.HeartRate, command.RespiratoryRate);
        DeviceHealthData = new DeviceHealthData(command.BatteryLevel, command.DeviceStatus);
        RecordedAt = command.RecordedAt;
    }
}
