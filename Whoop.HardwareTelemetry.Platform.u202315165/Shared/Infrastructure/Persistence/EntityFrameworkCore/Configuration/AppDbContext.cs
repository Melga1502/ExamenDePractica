using Microsoft.EntityFrameworkCore;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

/// <summary>
///     Database context for the WHOOP Hardware Telemetry Platform.
/// </summary>
/// <param name="options">Database context configuration options.</param>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(optionsBuilder);
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyHardwareConfiguration();
        builder.ApplyTelemetryConfiguration();
        builder.UseSnakeCaseNamingConvention();
    }
}
