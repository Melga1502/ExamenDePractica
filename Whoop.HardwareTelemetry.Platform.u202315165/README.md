# WHOOP Hardware Telemetry Platform API

RESTful API for managing WHOOP device telemetry under a Domain-Driven Design approach.

## Author

Josep Eliu Melgarejo Quiroz  
Student code: u202315165  
NRC: 12206

## Technologies

- C# 14
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Cortex.Mediator
- Swashbuckle OpenAPI
- Localization with `.resx` resources

## Architecture

The solution follows a layered and bounded-context organization inspired by the Learning Center Platform reference project.

Implemented bounded contexts:

- `Hardware`: manages WHOOP devices and authorization for telemetry transmission.
- `Telemetry`: manages telemetry data records received from devices.
- `Shared`: provides common infrastructure such as repositories, Unit of Work, auditing, events, localization and persistence conventions.

## Database

The API uses MySQL with the schema:

```text
whoop
```

Connection string example:

```json
"DefaultConnection": "server=localhost;user=root;password=password;database=whoop"
```

Before running migrations, create the database if it does not exist:

```sql
CREATE DATABASE whoop;
```

## Seeding

The application configures EF Core seeding for the initial WHOOP devices:

- `SN-9001`
- `SN-9002`
- `SN-9003`
- `SN-9004`
- `SN-9005`

## Integration Event

When a valid telemetry record is created, the Telemetry context publishes `TelemetryProcessedEvent`.

The Hardware context handles the event, checks idempotency by `RecordId`, and updates the device `LastSyncDate`.

## Run

Restore and build:

```bash
dotnet restore
dotnet build
```

Apply migrations:

```bash
dotnet ef database update
```

Run the API:

```bash
dotnet run --project Whoop.HardwareTelemetry.Platform.u202315165
```

## Endpoints

### Create Telemetry Data Record

```http
POST /api/v1/telemetry-data-records
```

Request:

```json
{
  "deviceId": 1,
  "heartRate": 72,
  "respiratoryRate": 16,
  "batteryLevel": 88,
  "deviceStatus": "NORMAL",
  "recordedAt": "2026-07-17 14:45:00"
}
```

Success response:

```json
{
  "id": 1,
  "deviceId": 1,
  "heartRate": 72,
  "respiratoryRate": 16,
  "batteryLevel": 88,
  "deviceStatus": "NORMAL",
  "recordedAt": "2026-07-17T19:45:00Z"
}
```

### Get Devices

```http
GET /api/v1/devices
```

Success response:

```json
[
  {
    "id": 1,
    "serialNumber": "SN-9001",
    "model": "WHOOP-5.0",
    "status": "Active",
    "lastSyncDate": null
  }
]
```
