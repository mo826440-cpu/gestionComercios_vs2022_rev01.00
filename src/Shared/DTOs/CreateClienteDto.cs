namespace Shared.DTOs;

/// <summary>
/// DTO para crear un nuevo cliente
/// </summary>
public class CreateClienteDto
{
    public Guid ComercioId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public bool Activo { get; set; } = true;
}

