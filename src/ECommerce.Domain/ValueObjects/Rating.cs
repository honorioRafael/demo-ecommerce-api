using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects;

public record Rating
{
    public int Value { get; init; }

    public Rating(int value)
    {
        if(value < 0 || value > 5)
            throw new DomainException("A avaliação deve ser entre 0 e 5.");

        Value = value;
    }
}
