namespace MAUI_Self_Health_Tracker.Shared.Models;

public sealed class BodyWeightEntry : LogEntry
{
    public decimal WeightLb { get; set; }
    public decimal? BodyFatPct { get; set; }
    public string Source { get; set; } = "Omron BCM-500";
}
