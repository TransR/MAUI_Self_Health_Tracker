using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MAUI_Self_Health_Tracker.Shared.Data
{
    // Enables `dotnet ef` to create the DbContext for migrations without launching your Web host.
    public sealed class TrackerDbContextFactory : IDesignTimeDbContextFactory<TrackerDbContext>
    {
        public TrackerDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var connectionString =
                config.GetConnectionString("DefaultConnection")
                ?? "Server=(localdb)\\MSSQLLocalDB;Database=SelfHealthTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";

            var options = new DbContextOptionsBuilder<TrackerDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new TrackerDbContext(options);
        }
    }
}
