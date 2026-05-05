using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects;

public record Price
{
    public decimal Value { get; init; }

    public Price(decimal value)
    {
        if(value < 0)
            throw new DomainException("O preço não pode ser menor do que 0");

        Value = value;
    }
}
