using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;
using Supabase.Postgrest.Responses;

namespace Shared.Services;

/// <summary>
/// Servicio para gestionar usuarios
/// Implementa operaciones CRUD usando Supabase PostgREST
/// </summary>
public class UsuarioService : IUsuarioService
{
    private readonly ISupabaseService _supabaseService;

    public UsuarioService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Usuario>> GetAllAsync(Guid comercioId)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.ComercioId == comercioId)
            .Get();

        return response.Models;
    }

    public async Task<Usuario?> GetByIdAsync(Guid id)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.Id == id)
            .Single();

        return response;
    }

    public async Task<Usuario?> GetByAuthUserIdAsync(Guid authUserId)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.AuthUserId == authUserId)
            .Single();

        return response;
    }

    public async Task<Usuario> CreateAsync(Usuario usuario)
    {
        // Validar que el usuario (nombre de usuario) sea único en el comercio
        if (!string.IsNullOrWhiteSpace(usuario.NombreUsuario))
        {
            var usuariosExistentes = await GetAllAsync(usuario.ComercioId);
            if (usuariosExistentes.Any(u => u.NombreUsuario != null && 
                u.NombreUsuario.Equals(usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase) && 
                u.Id != usuario.Id))
            {
                throw new InvalidOperationException($"El nombre de usuario '{usuario.NombreUsuario}' ya está en uso en este comercio.");
            }
        }

        var response = await _supabaseService.Client
            .From<Usuario>()
            .Insert(usuario);

        return response.Models.FirstOrDefault() ?? usuario;
    }

    /// <summary>
    /// Verifica si un nombre de usuario está disponible en un comercio
    /// </summary>
    public async Task<bool> IsUsuarioDisponibleAsync(Guid comercioId, string usuario, Guid? excludeUsuarioId = null)
    {
        var usuarios = await GetAllAsync(comercioId);
        return !usuarios.Any(u => 
            u.NombreUsuario != null && 
            u.NombreUsuario.Equals(usuario, StringComparison.OrdinalIgnoreCase) && 
            (excludeUsuarioId == null || u.Id != excludeUsuarioId.Value));
    }

    /// <summary>
    /// Obtiene un usuario por su nombre de usuario y comercio
    /// </summary>
    public async Task<Usuario?> GetByUsuarioAsync(Guid comercioId, string usuario)
    {
        try
        {
            var response = await _supabaseService.Client
                .From<Usuario>()
                .Where(x => x.ComercioId == comercioId && x.NombreUsuario == usuario)
                .Single();

            return response;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        // Validar que el usuario (nombre de usuario) sea único en el comercio (si cambió)
        if (!string.IsNullOrWhiteSpace(usuario.NombreUsuario))
        {
            var usuariosExistentes = await GetAllAsync(usuario.ComercioId);
            if (usuariosExistentes.Any(u => u.NombreUsuario != null && 
                u.NombreUsuario.Equals(usuario.NombreUsuario, StringComparison.OrdinalIgnoreCase) && 
                u.Id != usuario.Id))
            {
                throw new InvalidOperationException($"El nombre de usuario '{usuario.NombreUsuario}' ya está en uso en este comercio.");
            }
        }

        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.Id == usuario.Id)
            .Set(x => x.RolId, usuario.RolId)
            .Set(x => x.Nombre, usuario.Nombre)
            .Set(x => x.NombreUsuario, usuario.NombreUsuario)
            .Set(x => x.Contacto, usuario.Contacto)
            .Set(x => x.Referencias, usuario.Referencias)
            .Set(x => x.IdPublico, usuario.IdPublico)
            .Set(x => x.Activo, usuario.Activo)
            .Set(x => x.EsPropietario, usuario.EsPropietario)
            .Set(x => x.UpdatedAt, DateTime.UtcNow)
            .Update();

        return response.Models.FirstOrDefault() ?? usuario;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.Id == id)
            .Delete();
    }

    public async Task<List<Usuario>> GetByRolAsync(Guid comercioId, Guid rolId)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.ComercioId == comercioId && x.RolId == rolId)
            .Get();

        return response.Models;
    }
}

