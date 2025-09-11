using MAUI_Self_Health_Tracker.Shared.Services;
using MAUI_Self_Health_Tracker.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MAUI_Self_Health_Tracker.Web.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // Device/form-factor service used by the Shared RCL
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            // Optional: if/when you call server APIs from WASM,
            // this gives you a base-addressed HttpClient.
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            await builder.Build().RunAsync();
        }
    }
}
