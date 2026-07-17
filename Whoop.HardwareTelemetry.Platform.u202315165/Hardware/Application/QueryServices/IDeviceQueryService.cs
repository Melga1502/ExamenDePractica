using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Queries;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Application.QueryServices;

/// <summary>
///     Defines query operations for devices.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface IDeviceQueryService
{
    /// <summary>
    ///     Handles the query to list all devices.
    /// </summary>
    /// <param name="query">Query request.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>All devices.</returns>
    Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query, CancellationToken cancellationToken);
}
