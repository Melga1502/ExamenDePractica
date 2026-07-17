using System.Text.Json.Nodes;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;
using Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.Resources;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Interfaces.Rest.OpenApi;

/// <summary>
///     Adds a valid Swagger example for telemetry data record creation.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class CreateTelemetryDataRecordSchemaFilter : ISchemaFilter
{
    /// <summary>
    ///     Applies the request example to the telemetry creation schema.
    /// </summary>
    /// <param name="schema">Generated OpenAPI schema.</param>
    /// <param name="context">Schema filter context.</param>
    public void Apply(IOpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type != typeof(CreateTelemetryDataRecordResource)) return;
        if (schema is not OpenApiSchema openApiSchema) return;

        openApiSchema.Example = new JsonObject
        {
            ["deviceId"] = 1,
            ["heartRate"] = 72,
            ["respiratoryRate"] = 16,
            ["batteryLevel"] = 88,
            ["deviceStatus"] = "NORMAL",
            ["recordedAt"] = "2026-07-17 14:45:00"
        };
    }
}
