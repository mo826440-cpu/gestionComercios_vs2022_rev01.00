namespace Shared.Models;

/// <summary>
/// Modelo para la tabla logs_sistema
/// Representa un log/registro de eventos del sistema
/// </summary>
public class LogSistema
{
    public Guid Id { get; set; }
    public Guid ComercioId { get; set; } // FK a comercios
    public Guid? UsuarioId { get; set; } // FK a usuarios
    public string Tipo { get; set; } = string.Empty; // "info", "warning", "error", etc.
    public string Mensaje { get; set; } = string.Empty;
    public string? Detalles { get; set; }
    public DateTime CreatedAt { get; set; }
}

