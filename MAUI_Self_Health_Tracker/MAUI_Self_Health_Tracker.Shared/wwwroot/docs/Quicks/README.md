# The **Self Health®** _**InCareSys**_

The **Self Health®** _**InCareSys**_ is an Enterprise-Level Multi-Platform Application Suite that demonstrates how to unify disparate technologies under one cohesive, scalable, and maintainable ecosystem, closing an often unseen critical gap between front-end dynamism and back-end security. 

Independent Care Systems Inc (ICSI)
Take charge of your healthcare with Self Health® Products and Services!


Save Money, Improve Quality Of Care With Self Health® Products and Services

Accurate and secure personal healthcare information with Self Health®, any time, any where, on virtually any device!

---

## **Step-by-Step Development Self Health® _**InCareSys**_:**

> [!WARNING]
> You are currently viewing the **Step-by-Step **Self Health®** _**InCareSys**_ Development** of the **Jason Silvestri Open Project EXperiences (JSopX™) Project**. 
> 
> For more details, see [Getting Started](#getting-started) _below_.

---


```bash
# For The Cool Kids: Clone JSopX.AspNetCore Git Repository
$ git clone https://github.com/JasonSilvestri/JSopX.OpenProjectX.git
```

---

[`Home`](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/README.md) » [`Introduction`](../../../../Introduction/) » [`Projects`](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/OpenProjects/) · · [`Use Latest`](../../../../OpenProjects/jsopx.OpenProjectX/README.md) · [`By-Phase`](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/README.md) · **`From Scratch`** · · [`« Previous`](../../../../OpenProjects/jsopx.ClassLibrary/p1/v1/RECREATEME.md) [`Next »`](../../../../OpenProjects/jsopx.AspNetCore/p1/v1/RECREATEME.md)

---


  
## Table of Contents

  - [Overview](#overview)
  - [Prerequisites](#prerequisites)
  - [Getting Started](#getting-started)
      - [Step 1: Recreate Using ASP.NET Core Blazor Template](#step-1-recreate-using-aspnet-core-blazor-template)
      - [Step 2: Extend Weather Data](#step-2-extend-weather-data)
      - [Step 3: Integrate OIDC](#step-3-integrate-oidc)
      - [Step 4: Decouple from Built-In API](#step-4-decouple-from-built-in-api)
      - [Step 5: Standardize with RCLs and Libraries](#step-5-standardize-with-rcls-and-libraries)
  - [Next Steps](#next-steps)
  
---

## Current Phase

> [!IMPORTANT]
>
>**Phases 1**: This document is currently aligned with [Phase 1: Minimum Viable Product (MVP)](../../../../../../Phases/Phase-1.md) Business Requirements. 
> 

---

> [!CAUTION]
> **This is a DRAFT:**
> 
> The content before you is a draft version of the document. It **should not** be considered **accurate** and may contain placeholder information.

---

## Overview

**Jason Silvestri Open Project EXperiences (JSopX™)** is an Enterprise-Level Suite of Multi-Platform, Multi-Stack Applications that demonstrates how to unify disparate technologies under one cohesive, scalable, and maintainable ecosystem, closing an often unseen critical gap between front-end dynamism and back-end security. 

Balancing client-side and server-side operations has become increasingly challenging in today's web development landscape. With the rise of powerful client-side JavaScript frameworks, many developers have gravitated towards these technologies, often at the expense of robust server-side security and best practices. This trend has led to significant concerns and vulnerabilities that need to be addressed to build secure, scalable, and maintainable applications.

JSopX™ provides a unified framework of guidelines, organizational structures, and best practices designed to streamline project setup, enhance collaboration, and improve maintainability. 

By aligning varied frameworks—ranging from [ASP.NET Core](../../../../OpenProjects/jsopx.AspNetCore/README.md) to [Angular](../../../../OpenProjects/jsopx.AngularCore/README.md), [Vue](../../../../OpenProjects/jsopx.VueCore/README.md), [React](../../../../OpenProjects/jsopx.ReactCore/README.md), [Blazor](../../../../OpenProjects/jsopx.BlazorServerCore/README.md), [MAUI](../../../../OpenProjects/jsopx.OpenProjectX/README.md) and more, all using the same [Web API](../../../../OpenProjects/jsopx.WebAPI/README.md), [assets](../../../../OpenProjects/jsopx.RCLxProper/README.md), [documentation](../../../../OpenProjects/jsopx.BridgeTooFar/README.md), and [standards](../../../../Introduction/JSopxDevelopmentStandards.md)—these projects create a consistent development landscape where code can be shared, extended, and integrated seamlessly, bridging-of-the-critical-gap, between front-end dynamism and back-end security.  Most importantly, it is proof it is possible for developers like us to develop enterprise level applications that takes no more time than your average 9-12 project, while gaining an enormus advantage in the long run.

As the project evolves through each [Lifecycle Phase](../../../../Phases/ReadMe.md), we extend the application by creating new user interfaces, the integratation of standardized assets and resources commonly used across projects that comply to the stakeholder's brand standards we are tasked with creating, perform typical increase of security and documentation, and much more! 

[`Back to Top`](#table-of-contents)

---

## **Prerequisites**

Be sure each technology is installed, with proper versioning, if your goal is to continue exploring and/or installing the `JSopX.OpenProjectX` Project.

- [Visual Studio (v 17.14.11)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#visual-studio)
- [.NET Framework (v 9.0.1)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#net-framework)
- [ASP.NET Core (v 9.0.1)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#aspnet-core)
- [.NET Core Blazor (v 9.0.1)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#net-core-blazor)
- [.Net Core Maui Hybrid (v 9.0.1)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#net-core-maui-hybrid)
- [Node (v 20.14.0)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#node)
- [npm (v 10.8.1)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#npm)
- [Angular CLI (v 18.0.3)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#angular-cli)
- [React (v 18.2.0)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#react)
- [Vue (v 3.4.21)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#vue)
- [Vite (v 5.2.8)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#vite)
- [Bash (v 5.x+)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#bash)
- [Powershell (v 7.x+)](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/Technologies/#powershell)

---

## **Getting Started**

Carefully _choose_ the variant approach below that fits your current objective:

---

### 1. **Continue Creating `JSopX.`OpenProjectX From Scratch**:

- **[Continue](#step-1-recreate-using-aspnet-core-blazor-template)** → **Continue** as **you were**, **creating projects** from scratch, step-by-step, using the `JSopX.OpenProjectX` _From Scratch_ Variant.   

---

### 2. **Use Different Variant**:

- **[Install Using Latest](../../../../OpenProjects/jsopx.OpenProjectX/README.md)** → **Install** or **explore** the latest version of **this project**, using the `JSopX.OpenProjectX` _Using Latest_ Variant.  
- **[Browse By-Phase](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/README.md)** → **Browse** **previous versions** of the application by **phases** using the `JSopX.OpenProjectX` _By-Phase_ Variant.   
- **[Get All Projects](../../../../OpenProjects/jsopx.OpenProjectX/README.md)** → **Get all projects** instead, using the `JSopX.OpenProjectX` Enterprise Application.

---


## Step 1: Recreate Using .NET MAUI Blazor Hybrid Template

**Goal**: Simulate an existing MAUI Hybrid app with weather data, Identity, and JWT already in place.

1. **Open Visual Studio 2022 (v 17.14.11)**:
   - Ensure the .NET 9.0 SDK is installed (`dotnet --list-sdks`).

2. **Create the Project**:
   - File > New > Project.
   - Search for “.NET MAUI Blazor Hybrid App”.
   - Configure:
     - Project Name: `JSopX.OpenProjectX`.
     - Location: e.g., `path\to\local\repo\JasonSilvestri\JSopX.OpenProjectX`.
     - Solution Name: `JSopX.OpenProjectX`.
     - .NET Framework (v 9.0.1)
   - Click Create.

3. **Set Up Initial Weather Data**:
   - In `Components/Pages/Home.razor`, replace the counter with a weather display:

     ```razor
     @page "/"
     @inject HttpClient Http
     <h1>JSopX™ Weather</h1>
     @if (forecasts == null)
     {
         <p>Loading...</p>
     }
     else
     {
         <table>
             <thead>
                 <tr><th>Date</th><th>Temp (°C)</th><th>Summary</th></tr>
             </thead>
             <tbody>
                 @foreach (var forecast in forecasts)
                 {
                     <tr>
                         <td>@forecast.Date.ToShortDateString()</td>
                         <td>@forecast.TemperatureC</td>
                         <td>@forecast.Summary</td>
                     </tr>
                 }
             </tbody>
         </table>
     }
     @code {
         private WeatherForecast[] forecasts;
         protected override async Task OnInitializedAsync()
         {
             forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
         }
         public class WeatherForecast
         {
             public DateTime Date { get; set; }
             public int TemperatureC { get; set; }
             public string Summary { get; set; }
         }
     }
     ```
   - This uses the default `weather.json` in `wwwroot/sample-data`.

4. **Add Identity + JWT (Simulating Existing Setup)**:
   - Install NuGet packages: `Microsoft.AspNetCore.Identity.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.AspNetCore.Authentication.JwtBearer`.
   - Add `Models/ApplicationUser.cs`:

     ```csharp
     using Microsoft.AspNetCore.Identity;
     public class ApplicationUser : IdentityUser { }
     ```
   - Add `Data/AppDbContext.cs`:

     ```csharp
     using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
     using Microsoft.EntityFrameworkCore;
     public class AppDbContext : IdentityDbContext<ApplicationUser>
     {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
     }
     ```
   - Update `MauiProgram.cs`:

     ```csharp
     builder.Services.AddDbContext<AppDbContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
     builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
         .AddEntityFrameworkStores<AppDbContext>()
         .AddDefaultTokenProviders();
     builder.Services.AddAuthentication().AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = builder.Configuration["Jwt:Issuer"],
             ValidAudience = builder.Configuration["Jwt:Audience"],
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
         };
     });
     builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7234/") }); // Temp API URL
     ```
   - Update `appsettings.json`:

     ```json
     {
       "ConnectionStrings": { "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=JSopXMauiDb;Trusted_Connection=True;" },
       "Jwt": { "Key": "8f+2Kj9mPqL5xRtYvWnZcQwXjB3sM7hD9pN8uG4tA1o=", "Issuer": "JSopX", "Audience": "JSopX" }
     }
     ```
   - Add `Components/Pages/Login.razor`:

     ```razor
     @page "/login"
     @inject HttpClient Http
     @inject NavigationManager Navigation
     <h3>Login</h3>
     <input @bind="username" placeholder="Email" />
     <input @bind="password" type="password" placeholder="Password" />
     <button @onclick="LoginAsync">Login</button>
     <p>@message</p>
     @code {
         private string username = "", password = "", message = "";
         private async Task LoginAsync()
         {
             var response = await Http.PostAsJsonAsync("api/auth/login", new { username, password });
             if (response.IsSuccessStatusCode)
             {
                 var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                 message = "Logged in!";
                 await SecureStorage.SetAsync("jwt", result.token);
                 Navigation.NavigateTo("/");
             }
             else { message = "Login failed."; }
         }
         private class LoginResponse { public string token { get; set; } }
     }
     ```
   - Add a placeholder API in `Controllers/AuthController.cs`:

     ```csharp
     [Route("api/[controller]")]
     [ApiController]
     public class AuthController : ControllerBase
     {
         private readonly UserManager<ApplicationUser> _userManager;
         private readonly IConfiguration _config;
         public AuthController(UserManager<ApplicationUser> userManager, IConfiguration config)
         {
             _userManager = userManager; _config = config;
         }
         [HttpPost("login")]
         public async Task<IActionResult> Login([FromBody] LoginModel model)
         {
             var user = await _userManager.FindByNameAsync(model.Username);
             if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
             {
                 var token = GenerateJwtToken(user);
                 return Ok(new { token });
             }
             return Unauthorized();
         }
         private string GenerateJwtToken(ApplicationUser user)
         {
             var claims = new[] { new Claim(ClaimTypes.Name, user.UserName) };
             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
             var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
             var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
             return new JwtSecurityTokenHandler().WriteToken(token);
         }
     }
     public class LoginModel { public string Username { get; set; } public string Password { get; set; } }
     ```

5. **Test the Base Setup**:
   - Run migrations: `Add-Migration InitialCreate`, `Update-Database`.
   - Start the app (`F5`, Windows Machine target).
   - Register a user via a tool like Postman (`POST /api/auth/register`), then log in at `/login`.


[`Back to Top`](#table-of-contents)

---

## Step 2: Extend Weather Data

**Goal**: Enhance the weather feature with historical data.

1. **Update Weather Model**:
   - In `Home.razor`, modify `WeatherForecast`:

     ```csharp
     public class WeatherForecast
     {
         public DateTime Date { get; set; }
         public int TemperatureC { get; set; }
         public string Summary { get; set; }
         public int? HistoricalTempC { get; set; } // New field
     }
     ```

2. **Add Historical Data Endpoint**:
   - In `Controllers/WeatherController.cs` (add if not present):

     ```csharp
     [Route("api/[controller]")]
     [ApiController]
     public class WeatherController : ControllerBase
     {
         [HttpGet]
         public ActionResult<IEnumerable<WeatherForecast>> Get()
         {
             var rng = new Random();
             return Enumerable.Range(1, 5).Select(index => new WeatherForecast
             {
                 Date = DateTime.Now.AddDays(index),
                 TemperatureC = rng.Next(-20, 55),
                 Summary = new[] { "Cool", "Warm", "Hot" }[rng.Next(3)],
                 HistoricalTempC = rng.Next(-25, 50)
             }).ToArray();
         }
     }
     ```

3. **Update Home Page**:
   - In `Home.razor`:

     ```razor
     <tr><th>Date</th><th>Temp (°C)</th><th>Historical Temp (°C)</th><th>Summary</th></tr>
     ...
     <td>@forecast.HistoricalTempC</td>
     ...
     @code {
         protected override async Task OnInitializedAsync()
         {
             forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("api/weather");
         }
     }
     ```

4. **Test**: Run and verify historical temps show up.


[`Back to Top`](#table-of-contents)

---

## Step 3: Integrate OIDC

**Goal**: Replace custom JWT with OIDC via Duende IdentityServer (hosted in `JSopX.AspNetCore` later).

1. **Install Duende IdentityServer**:
   - For now, simulate OIDC by adding `Microsoft.AspNetCore.Authentication.OpenIdConnect` via NuGet.

2. **Configure OIDC**:
   - Update `MauiProgram.cs`:

     ```csharp
     builder.Services.AddAuthentication(options =>
     {
         options.DefaultScheme = "Cookies";
         options.DefaultChallengeScheme = "oidc";
     })
     .AddCookie("Cookies")
     .AddOpenIdConnect("oidc", options =>
     {
         options.Authority = "https://localhost:5001"; // Temp IdentityServer URL
         options.ClientId = "maui";
         options.ClientSecret = "secret";
         options.ResponseType = "code";
         options.SaveTokens = true;
         options.Scope.Add("openid");
         options.Scope.Add("profile");
         options.Scope.Add("api");
     });
     ```

3. **Secure Weather API**:
   - Add `[Authorize]` to `WeatherController`:

     ```csharp
     [Authorize]
     [HttpGet]
     public ActionResult<IEnumerable<WeatherForecast>> Get()
     ```

4. **Update Login**:
   - In `Login.razor`:

     ```razor
     @inject AuthenticationStateProvider AuthState
     @inject NavigationManager Navigation
     <button @onclick="LoginAsync">Login with OIDC</button>
     @code {
         private async Task LoginAsync()
         {
             Navigation.NavigateTo("authentication/login", true);
         }
     }
     ```
   - Add `Components/App.razor`:

     ```razor
     <CascadingAuthenticationState>
         <Router AppAssembly="@typeof(App).Assembly">
             ...
         </Router>
     </CascadingAuthenticationState>
     ```

5. **Test**: Requires IdentityServer setup (coming in `JSopX.AspNetCore`).


[`Back to Top`](#table-of-contents)

---

## Step 4: Decouple from Built-In API

**Goal**: Use `JSopX.WebAPI` instead.

1. **Create JSopX.WebAPI (if not already)**:
   - New Project > ASP.NET Core Web API > Name: `JSopX.WebAPI`.
   - Add `WeatherController` mirroring the above.
   - Update `Program.cs` with Identity and JWT.

2. **Point MAUI to WebAPI**:
   - In `Home.razor`:

     ```razor
     forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("https://localhost:7234/api/weather");
     ```

3. **Test**: Run both projects, ensure data pulls from `JSopX.WebAPI`.


[`Back to Top`](#table-of-contents)

---

## Step 5: Standardize with RCLs and Libraries

1. **Reference JSopX.RCLxProper**:
   - Add Project > New > Razor Class Library > `JSopX.RCLxProper`.
   - Move `Login.razor` to `JSopX.RCLxProper/Pages/Login.razor`.
   - Reference in `JSopX.OpenProjectX`: Right-click > Add Project Reference.
   - Update `App.razor` to use RCL routes.

2. **Reference JSopX.SharedResources**:
   - Add Project > Class Library > `JSopX.SharedResources`.
   - Add a sample asset (e.g., `WeatherUtils.cs`):

     ```csharp
     public static class WeatherUtils
     {
         public static string GetWeatherIcon(string summary) => summary switch
         {
             "Cool" => "❄️",
             "Warm" => "☀️",
             "Hot" => "🔥",
             _ => "🌧️"
         };
     }
     ```
   - Reference and use in `Home.razor`:

     ```razor
     <td>@WeatherUtils.GetWeatherIcon(forecast.Summary)</td>
     ```

3. **Test**: Verify login from RCL and icons from shared library work.

[`Back to Top`](#table-of-contents)

---

## **Next Steps**

Carefully choose the approach below that fits your current objective:

---

1. **[Continue](../../../../OpenProjects/jsopx.ClassLibrary/p1/v1/RECREATEME.md)** → **Continue** as **you were**, **creating projects** from scratch, step-by-step. You'll move onto the next project, using the `JSopX.OpenProjectX` _From Scratch_ Variant.   

---

1. **[Install Using Latest](../../../../OpenProjects/jsopx.OpenProjectX/README.md)** → **Install** or **explore** the latest version of **this project**, using the `JSopX.OpenProjectX` _Using Latest_ Variant.  
2. **[Browse By-Phase](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/README.md)** → **Browse** **previous versions** of the application by **phases** using the `JSopX.OpenProjectX` _By-Phase_ Variant.   
3. **[Get All Projects](../../../../OpenProjects/jsopx.OpenProjectX/README.md)** → **Get all projects** instead, using the `JSopX.OpenProjectX` Enterprise Application.


---

[`Home`](../../../../OpenProjects/jsopx.AspNetCore/p1/v1/README.md) » [`Introduction`](../../../../Introduction/) » [`Projects`](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/OpenProjects/) · · [`Use Latest`](../../../../OpenProjects/jsopx.OpenProjectX/README.md) · [`By-Phase`](../../../../OpenProjects/jsopx.OpenProjectX/p1/v1/README.md) · **`From Scratch`** · · [`Back to Top`](#table-of-contents) · [`« Previous`](../../../../OpenProjects/jsopx.ClassLibrary/p1/v1/RECREATEME.md) [`Next »`](../../../../OpenProjects/jsopx.AspNetCore/p1/v1/RECREATEME.md)

---

##### [incaresys.com](https://incaresys.com/) | [GitHub](https://github.com/TransR/MAUI_Self_Health_Tracker) | [Email](mailto:marks@incaresys.com) | [Phone : 508-612-5021](phoneto:508-612-5021)

###### Copyright © 2025 - All Rights Reserved by Mark J. Silvestri & Independent Care Systems Inc (ICSI)
