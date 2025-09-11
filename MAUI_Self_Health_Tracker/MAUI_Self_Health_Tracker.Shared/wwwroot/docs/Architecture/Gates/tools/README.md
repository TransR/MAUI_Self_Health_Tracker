# Architecture – MAUI Self Health Tracker

**Project root:** `MAUI_Self_Health_Tracker`  
**Primary solution:** `MAUI_Self_Health_Tracker.sln`

---

## Table of Contents
1. [Scope](#scope)  
2. [Solution Topology](#solution-topology)  
3. [Runtime Architecture](#runtime-architecture)  
4. [Data & EF Core](#data--ef-core)  
5. [Configuration & Environments](#configuration--environments)  
6. [Build & CI Artifacts](#build--ci-artifacts)  
7. [Gate Checks (Lumina Gate)](#gate-checks-lumina-gate)  
8. [Roadmap Notes](#roadmap-notes)  
9. [Links](#links)

---

## Scope
This document provides a **stable technical map** for the repository. It’s intentionally concise and source-of-truthish:
- Defines projects and responsibilities.
- Shows where EF Core and settings live.
- Points to gate checks and CI outputs.
- Stays valid across minor refactors and naming cleanups.

---

## Solution Topology
```
MAUI_Self_Health_Tracker/
├─ MAUI_Self_Health_Tracker/               # MAUI app (Blazor Hybrid host)
│  ├─ MauiProgram.cs                        # DI for device-side services
│  └─ wwwroot/                              # static assets for MAUI host
│
├─ MAUI_Self_Health_Tracker.Shared/        # RCL (UI + Models + EF Core)
│  ├─ Models/                               # Entities
│  ├─ Data/
│  │  ├─ TrackerDbContext.cs                # DbContext (code-first)
│  │  └─ TrackerDbContextFactory.cs         # Design-time factory (migrations)
│  ├─ Pages/ Components/ Layout/            # Reusable Blazor UI
│  └─ wwwroot/
│     └─ docs/
│        ├─ Discovery/README.md             # scratchpad / notes / experiments
│        └─ Architecture/README.md          # this file
│           └─ Gates/README.md              # Lumina Gate details
│
├─ MAUI_Self_Health_Tracker.Web/           # ASP.NET Core host (Blazor Server + WASM)
│  ├─ Program.cs                            # Web DI, RazorComponents
│  ├─ appsettings.json                      # prod defaults
│  └─ appsettings.Development.json          # local dev (connection strings)
│
└─ MAUI_Self_Health_Tracker.Web.Client/    # (optional) WASM client
   └─ Program.cs                            # Only used if explicitly enabled
```

---

## Runtime Architecture
- **UI**: Razor Components (shared) rendered by **MAUI** (hybrid) and **Web** (server/WASM).
- **Services**: DI in each host; shared contracts in `.Shared`.
- **Data**: EF Core **code-first** via `TrackerDbContext` in `.Shared`.
- **Composition**: Web host maps routes and imports the Shared RCL assembly for pages/components.

---

## Data & EF Core
- **Context**: `MAUI_Self_Health_Tracker.Shared/Data/TrackerDbContext.cs`
- **Factory**: `TrackerDbContextFactory.cs` enables `dotnet ef` without booting the host.
- **Migrations home**: **Shared project**. Example:
  ```bash
  dotnet ef migrations add InitialCreate \
    --project ./MAUI_Self_Health_Tracker.Shared/MAUI_Self_Health_Tracker.Shared.csproj \
    --startup-project ./MAUI_Self_Health_Tracker.Web/MAUI_Self_Health_Tracker.Web.csproj
  dotnet ef database update \
    --project ./MAUI_Self_Health_Tracker.Shared/MAUI_Self_Health_Tracker.Shared.csproj \
    --startup-project ./MAUI_Self_Health_Tracker.Web/MAUI_Self_Health_Tracker.Web.csproj
  ```

---

## Configuration & Environments
- **Primary**: `MAUI_Self_Health_Tracker.Web/appsettings*.json`
- **Local test (Windows auth)**:
  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=SelfHealthTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
    }
  }
  ```
- **Azure SQL (future)**: use `Server=tcp:<server>.database.windows.net,1433;...;Authentication=Active Directory Default;` and managed identity or AAD token flow.

---

## Build & CI Artifacts
- CI workflow (optional): `.github/workflows/lumina-gate.yml`
- Gate reports (JSON):  
  `MAUI_Self_Health_Tracker.Shared/wwwroot/docs/Architecture/Gates/results/*.json`

---

## Gate Checks (Lumina Gate)
The gate is a **preflight diagnostic** (restore/build/EF/migrations sanity) that emits a **machine-readable JSON** summary. It doesn’t block by default.  
See: [`Gates/README.md`](./Gates/README.md)

---

## Roadmap Notes
- Rename namespace roots to `ICSI.SelfHealth.*` after functional stabilization.
- Promote **Web.Client** only if we need rich WASM-only features.
- Introduce Azure SQL + migrations pipeline once prototype passes local + CI gates.

---

## Links
- Back to **Discovery**: [`../Discovery/README.md`](../Discovery/README.md)  
- Lumina Gate details: [`./Gates/README.md`](./Gates/README.md)  
- **Home** (repo root): [`../../../../README.md`](../../../../README.md)

---

##### [incaresys.com](https://incaresys.com/) | [GitHub](https://github.com/TransR/MAUI_Self_Health_Tracker) | [Email](mailto:marks@incaresys.com) | [Phone : 508-612-5021](phoneto:508-612-5021)

###### Copyright © 2025 - All Rights Reserved by Mark J. Silvestri & Independent Care Systems Inc (ICSI)
