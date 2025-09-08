namespace MAUI_Self_Health_Tracker.Shared.Models;

public sealed class UserTargets
{
    public int Id { get; set; }
    public decimal? DailyCalories { get; set; }
    public decimal? DailyProteinG { get; set; }
    public decimal? DailyCarbsG { get; set; }
    public decimal? DailyFatG { get; set; }
    public decimal? GoalWeightLb { get; set; }
}
