namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de validaciones
/// Proporciona métodos de validación para entidades del negocio
/// </summary>
public interface IValidationService
{
    /// <summary>
    /// Valida un email
    /// </summary>
    bool IsValidEmail(string? email);

    /// <summary>
    /// Valida que un número sea positivo
    /// </summary>
    bool IsPositiveNumber(decimal value);

    /// <summary>
    /// Valida que un string no esté vacío
    /// </summary>
    bool IsNotEmpty(string? value);

    /// <summary>
    /// Valida que un Guid no sea vacío
    /// </summary>
    bool IsValidGuid(Guid id);
}

