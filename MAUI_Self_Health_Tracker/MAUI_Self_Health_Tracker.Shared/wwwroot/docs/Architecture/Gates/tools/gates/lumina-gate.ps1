Param(
  [Parameter(Mandatory = $true)] [string] $SolutionPath,
  [Parameter(Mandatory = $true)] [string] $SharedProject,
  [Parameter(Mandatory = $true)] [string] $StartupProject,
  [Parameter(Mandatory = $true)] [string] $AppSettingsPath,
  [string] $ConnectionStringName = "DefaultConnection",
  [string] $Environment = "Development"
)

$ErrorActionPreference = "Stop"

function Invoke-Step {
  param(
    [string] $Name,
    [scriptblock] $Action
  )
  $sw = [System.Diagnostics.Stopwatch]::StartNew()
  $result = @{
    status = "Failed"
    exitCode = 1
    durationMs = 0
    log = ""
  }
  try {
    $global:LASTEXITCODE = 0
    $out = & $Action | Out-String
    $code = $global:LASTEXITCODE
    $result.exitCode = $code
    $result.log = $out.Trim()
    if ($code -eq 0) {
      $result.status = "Success"
    }
  } catch {
    $result.log = $_ | Out-String
    $result.status = "Failed"
    $result.exitCode = -1
  } finally {
    $sw.Stop()
    $result.durationMs = $sw.ElapsedMilliseconds
  }
  return $result
}

function Get-ConnectionString {
  param(
    [string] $Path,
    [string] $Name
  )
  if (!(Test-Path $Path)) {
    return @{ value = $null; source = "NotFound" }
  }
  $json = Get-Content -Raw -Path $Path | ConvertFrom-Json
  $cs = $null
  if ($json.PSObject.Properties.Name -contains "ConnectionStrings") {
    $cs = $json.ConnectionStrings.$Name
  }
  if ($null -ne $cs -and "$cs".Trim() -ne "") {
    $source = Split-Path -Leaf $Path
    return @{ value = "$cs"; source = $source }
  }

  $fallback = (Join-Path (Split-Path $Path -Parent) "appsettings.json")
  if (Test-Path $fallback) {
    $json2 = Get-Content -Raw -Path $fallback | ConvertFrom-Json
    $cs2 = $json2.ConnectionStrings.$Name
    if ($null -ne $cs2 -and "$cs2".Trim() -ne "") {
      return @{ value = "$cs2"; source = "appsettings.json" }
    }
  }

  $envName = "ConnectionStrings__${Name}"
  $envVal = [Environment]::GetEnvironmentVariable($envName)
  if ($envVal) {
    return @{ value = "$envVal"; source = "EnvVar" }
  }

  return @{ value = $null; source = "NotFound" }
}

function Test-SqlConnection {
  param([string] $ConnectionString)
  try {
    Add-Type -AssemblyName "System.Data"
    $conn = New-Object System.Data.SqlClient.SqlConnection($ConnectionString)
    $conn.Open()
    $conn.Close()
    return @{ status = "Connected"; exception = $null }
  } catch {
    return @{ status = "Failed"; exception = ($_ | Out-String).Trim() }
  }
}

# Ensure result folder
$ResultsDir = Join-Path ".\MAUI_Self_Health_Tracker\MAUI_Self_Health_Tracker.Shared\wwwroot\docs\Architecture\Gates\results" ""
if (!(Test-Path $ResultsDir)) {
  New-Item -ItemType Directory -Force -Path $ResultsDir | Out-Null
}

# 1) Restore
$restore = Invoke-Step -Name "restore" -Action {
  dotnet restore $SolutionPath
}

# 2) Build
$build = Invoke-Step -Name "build" -Action {
  dotnet build $SolutionPath -c Debug --no-restore
}

# 3) EF migrations list
$ef = @{
  status = "Failed"
  exitCode = 1
  migrations = @()
  log = ""
}
try {
  $global:LASTEXITCODE = 0
  $efOut = dotnet ef migrations list --project $SharedProject --startup-project $StartupProject --no-build --verbose 2>&1 | Out-String
  $ef.exitCode = $global:LASTEXITCODE
  $ef.log = $efOut.Trim()
  if ($global:LASTEXITCODE -eq 0) {
    $ef.status = "Success"
    $lines = $efOut -split "`r?`n"
    $migs = @()
    foreach ($l in $lines) {
      $t = $l.Trim()
      if ($t -ne "" -and -not ($t -like "Build started*" -or $t -like "Build succeeded*")) {
        if ($t -match "^\d{14}_.+") { $migs += $t }
        elseif ($t -match "^\s*\(No migrations were found\)") { }
        elseif ($t -notmatch "^\(.*\)$" -and $t -notmatch "^\[.*\]$") { }
      }
    }
    $ef.migrations = $migs
  }
} catch {
  $ef.log = ($_ | Out-String).Trim()
  $ef.exitCode = -1
  $ef.status = "Failed"
}

# 4) DB connectivity
$cs = Get-ConnectionString -Path $AppSettingsPath -Name $ConnectionStringName
$database = @{
  status = "Skipped"
  provider = "SqlServer"
  connectionStringSource = $cs.source
}
if ($cs.value) {
  $db = Test-SqlConnection -ConnectionString $cs.value
  $database.status = $db.status
  if ($db.exception) { $database.exception = $db.exception }
}

# 5) Aggregate + pass/fail
$now = [DateTime]::UtcNow.ToString("o")
$warnings = @()
if ($ef.status -eq "Success" -and $ef.migrations.Count -eq 0) {
  $warnings += "No migrations were found in the Shared project."
}
if ($database.status -eq "Failed") {
  $warnings += "Database connectivity failed using source: $($database.connectionStringSource)."
}
$pass = $restore.status -eq "Success" -and $build.status -eq "Success" -and $ef.status -eq "Success" -and $database.status -ne "Failed"

$result = [ordered]@{
  version = "0.1.0"
  timestampUtc = $now
  gate = @{
    solutionPath = $SolutionPath
    sharedProject = $SharedProject
    startupProject = $StartupProject
    appSettingsPath = $AppSettingsPath
    connectionStringName = $ConnectionStringName
    environment = $Environment
  }
  restore = $restore
  build = $build
  ef = $ef
  database = $database
  warnings = $warnings
  pass = $pass
}

# 6) Write JSON
$stamp = [DateTime]::UtcNow.ToString("yyyyMMdd_HHmmss")
$outFile = Join-Path $ResultsDir "lumina-result.$stamp.json"
$result | ConvertTo-Json -Depth 10 | Out-File -FilePath $outFile -Encoding UTF8

Write-Host "Lumina Gate complete: $outFile"
if (-not $pass) {
  Write-Error "Gate failed. See $outFile"
}
