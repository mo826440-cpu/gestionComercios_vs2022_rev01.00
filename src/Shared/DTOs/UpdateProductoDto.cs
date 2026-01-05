namespace Shared.DTOs;

/// <summary>
/// DTO para actualizar un producto existente
/// </summary>
public class UpdateProductoDto
{
    public Guid? CategoriaId { get; set; }
    public Guid? MarcaId { get; set; }
    public string? Nombre { get; set; }
    public string? Codigo { get; set; }
    public string? Descripcion { get; set; }
    public decimal? PrecioVenta { get; set; }
    public decimal? PrecioCompra { get; set; }
    public bool? Activo { get; set; }
}

