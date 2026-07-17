namespace Whoop.HardwareTelemetry.Platform.u202315165.Telemetry.Domain.Model.ValueObjects;

/// <summary>
///     Wearable vital sign values.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public record VitalSignData
{
    public int HeartRate { get; init; }
    public int RespiratoryRate { get; init; }

    private VitalSignData()
    {
    }

    /// <summary>
    ///     Creates and validates vital sign data.
    /// </summary>
    /// <param name="heartRate">Heart rate value.</param>
    /// <param name="respiratoryRate">Respiratory rate value.</param>
    public VitalSignData(int heartRate, int respiratoryRate)
    {
        if (heartRate <= 0) throw new ArgumentOutOfRangeException(nameof(heartRate), "Heart rate must be positive.");
        if (respiratoryRate <= 0)
            throw new ArgumentOutOfRangeException(nameof(respiratoryRate), "Respiratory rate must be positive.");

        HeartRate = heartRate;
        RespiratoryRate = respiratoryRate;
    }
}
