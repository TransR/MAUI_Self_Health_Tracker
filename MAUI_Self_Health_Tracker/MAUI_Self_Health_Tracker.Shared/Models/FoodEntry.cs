namespace MAUI_Self_Health_Tracker.Shared.Models;

public sealed class FoodEntry : LogEntry
{
    public string Item { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = "serving";
    public decimal? Calories { get; set; }
    public decimal? ProteinG { get; set; }
    public decimal? CarbsG { get; set; }
    public decimal? FatG { get; set; }
    public string? Meal { get; set; }
}
