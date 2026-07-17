using Cortex.Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Interfaces.Acl;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Application.Model;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Model.Events;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Resources.Errors;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Application.CommandServices;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Commands;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Errors;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Repositories;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Application.Internal.CommandServices;

/// <summary>
///     Application service for telemetry data record commands.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class TelemetryDataRecordCommandService(
    ITelemetryDataRecordRepository telemetryDataRecordRepository,
    IHardwareContextFacade hardwareContextFacade,
    IUnitOfWork unitOfWork,
    IMediator mediator,
    IStringLocalizer<ErrorMessages> localizer)
    : ITelemetryDataRecordCommandService
{
    /// <inheritdoc />
    public async Task<Result<TelemetryDataRecord>> Handle(
        CreateTelemetryDataRecordCommand command,
        CancellationToken cancellationToken)
    {
        try
        {
            var isAuthorized = await hardwareContextFacade
                .IsDeviceAuthorizedForTelemetryAsync(command.DeviceId, cancellationToken);

            if (!isAuthorized)
                return Result<TelemetryDataRecord>.Failure(
                    TelemetryError.DeviceAuthorizationFailed,
                    localizer["Telemetry.DeviceAuthorizationFailed"]);

            var telemetryDataRecord = new TelemetryDataRecord(command);
            await telemetryDataRecordRepository.AddAsync(telemetryDataRecord, cancellationToken);
            await unitOfWork.CompleteAsync(cancellationToken);

            await mediator.PublishAsync(
                new TelemetryProcessedEvent(
                    telemetryDataRecord.Id,
                    telemetryDataRecord.DeviceId,
                    telemetryDataRecord.RecordedAt),
                cancellationToken);

            return Result<TelemetryDataRecord>.Success(telemetryDataRecord);
        }
        catch (ArgumentException exception)
        {
            return Result<TelemetryDataRecord>.Failure(TelemetryError.InvalidRecordedAt, exception.Message);
        }
        catch (DbUpdateException)
        {
            return Result<TelemetryDataRecord>.Failure(
                TelemetryError.DatabaseError,
                localizer["Telemetry.DatabaseError"]);
        }
        catch (Exception)
        {
            return Result<TelemetryDataRecord>.Failure(
                TelemetryError.InternalServerError,
                localizer["Telemetry.InternalServerError"]);
        }
    }
}
