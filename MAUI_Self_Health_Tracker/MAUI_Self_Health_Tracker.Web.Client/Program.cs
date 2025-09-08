using MAUI_Self_Health_Tracker.Shared.Services;
using MAUI_Self_Health_Tracker.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the MAUI_Self_Health_Tracker.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
