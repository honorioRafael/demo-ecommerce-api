using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects;

public record ZipCode
{
    public string Value { get; init; }

    public ZipCode(string value)
    {
        if (string.IsNullOrEmpty(value) || !IsValid(value))
            throw new DomainException("O CEP é inválido. Informe exatamente 8 dígitos numéricos.");

        Value = value;
    }

    public static bool IsValid(string zipCode)
    {
        if (zipCode.Length != 8)
            return false;

        foreach (char c in zipCode)
        {
            if (!char.IsDigit(c))
                return false;
        }

        return true;
    }
}
