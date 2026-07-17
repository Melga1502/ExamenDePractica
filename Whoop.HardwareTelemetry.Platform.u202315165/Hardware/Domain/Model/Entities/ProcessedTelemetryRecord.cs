namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Entities;

/// <summary>
///     Stores a telemetry record id processed by the hardware event handler.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class ProcessedTelemetryRecord
{
    public long Id { get; private set; }
    public long RecordId { get; private set; }

    private ProcessedTelemetryRecord()
    {
    }

    /// <summary>
    ///     Creates a processed telemetry record marker.
    /// </summary>
    /// <param name="recordId">Telemetry record id.</param>
    public ProcessedTelemetryRecord(long recordId)
    {
        if (recordId <= 0) throw new ArgumentOutOfRangeException(nameof(recordId), "Record id must be positive.");
        RecordId = recordId;
    }
}
