namespace ECommerce.Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }

    public static void ThrowWhen(bool hasError, string error)
    {
        if (hasError)
        {
            throw new DomainException(error);
        }
    }
}