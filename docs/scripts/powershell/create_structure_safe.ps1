$basePath = "C:\VS 2022\gestionComercios_vs2022_rev01.00"

# =========================
# Crear carpetas (si faltan)
# =========================
$folders = @(
    "$basePath\src\Client",
    "$basePath\src\Server",
    "$basePath\src\Shared",
    "$basePath\docs",
    "$basePath\scripts\powershell",
    "$basePath\scripts\sql",
    "$basePath\config"
)

foreach ($folder in $folders) {
    if (-not (Test-Path $folder)) {
        New-Item -ItemType Directory -Path $folder | Out-Null
    }
}

# =========================
# Archivos docs NUEVOS (no existentes)
# =========================
$docFilesToEnsure = @(
    "00_overview.md",
    "01_architecture.md",
    "02_database_schema.md",
    "05_migration_plan.md",
    "06_cursor_checklist.md"
)

foreach ($file in $docFilesToEnsure) {
    $filePath = "$basePath\docs\$file"
    if (-not (Test-Path $filePath)) {
        New-Item -ItemType File -Path $filePath | Out-Null
    }
}

# =========================
# Script SQL (si no existe)
# =========================
$sqlFile = "$basePath\scripts\sql\database_schema_report.sql"
if (-not (Test-Path $sqlFile)) {
    New-Item -ItemType File -Path $sqlFile | Out-Null
}

# =========================
# Configuración
# =========================
$configFiles = @(
    "$basePath\config\appsettings.Development.json",
    "$basePath\config\appsettings.Production.json"
)

foreach ($config in $configFiles) {
    if (-not (Test-Path $config)) {
        New-Item -ItemType File -Path $config | Out-Null
    }
}

# =========================
# Root files
# =========================
$rootFiles = @(
    "$basePath\README.md",
    "$basePath\.gitignore"
)

foreach ($file in $rootFiles) {
    if (-not (Test-Path $file)) {
        New-Item -ItemType File -Path $file | Out-Null
    }
}

Write-Host "✅ Estructura verificada. Ningún archivo existente fue modificado."
