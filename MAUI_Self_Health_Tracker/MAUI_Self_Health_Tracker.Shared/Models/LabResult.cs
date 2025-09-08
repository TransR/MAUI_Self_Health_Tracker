namespace MAUI_Self_Health_Tracker.Shared.Models;

public sealed class LabResult : LogEntry
{
    public string Analyte { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string? ReferenceRange { get; set; }
}
