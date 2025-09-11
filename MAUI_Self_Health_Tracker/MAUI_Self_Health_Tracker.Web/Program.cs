using MAUI_Self_Health_Tracker.Shared.Services;
using MAUI_Self_Health_Tracker.Web.Components;
using MAUI_Self_Health_Tracker.Web.Services;

// Added usings for EF/DI hookup:
using MAUI_Self_Health_Tracker.Shared.Hosting;
using MAUI_Self_Health_Tracker.Shared.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add device-specific services used by the MAUI_Self_Health_Tracker.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

// Register Shared services (DbContext, etc.). Reads ConnectionStrings:DefaultConnection.
builder.Services.AddSharedServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();

    // Optional but handy in dev: apply pending migrations on startup.
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<TrackerDbContext>();
    db.Database.Migrate();

    // If you want seed data in dev, uncomment:
    // await SeedData.InitializeAsync(db, app.Logger);
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(MAUI_Self_Health_Tracker.Shared._Imports).Assembly,
        typeof(MAUI_Self_Health_Tracker.Web.Client._Imports).Assembly);

app.Run();
