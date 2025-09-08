namespace MAUI_Self_Health_Tracker.Shared.Models;

public sealed class ExerciseEntry : LogEntry
{
    public string ActivityType { get; set; } = string.Empty;
    public int Minutes { get; set; }
    public decimal? CaloriesBurned { get; set; }
    public int? Rpe { get; set; }
}
