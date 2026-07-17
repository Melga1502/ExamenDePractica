using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.ValueObjects;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Model.Entities;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Aggregates;

/// <summary>
///     Aggregate root that represents an authorized WHOOP device.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class Device : IAuditableEntity
{
    public long Id { get; private set; }
    public string SerialNumber { get; private set; } = string.Empty;
    public string Model { get; private set; } = string.Empty;
    public EDeviceStatus Status { get; private set; }
    public DateTime? LastSyncDate { get; private set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    private Device()
    {
    }

    /// <summary>
    ///     Creates a device with the data required by the hardware inventory.
    /// </summary>
    /// <param name="serialNumber">Unique device serial number.</param>
    /// <param name="model">Device model.</param>
    /// <param name="status">Device status.</param>
    public Device(string serialNumber, string model, EDeviceStatus status)
    {
        if (string.IsNullOrWhiteSpace(serialNumber))
            throw new ArgumentException("Serial number is required.", nameof(serialNumber));
        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentException("Model is required.", nameof(model));

        SerialNumber = serialNumber;
        Model = model;
        Status = status;
    }

    /// <summary>
    ///     Creates a seeded device with a known identifier.
    /// </summary>
    /// <param name="id">Device identifier.</param>
    /// <param name="serialNumber">Unique device serial number.</param>
    /// <param name="model">Device model.</param>
    /// <param name="status">Device status.</param>
    public Device(long id, string serialNumber, string model, EDeviceStatus status) : this(serialNumber, model, status)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Device id must be positive.");
        Id = id;
    }

    /// <summary>
    ///     Indicates whether this device can send telemetry data.
    /// </summary>
    /// <returns>True when the device is active; otherwise false.</returns>
    public bool IsDataTransmissionAllowed()
    {
        return Status == EDeviceStatus.Active;
    }

    /// <summary>
    ///     Updates the last telemetry synchronization date.
    /// </summary>
    /// <param name="syncDate">Telemetry record date.</param>
    public void UpdateLastSyncDate(DateTime syncDate)
    {
        LastSyncDate = syncDate;
    }
}
