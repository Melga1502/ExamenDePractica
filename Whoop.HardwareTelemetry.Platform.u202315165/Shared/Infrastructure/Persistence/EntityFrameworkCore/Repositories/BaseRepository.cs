using Microsoft.EntityFrameworkCore;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

/// <summary>
///     Entity Framework Core base repository.
/// </summary>
/// <typeparam name="TEntity">Entity type handled by the repository.</typeparam>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext Context = context;

    /// <inheritdoc />
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TEntity?> FindByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().FindAsync([id], cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    /// <inheritdoc />
    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}
