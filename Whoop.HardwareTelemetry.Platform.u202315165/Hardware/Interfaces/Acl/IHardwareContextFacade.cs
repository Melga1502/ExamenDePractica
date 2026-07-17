namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Interfaces.Acl;

/// <summary>
///     Facade exposed by Hardware to other bounded contexts.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface IHardwareContextFacade
{
    /// <summary>
    ///     Checks whether a device exists and allows telemetry transmission.
    /// </summary>
    /// <param name="deviceId">Device identifier.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>True when the device is active and authorized.</returns>
    Task<bool> IsDeviceAuthorizedForTelemetryAsync(long deviceId, CancellationToken cancellationToken);
}
