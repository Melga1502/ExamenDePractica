using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Application.Model;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Commands;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Application.CommandServices;

/// <summary>
///     Defines telemetry data record command operations.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface ITelemetryDataRecordCommandService
{
    /// <summary>
    ///     Handles telemetry data record creation.
    /// </summary>
    /// <param name="command">Command with telemetry data.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The created telemetry data record or an error.</returns>
    Task<Result<TelemetryDataRecord>> Handle(CreateTelemetryDataRecordCommand command, CancellationToken cancellationToken);
}
