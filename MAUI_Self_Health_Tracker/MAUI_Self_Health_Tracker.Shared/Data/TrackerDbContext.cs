using MAUI_Self_Health_Tracker.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUI_Self_Health_Tracker.Shared.Data;

public sealed class TrackerDbContext : DbContext
{
    public TrackerDbContext(DbContextOptions<TrackerDbContext> options) : base(options) {}

    public DbSet<FoodEntry> FoodEntries => Set<FoodEntry>();
    public DbSet<BodyWeightEntry> BodyWeightEntries => Set<BodyWeightEntry>();
    public DbSet<ExerciseEntry> ExerciseEntries => Set<ExerciseEntry>();
    public DbSet<VitalEntry> VitalEntries => Set<VitalEntry>();
    public DbSet<LabResult> LabResults => Set<LabResult>();
    public DbSet<MedicationEntry> MedicationEntries => Set<MedicationEntry>();
    public DbSet<LookupItem> LookupItems => Set<LookupItem>();
    public DbSet<UserTargets> UserTargets => Set<UserTargets>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<FoodEntry>().HasKey(x => x.Id);
        b.Entity<BodyWeightEntry>().HasKey(x => x.Id);
        b.Entity<ExerciseEntry>().HasKey(x => x.Id);
        b.Entity<VitalEntry>().HasKey(x => x.Id);
        b.Entity<LabResult>().HasKey(x => x.Id);
        b.Entity<MedicationEntry>().HasKey(x => x.Id);
        b.Entity<LookupItem>().HasIndex(x => new { x.Category, x.Key }).IsUnique();
        b.Entity<UserTargets>().HasKey(x => x.Id);

        b.Entity<FoodEntry>().HasIndex(x => x.When);
        b.Entity<BodyWeightEntry>().HasIndex(x => x.When);
        b.Entity<ExerciseEntry>().HasIndex(x => x.When);
        b.Entity<VitalEntry>().HasIndex(x => x.When);
        b.Entity<LabResult>().HasIndex(x => new { x.Analyte, x.When });

        b.Entity<FoodEntry>().Property(x => x.Quantity).HasPrecision(10, 2);
        b.Entity<FoodEntry>().Property(x => x.Calories).HasPrecision(10, 2);
        b.Entity<FoodEntry>().Property(x => x.ProteinG).HasPrecision(10, 2);
        b.Entity<FoodEntry>().Property(x => x.CarbsG).HasPrecision(10, 2);
        b.Entity<FoodEntry>().Property(x => x.FatG).HasPrecision(10, 2);

        b.Entity<BodyWeightEntry>().Property(x => x.WeightLb).HasPrecision(10, 2);
        b.Entity<BodyWeightEntry>().Property(x => x.BodyFatPct).HasPrecision(5, 2);

        b.Entity<LabResult>().Property(x => x.Value).HasPrecision(12, 4);
    }
}
