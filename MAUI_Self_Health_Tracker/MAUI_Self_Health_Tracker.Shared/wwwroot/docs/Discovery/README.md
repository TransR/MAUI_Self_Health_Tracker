# MAUI Self Health Tracker – Discovery Notes (v1)

> **Status:** Draft document for design exploration, troubleshooting logs, and evolving notes.  
> Location: `MAUI_Self_Health_Tracker.Shared/wwwroot/docs/Discovery/README.md`

---

## Table of Contents
1. [Context](#context)  
2. [North-Star Principles](#north-star-principles)  
3. [Architecture Snapshot](#architecture-snapshot)  
4. [DbContext + Data Layer](#dbcontext--data-layer)  
5. [Naming & Namespace Conventions](#naming--namespace-conventions)  
6. [Repository Usage](#repository-usage)  
7. [Constraints / Environment](#constraints--environment)  
8. [Next Steps](#next-steps)  

[`⇦ Back to Home`](../../../README.md) · [`⇧ Back to Top`](#table-of-contents)

---

## Context

The **MAUI Self Health Tracker** prototype is the foundation for **Self Health®**, a proprietary application owned by **Independent Care Systems Inc (ICSI)**.  
It is not an open-source project. This Discovery doc exists as the **sandbox for notes** — early observations, side research, troubleshooting logs, and messy draft steps.

[`⇧ Back to Top`](#table-of-contents)

---

## North-Star Principles

- **Strict Proprietary Ownership** — All rights reserved by Mark J. Silvestri & ICSI.  
- **Consistency First** — Shared RCL drives all models, DbContext, and Blazor components.  
- **Platform Parity** — Hybrid app (MAUI) and Web must remain in sync with database layer.  
- **Cloud Ready** — Local dev uses LocalDB/SQL Express, staging runs on SQL Server, production targets Azure SQL.  
- **Minimal Drift** — Versions of .NET/EF Core/packages must stay aligned across projects.  
- **No Public Forking/Contribution** — Repo is internal; documentation must reflect this clearly.

[`⇧ Back to Top`](#table-of-contents)

---

## Architecture Snapshot

```
Solution
├─ MAUI_Self_Health_Tracker/           # Primary MAUI host (Hybrid)
│  ├─ MauiProgram.cs
│  └─ Components/
│
├─ MAUI_Self_Health_Tracker.Shared/    # Shared RCL
│  ├─ Models/
│  ├─ Data/TrackerDbContext.cs
│  ├─ Components/
│  └─ Services/
│
├─ MAUI_Self_Health_Tracker.Web/       # Server host
│  ├─ Program.cs
│  └─ appsettings.json
└─ MAUI_Self_Health_Tracker.Web.Client # Optional WASM (not yet active)
```

[`⇧ Back to Top`](#table-of-contents)

---

## DbContext + Data Layer

- `TrackerDbContext` lives in **Shared** project (`.Shared/Data/`).  
- Currently supports `FoodEntry`, `ExerciseEntry`, `BodyWeightEntry`, `VitalEntry`, `LabResult`, `MedicationEntry`, `LookupItem`, and `UserTargets`.  
- **Design-time factory** enables EF CLI migrations.  
- **Migrations** should remain in Shared project for schema traceability.  

Questions under watch:
- Will `SeedData` logic interfere with migrations?  
- How do we cleanly separate test seeding vs. production migrations?  
- What is the migration gate checklist (build/migrate/commit)?  

[`⇧ Back to Top`](#table-of-contents)

---

## Naming & Namespace Conventions

- **Current:** `MAUI_Self_Health_Tracker.*` (temporary).  
- **Future:** `ICSI.SelfHealth.*` (final convention).  
- **Display Names:** `Self Health®` (trademarked).  

Policy: namespace renames must be atomic (no partial drifts); coordinated with Git repo moves.

[`⇧ Back to Top`](#table-of-contents)

---

## Repository Usage

This repo is a **single source of truth** for both raw and compiled artifacts:  

- **Raw:** models, migrations, service classes, docs.  
- **Compiled:** binaries for deployment, internal packages.  

Rules:
- No forks, no PRs from outsiders.  
- Commits must pass build + migration sanity checks.  
- Discovery docs can be messy; Architecture docs must remain clean.

[`⇧ Back to Top`](#table-of-contents)

---

## Constraints / Environment

- **Visual Studio:** 17.14.14  
- **.NET / ASP.NET Core / MAUI:** 9.0.1  
- **EF Core:** 9.0.9  
- **Node.js:** 20.14.0  
- **npm:** 10.8.1  
- **PowerShell:** 7.x+  
- **Bash:** 5.x+  

Windows 10+ baseline, staging/production planned for Azure SQL.

[`⇧ Back to Top`](#table-of-contents)

---

## Next Steps

- [ ] Namespace refactor → `ICSI.SelfHealth.*`.  
- [ ] Confirm LocalDB → SSMS path works for both devs.  
- [ ] Add Azure SQL pipeline for production.  
- [ ] Expand Architecture doc with full DI/migration patterns.  
- [ ] Experiment with “Lumina Gate” slim-doc format (parallel to verbose docs).  

[`⇦ Back to Home`](../../../README.md) · [`⇧ Back to Top`](#table-of-contents)

---

###### Copyright © 2025 – All Rights Reserved by Mark J. Silvestri & Independent Care Systems Inc (ICSI)