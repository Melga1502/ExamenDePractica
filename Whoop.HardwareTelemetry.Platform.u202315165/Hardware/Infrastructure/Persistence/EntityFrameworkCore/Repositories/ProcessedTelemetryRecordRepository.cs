using Microsoft.EntityFrameworkCore;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Entities;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

/// <summary>
///     Entity Framework Core repository for processed telemetry markers.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class ProcessedTelemetryRecordRepository(AppDbContext context) : IProcessedTelemetryRecordRepository
{
    /// <inheritdoc />
    public async Task<bool> ExistsByRecordIdAsync(long recordId, CancellationToken cancellationToken = default)
    {
        return await context.Set<ProcessedTelemetryRecord>()
            .AnyAsync(record => record.RecordId == recordId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddAsync(long recordId, CancellationToken cancellationToken = default)
    {
        await context.Set<ProcessedTelemetryRecord>()
            .AddAsync(new ProcessedTelemetryRecord(recordId), cancellationToken);
    }
}
