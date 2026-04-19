using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects;

public record Cpf
{
    public string Value { get; init; }

    public Cpf(string value)
    {
        if (string.IsNullOrEmpty(value) || !IsMathematicallyValid(value))
            throw new DomainException("O Cpf é inválido.");

        Value = value;
    }

    public static Cpf? TryParse(string? value)
    {
        if (string.IsNullOrEmpty(value))
            return null;

        return new Cpf(value);
    }

    private static bool IsMathematicallyValid(string cpf)
    {
        if (cpf.Length != 11)
            return false;

        bool todosIguais = true;
        for (int i = 1; i < 11; i++)
        {
            if (cpf[i] != cpf[0])
            {
                todosIguais = false;
                break;
            }
        }
        if (todosIguais) return false;

        int soma1 = 0;
        int soma2 = 0;

        for (int i = 0; i < 9; i++)
        {
            int digito = cpf[i] - '0';
            soma1 += digito * (10 - i);
            soma2 += digito * (11 - i);
        }

        int resto1 = (soma1 * 10) % 11;
        if (resto1 == 10) resto1 = 0;

        if (resto1 != (cpf[9] - '0'))
            return false;

        soma2 += resto1 * 2;
        int resto2 = (soma2 * 10) % 11;
        if (resto2 == 10) resto2 = 0;

        return resto2 == (cpf[10] - '0');
    }
}
