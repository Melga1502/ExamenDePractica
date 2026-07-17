using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Application.Internal.EventHandlers;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Model.Events;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Repositories;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Application.Internal.EventHandlers;

/// <summary>
///     Handles telemetry processed events and updates device synchronization data.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class TelemetryProcessedEventHandler(
    IDeviceRepository deviceRepository,
    IProcessedTelemetryRecordRepository processedTelemetryRecordRepository,
    IUnitOfWork unitOfWork)
    : IEventHandler<TelemetryProcessedEvent>
{
    /// <inheritdoc />
    public async Task Handle(TelemetryProcessedEvent notification, CancellationToken cancellationToken)
    {
        if (await processedTelemetryRecordRepository.ExistsByRecordIdAsync(notification.RecordId, cancellationToken))
            return;

        var device = await deviceRepository.FindByIdAsync(notification.DeviceId, cancellationToken);
        if (device is null) return;

        device.UpdateLastSyncDate(notification.RecordedAt);
        deviceRepository.Update(device);
        await processedTelemetryRecordRepository.AddAsync(notification.RecordId, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
    }
}
