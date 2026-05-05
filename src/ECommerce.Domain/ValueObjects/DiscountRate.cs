using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects;

public record DiscountRate
{
    public decimal Value { get; init; }

    public DiscountRate(decimal value)
    {
        if (value < 0 || value > 100)
            throw new DomainException("A taxa de desconto deve ser entre 0 e 100.");

        Value = value;
    }

    public decimal CalculateAmount(decimal originalPrice)
            => originalPrice * (Value / 100);
}
