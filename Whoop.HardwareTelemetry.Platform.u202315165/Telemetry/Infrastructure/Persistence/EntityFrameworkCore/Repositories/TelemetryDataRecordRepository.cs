using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Repositories;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

/// <summary>
///     Entity Framework Core repository for telemetry data records.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class TelemetryDataRecordRepository(AppDbContext context)
    : BaseRepository<TelemetryDataRecord>(context), ITelemetryDataRecordRepository
{
}
