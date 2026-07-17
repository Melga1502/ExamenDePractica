using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

/// <summary>
///     Entity Framework Core implementation of the unit of work pattern.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    /// <inheritdoc />
    public async Task CompleteAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}
