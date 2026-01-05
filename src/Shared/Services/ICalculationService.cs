using Shared.DTOs;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de cálculos
/// Proporciona métodos para cálculos de negocio
/// </summary>
public interface ICalculationService
{
    /// <summary>
    /// Calcula el total de una venta basado en sus detalles
    /// </summary>
    decimal CalculateVentaTotal(List<DetalleVentaItemDto> detalles, decimal? descuento = null);

    /// <summary>
    /// Calcula el total de una compra basado en sus detalles
    /// </summary>
    decimal CalculateCompraTotal(List<DetalleCompraItemDto> detalles, decimal? descuento = null);

    /// <summary>
    /// Calcula el subtotal de un item (cantidad * precio - descuento)
    /// </summary>
    decimal CalculateItemSubtotal(decimal cantidad, decimal precioUnitario, decimal? descuento = null);

    /// <summary>
    /// Calcula el descuento porcentual
    /// </summary>
    decimal CalculatePercentageDiscount(decimal total, decimal percentage);

    /// <summary>
    /// Calcula el precio con IVA (si aplica)
    /// </summary>
    decimal CalculatePriceWithTax(decimal basePrice, decimal taxPercentage);
}

