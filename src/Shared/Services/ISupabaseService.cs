using global::Supabase;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de Supabase
/// Proporciona acceso al cliente de Supabase configurado
/// </summary>
public interface ISupabaseService
{
    /// <summary>
    /// Cliente de Supabase configurado y listo para usar
    /// </summary>
    global::Supabase.Client Client { get; }
}
