using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Swashbuckle.AspNetCore.Annotations;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Application.Model;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Resources.Errors;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Application.CommandServices;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Errors;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Resources;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Transform;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest;

/// <summary>
///     REST controller for telemetry data records.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
[ApiController]
[Route("api/v1/[controller]")]
public class TelemetryDataRecordsController(
    ITelemetryDataRecordCommandService telemetryDataRecordCommandService,
    IStringLocalizer<ErrorMessages> localizer)
    : ControllerBase
{
    /// <summary>
    ///     Creates a telemetry data record.
    /// </summary>
    /// <param name="resource">Request resource.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The created telemetry data record.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a telemetry data record",
        Description = "Creates a telemetry data record after checking device authorization through the hardware context.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Telemetry data record created successfully.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data.")]
    [SwaggerResponse(StatusCodes.Status403Forbidden, "Device authorization failed.")]
    public async Task<IActionResult> CreateTelemetryDataRecord(
        [FromBody] CreateTelemetryDataRecordResource resource,
        CancellationToken cancellationToken)
    {
        try
        {
            var command = CreateTelemetryDataRecordCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await telemetryDataRecordCommandService.Handle(command, cancellationToken);
            return TelemetryActionResultAssembler.ToActionResultFromCreateTelemetryDataRecordResult(result);
        }
        catch (FormatException)
        {
            var message = localizer["Telemetry.InvalidDateFormat"];
            var result = Result<TelemetryDataRecord>.Failure(
                TelemetryError.InvalidDateFormat,
                message.ResourceNotFound ? "RecordedAt must use the format yyyy-MM-dd HH:mm:ss." : message.Value);
            return TelemetryActionResultAssembler.ToActionResultFromCreateTelemetryDataRecordResult(result);
        }
    }
}
