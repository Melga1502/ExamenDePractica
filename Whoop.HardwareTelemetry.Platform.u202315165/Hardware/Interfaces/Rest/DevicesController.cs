using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Application.QueryServices;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Queries;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Interfaces.Rest.Transform;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Interfaces.Rest;

/// <summary>
///     REST controller for devices.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
[ApiController]
[Route("api/v1/[controller]")]
public class DevicesController(IDeviceQueryService deviceQueryService) : ControllerBase
{
    /// <summary>
    ///     Gets all devices.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>Stored devices.</returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all devices",
        Description = "Gets the current list of WHOOP devices stored in the hardware inventory.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Devices returned successfully.")]
    public async Task<IActionResult> GetAllDevices(CancellationToken cancellationToken)
    {
        var devices = await deviceQueryService.Handle(new GetAllDevicesQuery(), cancellationToken);
        var resources = devices.Select(DeviceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
