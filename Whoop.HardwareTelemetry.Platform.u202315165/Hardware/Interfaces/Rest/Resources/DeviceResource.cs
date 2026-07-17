namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Interfaces.Rest.Resources;

/// <summary>
///     Resource returned for a WHOOP device.
/// </summary>
/// <param name="Id">Device id.</param>
/// <param name="SerialNumber">Device serial number.</param>
/// <param name="Model">Device model.</param>
/// <param name="Status">Device status.</param>
/// <param name="LastSyncDate">Last synchronization date.</param>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public record DeviceResource(
    long Id,
    string SerialNumber,
    string Model,
    string Status,
    DateTime? LastSyncDate);
