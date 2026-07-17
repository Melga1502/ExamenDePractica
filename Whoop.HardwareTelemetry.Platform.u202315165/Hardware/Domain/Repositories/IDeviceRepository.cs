using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Repositories;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Repositories;

/// <summary>
///     Repository contract for WHOOP devices.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface IDeviceRepository : IBaseRepository<Device>
{
    /// <summary>
    ///     Finds a device by its serial number.
    /// </summary>
    /// <param name="serialNumber">Device serial number.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The matching device if found; otherwise null.</returns>
    Task<Device?> FindBySerialNumberAsync(string serialNumber, CancellationToken cancellationToken = default);
}
