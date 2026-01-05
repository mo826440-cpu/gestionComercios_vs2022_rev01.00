using System.Text.RegularExpressions;

namespace Shared.Services;

/// <summary>
/// Servicio para validaciones comunes
/// </summary>
public class ValidationService : IValidationService
{
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public bool IsValidEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        return EmailRegex.IsMatch(email);
    }

    public bool IsPositiveNumber(decimal value)
    {
        return value > 0;
    }

    public bool IsNotEmpty(string? value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }

    public bool IsValidGuid(Guid id)
    {
        return id != Guid.Empty;
    }
}

