namespace MAUI_Self_Health_Tracker.Shared.Models;

public sealed class LookupItem
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string? Value { get; set; }
}
