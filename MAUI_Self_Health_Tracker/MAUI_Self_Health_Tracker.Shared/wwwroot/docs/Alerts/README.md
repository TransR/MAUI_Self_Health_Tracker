# MAUI Self Health Tracker – Active Alerts (v1)

> **Status:** This doc tracks **active issues, warnings, and assumption alerts**.  
> Location: `MAUI_Self_Health_Tracker.Shared/wwwroot/docs/Alerts/README.md`  
> **Owner:** Jason Silvestri (with Lumina AI assist).  

---

## Table of Contents

1 [Current Critical Alerts](#current-critical-alerts)

2 [Pending Actions for Mark](#pending-actions-for-mark)

3 [Permissions Note](#permissions-note)

4 [Assumption Alerts](#assumption-alerts)

5 [Workarounds in Progress](#workarounds-in-progress)

6 [Resolution Log](#resolution-log)


[`⇦ Back to Home`](../../../README.md) · [`⇧ Back to Top`](#table-of-contents)

---

## Current Critical Alerts

### ⚠️ Solution / Project Path Bug
- **Symptom:** Visual Studio (MAUI Blazor Hybrid v9 template) creates **nested directories**:  
  `MAUI_Self_Health_Tracker/MAUI_Self_Health_Tracker/MAUI_Self_Health_Tracker.Shared/...`
- **Impact:** EF CLI (`dotnet ef`) migration commands fail unless explicit paths are used.  
- **Status:** Being resolved. Stable builds confirmed. Migration commands still fragile.  
- **Next Checkpoint:** Align all migration commands to explicit paths, validate with `-v d` verbose output.


---

## ⚠️ Pending Actions for Mark

- You **can safely clone + build** the repo.  
- Do **not attempt to run `dotnet ef migrations` or `dotnet ef database update`** yet — Jason is stabilizing this pipeline.  
- Once migration steps are confirmed, Jason will provide updated **step-by-step notes** under `docs/Architecture/README.md`.  
- For now, treat the Alerts doc as the **single source of truth** for open fires.

---

### ⚠️ Permissions Note

Jason attempted to adjust GitHub repo permissions and got a `404`.  
- **Action for Mark:** Update repo visibility and permissions so Jason can make it **private** (default) or **public** (controlled).  
- Reminder: This repo is **proprietary** — no public forks, no external contributions.  

---

## Assumption Alerts

- Assumption: CLI failure was package mismatch.  
  **Reality:** Pathing issue due to nested directory bug in Visual Studio MAUI template.  
- Assumption: Removing the extra directory would solve it.  
  **Reality:** Removing breaks references; solution must be more deliberate.  
- Resolution discipline: wait until **3+ assumptions stack**, then log as Alert.

---

## Workarounds in Progress

- ✅ Installed **dotnet-ef 9.0.9** globally.  
- ✅ Stable builds across Shared / Web / Client confirmed.  
- 🔄 EF Migrations tested only with **explicit project/startup paths**.  
- 🔄 `.keep` + `.gitignore` hygiene added to docs/Architecture/Gates for clean state.  


## Resolution Log

- 2025-09-11 → Installed `dotnet-ef` 9.0.9 globally; CLI now available.  
- 2025-09-11 → Verified builds stable after package alignment.  
- 2025-09-11 → Migration command failed due to directory nesting; logged as **Critical Alert**.  
- 2025-09-11 → Added `.keep` + `.gitignore` patterns to keep Gates directory clean.  

---

[`⇦ Back to Home`](../../../../README.md) · [`⇧ Back to Top`](#table-of-contents) · [`View Resolved Alerts →`](./RESOLVED.md)

---

##### [incaresys.com](https://incaresys.com/) | [GitHub](https://github.com/TransR/MAUI_Self_Health_Tracker) | [Email](mailto:marks@incaresys.com) | [Phone : 508-612-5021](phoneto:508-612-5021)

###### Copyright © 2025 – All Rights Reserved by Mark J. Silvestri & Independent Care Systems Inc (ICSI)
