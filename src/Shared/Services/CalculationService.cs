using Shared.DTOs;

namespace Shared.Services;

/// <summary>
/// Servicio para cálculos de negocio
/// </summary>
public class CalculationService : ICalculationService
{
    public decimal CalculateVentaTotal(List<DetalleVentaItemDto> detalles, decimal? descuento = null)
    {
        var subtotal = detalles.Sum(d => CalculateItemSubtotal(d.Cantidad, d.PrecioUnitario, d.Descuento));
        return subtotal - (descuento ?? 0);
    }

    public decimal CalculateCompraTotal(List<DetalleCompraItemDto> detalles, decimal? descuento = null)
    {
        var subtotal = detalles.Sum(d => CalculateItemSubtotal(d.Cantidad, d.PrecioUnitario, d.Descuento));
        return subtotal - (descuento ?? 0);
    }

    public decimal CalculateItemSubtotal(decimal cantidad, decimal precioUnitario, decimal? descuento = null)
    {
        var subtotal = cantidad * precioUnitario;
        return subtotal - (descuento ?? 0);
    }

    public decimal CalculatePercentageDiscount(decimal total, decimal percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentException("El porcentaje debe estar entre 0 y 100", nameof(percentage));

        return total * (percentage / 100);
    }

    public decimal CalculatePriceWithTax(decimal basePrice, decimal taxPercentage)
    {
        if (taxPercentage < 0)
            throw new ArgumentException("El porcentaje de impuesto no puede ser negativo", nameof(taxPercentage));

        return basePrice * (1 + taxPercentage / 100);
    }
}

