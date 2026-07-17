namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Repositories;

/// <summary>
///     Defines common repository operations.
/// </summary>
/// <typeparam name="TEntity">Entity type handled by the repository.</typeparam>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface IBaseRepository<TEntity>
{
    /// <summary>
    ///     Adds an entity to the persistence context.
    /// </summary>
    /// <param name="entity">Entity to add.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Finds an entity by id.
    /// </summary>
    /// <param name="id">Entity identifier.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The entity if found; otherwise null.</returns>
    Task<TEntity?> FindByIdAsync(long id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lists all entities.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>All stored entities.</returns>
    Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Marks an entity as updated.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    void Update(TEntity entity);

    /// <summary>
    ///     Removes an entity.
    /// </summary>
    /// <param name="entity">Entity to remove.</param>
    void Remove(TEntity entity);
}
