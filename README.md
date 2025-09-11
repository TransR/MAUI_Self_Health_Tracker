# MAUI Self Health Tracker – Cross-Platform Prototype for Self Health® (v1)

The **MAUI Self Health Tracker** is a private, cross-platform application prototype designed to deliver the foundation of the **Self Health®** system. It leverages **.NET 9, ASP.NET Core 9, and MAUI Hybrid/Web** technologies to support mobile, desktop, and web targets.  
 
---

[`Home`](./README.md)

---

This repository is **strictly proprietary** and **not open for contributions**. Its purpose is internal development and controlled distribution only.

---

```bash
# Clone the Self Health Tracker Git Repository
$ git clone https://github.com/TransR/MAUI_Self_Health_Tracker.git
```

---

## ⚠️ Active Alerts - for Mark (v1)

> **Status:** This doc tracks **active issues, warnings, and assumption alerts**.  
> **Owner:** Mark Silvestri.  
>
> See your active alerts here: [`See ALERTS!`](../../../../README.md)

 
---

## ⚠️ Active Alerts - for Jason (v1)

> **Status:** This doc tracks **active issues, warnings, and assumption alerts**.  
> **Owner:** Jason Silvestri (with Lumina AI assist).  
>
> See your active alerts here: [`See ALERTS!`](./MAUI_Self_Health_Tracker.Shared/wwwroot/docs/Alerts/README.md)

---

## Table of Contents
1. [Overview](#overview)  
2. [Prerequisites](#prerequisites)  
3. [Platform Scope (v1)](#platform-scope-v1)  
4. [Repository File Structure](#repository-file-structure)  
5. [Clone Instructions](#clone-instructions)  
   - [Option 1: Bash](#option-1-using-bash)  
   - [Option 2: PowerShell](#option-2-using-powershell)  
   - [Option 3: Node.js / degit](#option-3-using-node-or-npm-degit)  
6. [Build & Run](#build--run)  
7. [License / Ownership](#license--ownership)

---

## Overview

The **MAUI Self Health Tracker** prototype demonstrates the **core architecture for Self Health®**.  

- Uses a **Shared Project (RCL)** for models, DbContext (`TrackerDbContext`), and reusable Blazor components.  
- A **Web Project** provides server-side hosting and Blazor Hybrid endpoints.  
- A **MAUI Project** serves as the cross-platform host (Android, iOS, Windows, macOS).  
- Optionally includes a **Web.Client Project** (Blazor WASM) reserved for future expansion.  

The repository exists to validate design, data access patterns, and hybrid MAUI + ASP.NET Core hosting.  

---

🛡️ **IMPORTANT**: 

This repository **should NOT** be confused with the look and real, and/or even the _production-ready_ version(s) of the application(s) currently named, **MAUI Self Health Tracker**. 

Instead, think of it as **all of that**, and more, including **_ALL_** raw, uncompiled code, product release applications, documentation, and everything else in between. 

More importantly, we should keep it private as often as possible and `never` store sensitive information in the repository. 


[`⇧ Back to Top`](#table-of-contents)  

---

## Prerequisites

To build and run the **MAUI Self Health Tracker**, ensure the following are installed:

- [Visual Studio (v 17.14.14)](https://visualstudio.microsoft.com/)  
- [.NET Framework (v 9.0.1)](https://dotnet.microsoft.com/)  
- [ASP.NET Core (v 9.0.1)](https://dotnet.microsoft.com/)  
- [.NET MAUI (v 9.0.1)](https://learn.microsoft.com/dotnet/maui/)  
- [Node.js (v 20.14.0)](https://nodejs.org/)  
- [npm (v 10.8.1)](https://www.npmjs.com/)  
- [Bash (v 5.x+)](https://www.gnu.org/software/bash/)  
- [PowerShell (v 7.x+)](https://learn.microsoft.com/powershell/)  

[`⇧ Back to Top`](#table-of-contents)  

---

## Platform Scope (v1)

- **Technology Stack:** .NET 9, ASP.NET Core 9, MAUI Hybrid, Blazor WebAssembly (optional).  
- **Database Layer:** EF Core (`TrackerDbContext`) using LocalDB for dev/testing, SQL Server for staging, and Azure SQL planned for production.  
- **Cross-Platform Targets:** Android, iOS, Windows, macOS, Web.  
- **Branding & Trademark:** All artifacts use **Self Health®**, owned by Independent Care Systems Inc (ICSI).  
- **Repository Intent:** Internal-only; raw and compiled artifacts for ICSI engineering and deployment.  

[`⇧ Back to Top`](#table-of-contents)  

---

## Repository File Structure

```text
MAUI_Self_Health_Tracker/
├─ README.md
├─ LICENSE
├─ CODE_OF_CONDUCT.md
├─ SECURITY.md
├─ MAUI_Self_Health_Tracker/              # Primary MAUI Hybrid Project
│  ├─ MauiProgram.cs
│  └─ ...
├─ MAUI_Self_Health_Tracker.Shared/       # Shared RCL: DbContext, Models, Components
│  ├─ Data/TrackerDbContext.cs
│  ├─ Models/
│  └─ Components/
├─ MAUI_Self_Health_Tracker.Web/          # Web Project (ASP.NET Core host)
│  ├─ Program.cs
│  └─ appsettings.json
└─ MAUI_Self_Health_Tracker.Web.Client/   # Optional Blazor WASM project
   └─ Program.cs
```

[`⇧ Back to Top`](#table-of-contents)  

---

## Clone Instructions

### **Option 1: Using Bash**
```bash
cd path/to/local/repos
git clone https://github.com/TransR/MAUI_Self_Health_Tracker.git
```

[`Back to Top`](#clone-instructions)  

---

### **Option 2: Using PowerShell**
```powershell
cd path\to\local\repos
git clone https://github.com/TransR/MAUI_Self_Health_Tracker.git
```

[`Back to Top`](#clone-instructions)  

---

### **Option 3: Using Node.js / npm (degit)**
```shell
cd path/to/local/repos
npx degit https://github.com/TransR/MAUI_Self_Health_Tracker
```

[`Back to Top`](#clone-instructions)  

---

## Build & Run

1. Open `MAUI_Self_Health_Tracker.sln` in Visual Studio 17.14.14.  
2. Restore dependencies:
   ```powershell
   dotnet restore
   ```
3. Verify EF Core setup (from solution folder):
   ```powershell
   dotnet ef dbcontext list `
     --project .\MAUI_Self_Health_Tracker.Shared\MAUI_Self_Health_Tracker.Shared.csproj `
     --startup-project .\MAUI_Self_Health_Tracker.Web\MAUI_Self_Health_Tracker.Web.csproj
   ```
4. Build the solution.  
5. Run the MAUI app (select Android, iOS, Windows, or MacCatalyst target).  
6. Optionally run the Web project (`https://localhost:5001`).  

[`⇧ Back to Top`](#table-of-contents)  

---

## License / Ownership

**Self Health®** is a registered trademark of Independent Care Systems Inc (ICSI).  
Unauthorized use, modification, or distribution of this software is strictly prohibited.

---

##### [incaresys.com](https://incaresys.com/) | [GitHub](https://github.com/TransR/MAUI_Self_Health_Tracker) | [Email](mailto:marks@incaresys.com) | [Phone : 508-612-5021](phoneto:508-612-5021)

###### Copyright © 2025 – All Rights Reserved by Mark J. Silvestri & Independent Care Systems Inc (ICSI)
