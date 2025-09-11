﻿# Lumina Gate – Preflight & Sanity Reports

**Purpose:** fast, machine-checkable diagnostics for builds, EF Core readiness, and config hygiene—without blocking development (until you flip the switch).

---

## Table of Contents
1. [What the Gate Does](#what-the-gate-does)
2. [Where Files Live](#where-files-live)
3. [Running Locally](#running-locally)
4. [CI Workflow (Optional)](#ci-workflow-optional)
5. [Output Schema (JSON)](#output-schema-json)
6. [Making It Enforcing (Later)](#making-it-enforcing-later)
7. [Navigation](#navigation)

---

## What the Gate Does
- **Restore & Build**: verifies solution builds on a clean agent.
- **EF Core Probe**: makes sure `TrackerDbContextFactory` constructs the context and that migrations can be discovered.
- **Configuration Probe**: checks `appsettings*.json` for an accessible connection string (non-fatal in CI).
- **Report**: writes a single JSON artifact summarizing pass/fail and context.

---

## Where Files Live
```
MAUI_Self_Health_Tracker.Shared/
└─ wwwroot/docs/Architecture/Gates/
   ├─ README.md                     # this file
   ├─ results/                      # JSON reports land here
   │  └─ lumina-result.<timestamp>.json
   └─ tools/                        # optional local tools (future)
```

> CI workflow sits at: `.github/workflows/lumina-gate.yml` (repo root).

---

## Running Locally
When you add the PowerShell script later (e.g., `tools/gates/lumina-gate.ps1`), a typical invocation might look like:

```powershell
.\tools\gates\lumina-gate.ps1 `
  -SolutionPath ".\MAUI_Self_Health_Tracker\MAUI_Self_Health_Tracker.sln" `
  -SharedProject ".\MAUI_Self_Health_Tracker\MAUI_Self_Health_Tracker.Shared\MAUI_Self_Health_Tracker.Shared.csproj" `
  -StartupProject ".\MAUI_Self_Health_Tracker\MAUI_Self_Health_Tracker.Web\MAUI_Self_Health_Tracker.Web.csproj" `
  -AppSettingsPath ".\MAUI_Self_Health_Tracker\MAUI_Self_Health_Tracker.Web\appsettings.Development.json" `
  -Environment "LOCAL"
```

The script should:
- Create `results/` if missing.
- Emit `lumina-result.<yyyyMMdd-HHmmss>.json`.

---

## CI Workflow (Optional)
A ready-to-use workflow (non-blocking) has been provided earlier:  
`.github/workflows/lumina-gate.yml`

It:
- Sets up .NET 9 SDK + dotnet-ef.
- Runs the gate script with `continue-on-error: true`.
- Uploads `results/*.json` as a build artifact.

---

## Output Schema (JSON)
The gate report uses a small, stable schema (example shown for reference—your script will generate the actual values):

```json
{
  "name": "lumina-gate",
  "version": "1.0.0",
  "timestamp": "2025-09-10T19:00:00Z",
  "environment": "CI",
  "pass": true,
  "checks": {
    "restore": { "pass": true, "details": "dotnet restore succeeded" },
    "build":   { "pass": true, "details": "solution built: 4 succeeded" },
    "ef": {
      "pass": true,
      "contextFactory": "TrackerDbContextFactory",
      "migrationsFound": 1,
      "details": "EF tools ok; context constructed"
    },
    "config": {
      "pass": true,
      "appsettings": "appsettings.Development.json",
      "connectionString": "DefaultConnection",
      "details": "Probed successfully (non-blocking)"
    }
  },
  "notes": [
    "Non-blocking in CI; flip enforcement when ready."
  ]
}
```

Place actual schema evolution notes in `results/` alongside reports if needed.

---

## Making It Enforcing (Later)
When you want the gate to fail PRs:
1. In the workflow, set the gate step `continue-on-error: false`.
2. Add a small post-step that parses the latest JSON and exits with non-zero if `"pass": false`.

---

## Navigation
- **Back to Architecture:** [`../README.md`](../README.md)  
- **Back to Discovery:** [`../../Discovery/README.md`](../../Discovery/README.md)  
- **Back to Home (repo root):** [`../../../../../../README.md`](../../../../../../README.md)

---

##### [incaresys.com](https://incaresys.com/) | [GitHub](https://github.com/TransR/MAUI_Self_Health_Tracker) | [Email](mailto:marks@incaresys.com) | [Phone : 508-612-5021](phoneto:508-612-5021)

###### Copyright © 2025 - All Rights Reserved by Mark J. Silvestri & Independent Care Systems Inc (ICSI)
