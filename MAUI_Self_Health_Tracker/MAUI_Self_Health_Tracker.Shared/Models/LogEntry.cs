namespace MAUI_Self_Health_Tracker.Shared.Models;

public abstract class LogEntry
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTimeOffset When { get; set; }
    public string? Note { get; set; }
    public List<string> Tags { get; set; } = new();
}
