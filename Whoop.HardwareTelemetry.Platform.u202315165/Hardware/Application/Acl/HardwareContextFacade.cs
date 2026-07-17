using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Interfaces.Acl;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Application.Acl;

/// <summary>
///     ACL facade that exposes Hardware capabilities to other bounded contexts.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class HardwareContextFacade(IDeviceRepository deviceRepository) : IHardwareContextFacade
{
    /// <inheritdoc />
    public async Task<bool> IsDeviceAuthorizedForTelemetryAsync(long deviceId, CancellationToken cancellationToken)
    {
        var device = await deviceRepository.FindByIdAsync(deviceId, cancellationToken);
        return device?.IsDataTransmissionAllowed() == true;
    }
}
