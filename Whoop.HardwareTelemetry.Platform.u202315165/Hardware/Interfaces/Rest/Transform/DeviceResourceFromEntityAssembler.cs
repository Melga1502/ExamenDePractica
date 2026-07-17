using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Interfaces.Rest.Resources;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Interfaces.Rest.Transform;

/// <summary>
///     Assembles device resources from device aggregates.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public static class DeviceResourceFromEntityAssembler
{
    /// <summary>
    ///     Converts a device aggregate into a device resource.
    /// </summary>
    /// <param name="device">Device aggregate.</param>
    /// <returns>Device resource.</returns>
    public static DeviceResource ToResourceFromEntity(Device device)
    {
        return new DeviceResource(
            device.Id,
            device.SerialNumber,
            device.Model,
            device.Status.ToString(),
            device.LastSyncDate);
    }
}
