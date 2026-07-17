using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Application.QueryServices;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Queries;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Repositories;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Application.Internal.QueryServices;

/// <summary>
///     Application service for device queries.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class DeviceQueryService(IDeviceRepository deviceRepository) : IDeviceQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query, CancellationToken cancellationToken)
    {
        return await deviceRepository.ListAsync(cancellationToken);
    }
}
