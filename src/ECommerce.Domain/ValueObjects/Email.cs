using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects;

public record Email
{
    public string Value { get; init; }

    public Email(string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            throw new DomainException("O Email é inválido.");

        Value = value;
    }
}
