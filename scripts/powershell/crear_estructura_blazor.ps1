# ============================================
# Script: Crear Estructura Blazor WebAssembly
# ============================================
# Este script crea todos los archivos y carpetas
# necesarios para un proyecto Blazor WebAssembly
# con estructura Client/Server/Shared

$ErrorActionPreference = "Stop"

# Ruta base del proyecto
$projectRoot = "C:\VS 2022\gestionComercios_vs2022_rev01.00"

Write-Host "🚀 Creando estructura del proyecto Blazor WebAssembly..." -ForegroundColor Cyan
Write-Host "Ruta base: $projectRoot" -ForegroundColor Gray
Write-Host ""

# Cambiar al directorio del proyecto
Set-Location $projectRoot

# ============================================
# 1. ARCHIVO DE SOLUCIÓN (.sln)
# ============================================
Write-Host "📄 Creando archivo de solución..." -ForegroundColor Yellow
$slnPath = Join-Path $projectRoot "gestionComercios.sln"
if (-not (Test-Path $slnPath)) {
    # Crear archivo .sln con formato válido de Visual Studio
    $slnContent = @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.0.31903.59
MinimumVisualStudioVersion = 10.0.40219.1
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
"@
    Set-Content -Path $slnPath -Value $slnContent -Encoding UTF8
    Write-Host "   ✓ gestionComercios.sln creado (formato válido)" -ForegroundColor Green
} else {
    Write-Host "   ⚠ gestionComercios.sln ya existe, se omite" -ForegroundColor Yellow
}

# ============================================
# 2. ESTRUCTURA CLIENT (Blazor WebAssembly)
# ============================================
Write-Host ""
Write-Host "📁 Creando estructura Client/..." -ForegroundColor Yellow
$clientPath = Join-Path $projectRoot "src\Client"

# Subcarpetas en Client
$clientFolders = @(
    "Pages",
    "Components",
    "Services",
    "wwwroot\css",
    "wwwroot\js",
    "wwwroot\images",
    "wwwroot\lib"
)

foreach ($folder in $clientFolders) {
    $fullPath = Join-Path $clientPath $folder
    if (-not (Test-Path $fullPath)) {
        New-Item -Path $fullPath -ItemType Directory -Force | Out-Null
        Write-Host "   ✓ Carpeta: $folder" -ForegroundColor Green
    }
}

# Archivos en Client
$clientFiles = @(
    "Client.csproj",
    "Program.cs",
    "App.razor",
    "App.razor.css",
    "MainLayout.razor",
    "MainLayout.razor.css",
    "NavMenu.razor",
    "NavMenu.razor.css",
    "_Imports.razor",
    "wwwroot\index.html",
    "wwwroot\manifest.json",
    "wwwroot\service-worker.js",
    "wwwroot\favicon.ico",
    "wwwroot\css\app.css",
    "wwwroot\css\bootstrap\bootstrap.min.css",
    "wwwroot\css\bootstrap\bootstrap.min.css.map",
    "wwwroot\css\open-iconic\font\css\open-iconic-bootstrap.min.css"
)

foreach ($file in $clientFiles) {
    $fullPath = Join-Path $clientPath $file
    $dir = Split-Path $fullPath -Parent
    if (-not (Test-Path $dir)) {
        New-Item -Path $dir -ItemType Directory -Force | Out-Null
    }
    if (-not (Test-Path $fullPath)) {
        New-Item -Path $fullPath -ItemType File -Force | Out-Null
        Write-Host "   ✓ Archivo: $file" -ForegroundColor Green
    } else {
        Write-Host "   ⚠ Archivo: $file ya existe, se omite" -ForegroundColor Yellow
    }
}

# Páginas básicas en Client/Pages
$pages = @(
    "Index.razor",
    "Counter.razor",
    "FetchData.razor",
    "Error.razor"
)

foreach ($page in $pages) {
    $fullPath = Join-Path $clientPath "Pages\$page"
    if (-not (Test-Path $fullPath)) {
        New-Item -Path $fullPath -ItemType File -Force | Out-Null
        Write-Host "   ✓ Página: Pages\$page" -ForegroundColor Green
    }
}

# ============================================
# 3. ESTRUCTURA SHARED
# ============================================
Write-Host ""
Write-Host "📁 Creando estructura Shared/..." -ForegroundColor Yellow
$sharedPath = Join-Path $projectRoot "src\Shared"

# Subcarpetas en Shared
$sharedFolders = @(
    "Models",
    "Services",
    "Interfaces",
    "DTOs"
)

foreach ($folder in $sharedFolders) {
    $fullPath = Join-Path $sharedPath $folder
    if (-not (Test-Path $fullPath)) {
        New-Item -Path $fullPath -ItemType Directory -Force | Out-Null
        Write-Host "   ✓ Carpeta: $folder" -ForegroundColor Green
    }
}

# Archivos en Shared
$sharedFiles = @(
    "Shared.csproj",
    "_Imports.razor"
)

foreach ($file in $sharedFiles) {
    $fullPath = Join-Path $sharedPath $file
    if (-not (Test-Path $fullPath)) {
        New-Item -Path $fullPath -ItemType File -Force | Out-Null
        Write-Host "   ✓ Archivo: $file" -ForegroundColor Green
    } else {
        Write-Host "   ⚠ Archivo: $file ya existe, se omite" -ForegroundColor Yellow
    }
}

# ============================================
# 4. ARCHIVOS DE CONFIGURACIÓN
# ============================================
Write-Host ""
Write-Host "⚙️ Creando archivos de configuración..." -ForegroundColor Yellow

$configFiles = @(
    ".gitignore",
    ".editorconfig",
    "nuget.config"
)

foreach ($file in $configFiles) {
    $fullPath = Join-Path $projectRoot $file
    if (-not (Test-Path $fullPath)) {
        New-Item -Path $fullPath -ItemType File -Force | Out-Null
        Write-Host "   ✓ Config: $file" -ForegroundColor Green
    } else {
        Write-Host "   ⚠ Config: $file ya existe, se omite" -ForegroundColor Yellow
    }
}

# ============================================
# RESUMEN
# ============================================
Write-Host ""
Write-Host "✅ Estructura creada exitosamente!" -ForegroundColor Green
Write-Host ""
Write-Host "📋 Próximos pasos:" -ForegroundColor Cyan
Write-Host "   1. Abrir Visual Studio 2022" -ForegroundColor White
Write-Host "   2. Abrir la solución: gestionComercios.sln" -ForegroundColor White
Write-Host "   3. Agregar los proyectos Client.csproj y Shared.csproj a la solución" -ForegroundColor White
Write-Host "   4. Configurar referencias entre proyectos" -ForegroundColor White
Write-Host ""
Write-Host "💡 Los archivos están vacíos, listos para que el asistente agregue el código." -ForegroundColor Gray

