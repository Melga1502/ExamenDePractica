using Microsoft.EntityFrameworkCore;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.Aggregates;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

/// <summary>
///     Provides Entity Framework Core configuration for the Telemetry bounded context.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public static class ModelBuilderExtensions
{
    /// <summary>
    ///     Applies Telemetry model configuration.
    /// </summary>
    /// <param name="builder">Model builder used by Entity Framework Core.</param>
    public static void ApplyTelemetryConfiguration(this ModelBuilder builder)
    {
        builder.Entity<TelemetryDataRecord>(entity =>
        {
            entity.HasKey(record => record.Id);
            entity.Property(record => record.Id).ValueGeneratedOnAdd();
            entity.Property(record => record.DeviceId).IsRequired();
            entity.Property(record => record.RecordedAt).IsRequired();
            entity.Property(record => record.CreatedAt).IsRequired(false);
            entity.Property(record => record.UpdatedAt).IsRequired(false);

            entity.OwnsOne(record => record.VitalSignData, owned =>
            {
                owned.WithOwner().HasForeignKey("Id");
                owned.Property<long>("Id").HasColumnName("id");
                owned.HasKey("Id");
                owned.Property(value => value.HeartRate).IsRequired();
                owned.Property(value => value.RespiratoryRate).IsRequired();
            });

            entity.OwnsOne(record => record.DeviceHealthData, owned =>
            {
                owned.WithOwner().HasForeignKey("Id");
                owned.Property<long>("Id").HasColumnName("id");
                owned.HasKey("Id");
                owned.Property(value => value.BatteryLevel).IsRequired();
                owned.Property(value => value.DeviceStatus).IsRequired().HasMaxLength(40);
            });
        });
    }
}
