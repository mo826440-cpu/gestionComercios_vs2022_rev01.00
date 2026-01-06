# Script para build de producción
# Este script construye la aplicación Blazor para producción

param(
    [string]$SupabaseUrl = "",
    [string]$SupabaseAnonKey = ""
)

Write-Host "🚀 Building Blazor WebAssembly for Production..." -ForegroundColor Green

# Ruta del proyecto
$projectPath = "src\Client\Client.csproj"
$outputPath = "publish"

# Verificar que existe el proyecto
if (-not (Test-Path $projectPath)) {
    Write-Host "❌ Error: No se encuentra el proyecto en $projectPath" -ForegroundColor Red
    exit 1
}

# Si se proporcionan valores, actualizar appsettings.Production.json
if ($SupabaseUrl -and $SupabaseAnonKey) {
    Write-Host "📝 Actualizando appsettings.Production.json..." -ForegroundColor Yellow
    
    $appsettingsPath = "src\Client\wwwroot\appsettings.Production.json"
    $appsettings = @{
        Supabase = @{
            Url = $SupabaseUrl
            AnonKey = $SupabaseAnonKey
        }
        Logging = @{
            LogLevel = @{
                Default = "Warning"
                Microsoft.AspNetCore = "Warning"
                Microsoft.AspNetCore.Components = "Warning"
            }
        }
    } | ConvertTo-Json -Depth 10
    
    $appsettings | Set-Content -Path $appsettingsPath -Encoding UTF8
    Write-Host "✅ appsettings.Production.json actualizado" -ForegroundColor Green
}

# Limpiar build anterior
if (Test-Path $outputPath) {
    Write-Host "🧹 Limpiando build anterior..." -ForegroundColor Yellow
    Remove-Item -Path $outputPath -Recurse -Force
}

# Build y Publish
Write-Host "🔨 Compilando proyecto..." -ForegroundColor Yellow
dotnet publish $projectPath -c Release -o $outputPath

if ($LASTEXITCODE -eq 0) {
    Write-Host "✅ Build completado exitosamente!" -ForegroundColor Green
    Write-Host "📦 Archivos generados en: $outputPath\wwwroot" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "📋 Próximos pasos:" -ForegroundColor Yellow
    Write-Host "   1. Revisar los archivos en $outputPath\wwwroot"
    Write-Host "   2. Subir a tu hosting (Netlify, Azure, etc.)"
    Write-Host "   3. Configurar dominio personalizado si es necesario"
} else {
    Write-Host "❌ Error en el build" -ForegroundColor Red
    exit 1
}


