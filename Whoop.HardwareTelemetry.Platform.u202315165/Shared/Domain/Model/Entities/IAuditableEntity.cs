namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Model.Entities;

/// <summary>
///     Contract for aggregate roots that store audit timestamps.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public interface IAuditableEntity
{
    DateTimeOffset? CreatedAt { get; set; }
    DateTimeOffset? UpdatedAt { get; set; }
}
