using Microsoft.EntityFrameworkCore;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

/// <summary>
///     Entity Framework Core repository for devices.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class DeviceRepository(AppDbContext context) : BaseRepository<Device>(context), IDeviceRepository
{
    /// <inheritdoc />
    public async Task<Device?> FindBySerialNumberAsync(string serialNumber, CancellationToken cancellationToken = default)
    {
        return await Context.Set<Device>()
            .FirstOrDefaultAsync(device => device.SerialNumber == serialNumber, cancellationToken);
    }
}
