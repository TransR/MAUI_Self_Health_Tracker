using MAUI_Self_Health_Tracker.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUI_Self_Health_Tracker.Shared.Data;

public static class SeedData
{
    public sealed class SeedOptions
    {
        public int DaysBack { get; set; } = 60;
        public string Version { get; set; } = "v1";
    }

    public static async Task EnsureSeededAsync(TrackerDbContext db, SeedOptions? options = null)
    {
        options ??= new SeedOptions();
        var sentinelCategory = "__seed__";
        var sentinelKey = options.Version;

        if (await db.LookupItems.AnyAsync(x => x.Category == sentinelCategory && x.Key == sentinelKey))
            return;

        if (!await db.LookupItems.AnyAsync())
        {
            db.LookupItems.AddRange(
                new LookupItem { Category = "FoodUnit", Key = "serving", Value = "serving" },
                new LookupItem { Category = "FoodUnit", Key = "g", Value = "grams" },
                new LookupItem { Category = "Meal", Key = "Breakfast", Value = "Breakfast" },
                new LookupItem { Category = "Meal", Key = "Lunch", Value = "Lunch" },
                new LookupItem { Category = "Meal", Key = "Dinner", Value = "Dinner" },
                new LookupItem { Category = "Activity", Key = "Walk", Value = "Walk" },
                new LookupItem { Category = "Activity", Key = "Bike", Value = "Bike" }
            );
        }

        if (!await db.UserTargets.AnyAsync())
        {
            db.UserTargets.Add(new UserTargets
            {
                DailyCalories = 2000,
                DailyProteinG = 150,
                DailyCarbsG = 180,
                DailyFatG = 70,
                GoalWeightLb = 220
            });
        }

        var rng = new Random(1337);
        decimal Rand(decimal min, decimal max) => min + (decimal)rng.NextDouble() * (max - min);

        var start = DateTime.Today.AddDays(-options.DaysBack);
        var days = Enumerable.Range(0, options.DaysBack + 1).Select(i => start.AddDays(i)).ToList();

        var baseW = 252.0m;
        foreach (var d in days)
        {
            baseW -= 0.05m;
            var w = baseW + Rand(-0.6m, 0.6m);
            db.BodyWeightEntries.Add(new BodyWeightEntry { When = d.AddHours(7), WeightLb = Math.Round(w, 1) });
        }

        foreach (var d in days)
        {
            db.FoodEntries.Add(new FoodEntry { When = d.AddHours(8), Item = "Eggs & Toast", Quantity = 1, Unit = "serving", Calories = 350, ProteinG = 22, CarbsG = 30, FatG = 14, Meal = "Breakfast" });
            db.FoodEntries.Add(new FoodEntry { When = d.AddHours(13), Item = "Chicken Salad", Quantity = 1, Unit = "serving", Calories = 500, ProteinG = 42, CarbsG = 28, FatG = 22, Meal = "Lunch" });
            if (d.Day % 2 == 0)
                db.FoodEntries.Add(new FoodEntry { When = d.AddHours(19), Item = "Grilled Salmon & Veg", Quantity = 1, Unit = "serving", Calories = 650, ProteinG = 48, CarbsG = 35, FatG = 28, Meal = "Dinner" });
        }

        foreach (var d in days.Where((_, i) => i % 2 == 0))
            db.ExerciseEntries.Add(new ExerciseEntry { When = d.AddHours(18), ActivityType = "Walk", Minutes = 40, CaloriesBurned = 200, Rpe = 4 });

        foreach (var d in days)
            db.VitalEntries.Add(new VitalEntry { When = d.AddHours(7), Systolic = 118, Diastolic = 76, HeartRate = 70, SpO2 = 96, TemperatureF = 98.2m });

        foreach (var d in days.Where((_, i) => i % 7 == 0))
        {
            db.LabResults.Add(new LabResult { When = d.AddHours(9), Analyte = "eGFR", Value = 78, Unit = "mL/min/1.73m2" });
            db.LabResults.Add(new LabResult { When = d.AddHours(9), Analyte = "Creatinine", Value = 1.05m, Unit = "mg/dL" });
            db.LabResults.Add(new LabResult { When = d.AddHours(9), Analyte = "BUN", Value = 18, Unit = "mg/dL" });
        }

        db.LookupItems.Add(new LookupItem { Category = sentinelCategory, Key = sentinelKey, Value = DateTime.UtcNow.ToString("u") });

        await db.SaveChangesAsync();
    }
}
