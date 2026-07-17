namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Repositories;

/// <summary>
///     Represents the unit of work contract for saving pending persistence changes.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface IUnitOfWork
{
    /// <summary>
    ///     Saves all pending changes in the current persistence context.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    Task CompleteAsync(CancellationToken cancellationToken = default);
}
