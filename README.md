# Gestión Comercios - Blazor WebAssembly + Supabase

Sistema de gestión para comercios desarrollado con Blazor WebAssembly y Supabase.

## 🚀 Stack Tecnológico

- **Frontend:** Blazor WebAssembly (.NET 8.0) + PWA
- **Backend:** Supabase (PostgreSQL + Auth)
- **Autenticación:** Supabase Auth + RBAC
- **Almacenamiento Local:** IndexedDB (offline-first)
- **Hosting:** Cloudflare Pages (gratis)

## 📋 Características

- ✅ Gestión de comercios, usuarios, productos, clientes
- ✅ Ventas y compras con detalles
- ✅ Control de stock
- ✅ Autenticación y autorización (RBAC)
- ✅ Soporte offline con sincronización automática
- ✅ PWA (instalable en dispositivos)
- ✅ Responsive design

## 🛠️ Requisitos

- .NET 8.0 SDK
- Visual Studio 2022 (recomendado) o VS Code
- Cuenta de Supabase
- Cuenta de GitHub (para deployment)

## 📦 Instalación

1. Clonar el repositorio:
```bash
git clone https://github.com/mo826440-cpu/gestionComercios_vs2022_rev01.00.git
```

2. Restaurar dependencias:
```bash
dotnet restore
```

3. Configurar `src/Client/wwwroot/appsettings.json` con tus credenciales de Supabase

4. Ejecutar:
```bash
cd src/Client
dotnet run
```

## 📚 Documentación

- [Checklist del Proyecto](docs/06_cursor_checklist.md)
- [Guía de Deployment](docs/09_deployment_guide.md)
- [Setup Rápido Cloudflare](docs/09_cloudflare_setup_quick.md)

## 🔧 Desarrollo

El proyecto está organizado en:

- `src/Client/` - Aplicación Blazor WebAssembly
- `src/Shared/` - Código compartido (modelos, servicios, DTOs)
- `docs/` - Documentación del proyecto
- `scripts/` - Scripts de utilidad

## 📝 Licencia

[Especificar licencia si corresponde]

