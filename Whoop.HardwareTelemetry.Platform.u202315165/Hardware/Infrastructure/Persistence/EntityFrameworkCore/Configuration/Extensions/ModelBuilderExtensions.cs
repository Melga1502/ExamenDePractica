using Microsoft.EntityFrameworkCore;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Entities;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

/// <summary>
///     Provides Entity Framework Core configuration for the Hardware bounded context.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies Hardware model configuration.
    /// </summary>
    /// <param name="builder">Model builder used by Entity Framework Core.</param>
    public static void ApplyHardwareConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Device>(entity =>
        {
            entity.HasKey(device => device.Id);
            entity.Property(device => device.Id).ValueGeneratedOnAdd();
            entity.Property(device => device.SerialNumber).IsRequired().HasMaxLength(30);
            entity.HasIndex(device => device.SerialNumber).IsUnique();
            entity.Property(device => device.Model).IsRequired().HasMaxLength(30);
            entity.Property(device => device.Status).IsRequired().HasConversion<int>();
            entity.Property(device => device.LastSyncDate).IsRequired(false);
            entity.Property(device => device.CreatedAt).IsRequired(false);
            entity.Property(device => device.UpdatedAt).IsRequired(false);
        });

        builder.Entity<ProcessedTelemetryRecord>(entity =>
        {
            entity.HasKey(record => record.Id);
            entity.Property(record => record.Id).ValueGeneratedOnAdd();
            entity.Property(record => record.RecordId).IsRequired();
            entity.HasIndex(record => record.RecordId).IsUnique();
        });
    }
}
