# MAUI Self Health Tracker – Resolved Alerts (v1)

> **Status:** Archive of resolved or closed alerts.  
> Location: `MAUI_Self_Health_Tracker.Shared/wwwroot/docs/Alerts/RESOLVED.md`

---

## Table of Contents
1. [Context](#context)  
2. [Resolved Items](#resolved-items)  
   - [2025-01 – Extra Solution/Project Directory Path](#2025-01--extra-solutionproject-directory-path)  
   - [Future Alerts](#future-alerts)  

[`⇦ Back to Active Alerts`](./README.md) · [`⇧ Back to Top`](#table-of-contents) · [`Back to Home`](../../../../README.md)

---

## Context

This document tracks **alerts that have been resolved** and moved out of the active `Alerts/README.md`.  
It serves as a history of lessons learned, troubleshooting notes, and context for future refactoring.  

[`⇧ Back to Top`](#table-of-contents)

---

## Resolved Items

### 2025-01 – Extra Solution/Project Directory Path

**Summary:**  
The Visual Studio MAUI Hybrid/Web template generated **nested solution/project directories** (`MAUI_Self_Health_Tracker/MAUI_Self_Health_Tracker/MAUI_Self_Health_Tracker`).  

**Resolution:**  
- Identified as a template bug / pathing quirk.  
- Workarounds tested:
  - Moving projects manually (failed).
  - Renaming solution/project (caused crashes).
  - Final approach: keep solution/projects in same directory for predictable outcome.  
- Captured as a reference issue for **ICSI.SelfHealth** refactor.  

[`⇧ Back to Top`](#table-of-contents)

---

## Future Alerts

- Placeholder for the next archived alert.

[`⇦ Back to Active Alerts`](./README.md) · [`⇧ Back to Top`](#table-of-contents) · [`Back to Home`](../../../../README.md)

---

##### [incaresys.com](https://incaresys.com/) | [GitHub](https://github.com/TransR/MAUI_Self_Health_Tracker) | [Email](mailto:marks@incaresys.com) | [Phone : 508-612-5021](phoneto:508-612-5021)

###### Copyright © 2025 – All Rights Reserved by Mark J. Silvestri & Independent Care Systems Inc (ICSI)