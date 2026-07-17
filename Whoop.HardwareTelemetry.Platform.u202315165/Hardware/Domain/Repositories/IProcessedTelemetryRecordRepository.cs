namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Repositories;

/// <summary>
///     Repository contract for telemetry records already processed by hardware handlers.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface IProcessedTelemetryRecordRepository
{
    /// <summary>
    ///     Checks whether a telemetry record was already handled.
    /// </summary>
    /// <param name="recordId">Telemetry record id.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>True when the record was already processed.</returns>
    Task<bool> ExistsByRecordIdAsync(long recordId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Stores the processed telemetry record id.
    /// </summary>
    /// <param name="recordId">Telemetry record id.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    Task AddAsync(long recordId, CancellationToken cancellationToken = default);
}
