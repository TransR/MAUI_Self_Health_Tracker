using MAUI_Self_Health_Tracker.Services;
using MAUI_Self_Health_Tracker.Shared.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using System;
using System.Net.Http;

namespace MAUI_Self_Health_Tracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Device/form-factor service consumed by the Shared RCL
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            // Hybrid BlazorWebView host
            builder.Services.AddMauiBlazorWebView();

            // Optional: handy when the hybrid app wants to call your server.
            // You can replace the BaseAddress with your dev server later.
            builder.Services.AddSingleton(new HttpClient
            {
                // For local hybrid scenarios, you’ll point this to your Web API if/when you add one.
                BaseAddress = new Uri("https://localhost:5001/")
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
            builder.Logging.AddFilter("Microsoft.AspNetCore.Components", LogLevel.Information);
            builder.Logging.AddFilter("Microsoft.AspNetCore.Hosting", LogLevel.Information);
#endif

            return builder.Build();
        }
    }
}
