namespace MAUI_Self_Health_Tracker.Shared.Models;

public sealed class MedicationEntry : LogEntry
{
    public string Name { get; set; } = string.Empty;
    public string Dose { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public bool Taken { get; set; }
}
