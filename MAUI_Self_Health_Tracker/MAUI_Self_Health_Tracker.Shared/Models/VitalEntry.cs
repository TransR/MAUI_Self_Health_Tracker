namespace MAUI_Self_Health_Tracker.Shared.Models;

public sealed class VitalEntry : LogEntry
{
    public int? Systolic { get; set; }
    public int? Diastolic { get; set; }
    public int? HeartRate { get; set; }
    public int? SpO2 { get; set; }
    public decimal? TemperatureF { get; set; }
}
