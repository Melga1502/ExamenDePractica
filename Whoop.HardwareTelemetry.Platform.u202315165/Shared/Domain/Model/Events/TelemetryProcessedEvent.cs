namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Model.Events;

/// <summary>
///     Integration event emitted when telemetry data is processed.
/// </summary>
/// <param name="RecordId">Telemetry record id.</param>
/// <param name="DeviceId">Authorized device id.</param>
/// <param name="RecordedAt">Telemetry record date.</param>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public record TelemetryProcessedEvent(long RecordId, long DeviceId, DateTime RecordedAt) : IEvent;
