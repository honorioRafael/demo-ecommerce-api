using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects;

public record Cpf
{
    public string Value { get; init; }

    public Cpf(string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            throw new DomainException("O Cpf é inválido.");

        Value = value;
    }
}
