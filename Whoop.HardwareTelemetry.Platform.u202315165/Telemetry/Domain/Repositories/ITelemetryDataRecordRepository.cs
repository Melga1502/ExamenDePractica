using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Aggregates;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Repositories;

/// <summary>
///     Repository contract for telemetry data records.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface ITelemetryDataRecordRepository : IBaseRepository<TelemetryDataRecord>
{
}
