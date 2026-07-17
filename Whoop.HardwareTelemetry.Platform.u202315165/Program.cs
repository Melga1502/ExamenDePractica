using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.Extensions.Localization;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.Aggregates;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Model.ValueObjects;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Application.Acl;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Application.Internal.QueryServices;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Application.QueryServices;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Hardware.Interfaces.Acl;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Application.CommandServices;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Application.Internal.CommandServices;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.OpenApi;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Resources.Errors;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Domain.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Interfaces.AspNetCore.Configuration;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Pipeline.Middleware.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()))
    .AddDataAnnotationsLocalization();
builder.Services.AddProblemDetails();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddSingleton<IStringLocalizer<ErrorMessages>, StringLocalizer<ErrorMessages>>();

builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (string.IsNullOrWhiteSpace(connectionString))
        throw new InvalidOperationException("Database connection string is not configured.");

    options.UseMySQL(connectionString)
        .UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>())
        .EnableDetailedErrors()
        .UseSeeding((context, _) =>
        {
            if (context.Set<Device>().Any()) return;

            context.Set<Device>().AddRange(
                new Device(1, "SN-9001", "WHOOP-5.0", EDeviceStatus.Active),
                new Device(2, "SN-9002", "WHOOP-5.0", EDeviceStatus.Active),
                new Device(3, "SN-9003", "WHOOP-4.0", EDeviceStatus.Inactive),
                new Device(4, "SN-9004", "WHOOP-5.0", EDeviceStatus.Active),
                new Device(5, "SN-9005", "WHOOP-MG", EDeviceStatus.Active)
            );
            context.SaveChanges();
        })
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            if (await context.Set<Device>().AnyAsync(cancellationToken)) return;

            await context.Set<Device>().AddRangeAsync(
            [
                new Device(1, "SN-9001", "WHOOP-5.0", EDeviceStatus.Active),
                new Device(2, "SN-9002", "WHOOP-5.0", EDeviceStatus.Active),
                new Device(3, "SN-9003", "WHOOP-4.0", EDeviceStatus.Inactive),
                new Device(4, "SN-9004", "WHOOP-5.0", EDeviceStatus.Active),
                new Device(5, "SN-9005", "WHOOP-MG", EDeviceStatus.Active)
            ], cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        });

    if (builder.Environment.IsDevelopment()) options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IProcessedTelemetryRecordRepository, ProcessedTelemetryRecordRepository>();
builder.Services.AddScoped<ITelemetryDataRecordRepository, TelemetryDataRecordRepository>();
builder.Services.AddScoped<IDeviceQueryService, DeviceQueryService>();
builder.Services.AddScoped<IHardwareContextFacade, HardwareContextFacade>();
builder.Services.AddScoped<ITelemetryDataRecordCommandService, TelemetryDataRecordCommandService>();
builder.Services.AddCortexMediator([typeof(Program)]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WHOOP Hardware Telemetry Platform API",
        Version = "v1",
        Description = "RESTful API for WHOOP hardware inventory and telemetry records.",
        Contact = new OpenApiContact
        {
            Name = "Josep Eliu Melgarejo Quiroz"
        }
    });
    options.EnableAnnotations();
    options.SchemaFilter<CreateTelemetryDataRecordSchemaFilter>();
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.UseGlobalExceptionHandler();

var supportedCultures = new[] { "en", "en-US", "es", "es-PE" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
