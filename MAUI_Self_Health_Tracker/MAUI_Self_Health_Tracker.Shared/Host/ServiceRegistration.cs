using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MAUI_Self_Health_Tracker.Shared.Data;

namespace MAUI_Self_Health_Tracker.Shared.Hosting
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddSharedServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? "Server=(localdb)\\MSSQLLocalDB;Database=SelfHealthTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";

            services.AddDbContext<TrackerDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register domain/services later here, e.g.:
            // services.AddScoped<IWhateverService, WhateverService>();

            return services;
        }
    }
}
