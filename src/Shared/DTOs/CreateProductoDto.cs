namespace Shared.DTOs;

/// <summary>
/// DTO para crear un nuevo producto
/// </summary>
public class CreateProductoDto
{
    public Guid ComercioId { get; set; }
    public Guid? CategoriaId { get; set; }
    public Guid? MarcaId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Codigo { get; set; }
    public string? Descripcion { get; set; }
    public decimal PrecioVenta { get; set; }
    public decimal? PrecioCompra { get; set; }
    public bool Activo { get; set; } = true;
}

