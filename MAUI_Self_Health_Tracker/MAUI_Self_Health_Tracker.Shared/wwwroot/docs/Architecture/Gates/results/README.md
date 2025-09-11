# Lumina Gate – Tools Directory

This folder contains **scripts and helper utilities** used to run Lumina Gate checks locally or in CI/CD.

---

## Contents
- **`lumina-gate.ps1`** → PowerShell script that performs restore/build/EF/config probes and writes JSON reports into `../results/`.  
- **(future)** additional scripts, helpers, or language ports (Node.js, Bash, etc.) may live here.

---

## Notes
- These scripts are **not run automatically** unless explicitly invoked.  
- In CI/CD, the associated GitHub Action workflow (`../github/workflows/lumina-gate.yaml`) will call these scripts.  
- Scripts should always write outputs to the `../results/` folder.  

---

## Navigation
- Back to **Gates Overview**: [`../README.md`](../README.md)  
- Back to **Architecture Docs**: [`../../README.md`](../../README.md)  
- Back to **Repo Home**: [`../../../../../../../../README.md`](../../../../../../../../README.md)

---

##### [incaresys.com](https://incaresys.com/) | [GitHub](https://github.com/TransR/MAUI_Self_Health_Tracker) | [Email](mailto:marks@incaresys.com) | [Phone : 508-612-5021](phoneto:508-612-5021)

###### Copyright © 2025 - All Rights Reserved by Mark J. Silvestri & Independent Care Systems Inc (ICSI)
