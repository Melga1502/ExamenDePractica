using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

/// <summary>
///     Provides database naming conventions for Entity Framework Core.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies plural table names and snake_case column names.
    /// </summary>
    /// <param name="builder">Model builder used by Entity Framework Core.</param>
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            if (!entity.IsOwned())
                entity.SetTableName(entity.GetTableName()?.Pluralize().Underscore());

            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.GetColumnName().Underscore());

            if (entity.IsOwned()) continue;

            foreach (var key in entity.GetKeys())
                key.SetName(key.GetName()?.Underscore());
            
            foreach (var foreignKey in entity.GetForeignKeys())
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.Underscore());

            foreach (var index in entity.GetIndexes())
                index.SetDatabaseName(index.GetDatabaseName()?.Underscore());
        }
    }
}
