using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.ValueObjects;

public record Cnpj
{
    public string Value { get; init; }

    public Cnpj(string value)
    {
        if (string.IsNullOrEmpty(value) || !IsValid(value))
            throw new DomainException("O CNPJ é inválido.");

        Value = value;
    }

    public static bool IsValid(string cnpj)
    {
        if (cnpj.Length != 14)
            return false;

        // Rejeita sequências repetidas (ex: 00000000000000)
        bool todosIguais = true;
        for (int i = 1; i < 14; i++)
        {
            if (cnpj[i] != cnpj[0])
            {
                todosIguais = false;
                break;
            }
        }
        if (todosIguais) return false;

        // Primeiro dígito verificador
        int[] peso1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int soma1 = 0;
        for (int i = 0; i < 12; i++)
            soma1 += (cnpj[i] - '0') * peso1[i];

        int resto1 = soma1 % 11;
        int digito1 = resto1 < 2 ? 0 : 11 - resto1;

        if (digito1 != (cnpj[12] - '0'))
            return false;

        // Segundo dígito verificador
        int[] peso2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int soma2 = 0;
        for (int i = 0; i < 13; i++)
            soma2 += (cnpj[i] - '0') * peso2[i];

        int resto2 = soma2 % 11;
        int digito2 = resto2 < 2 ? 0 : 11 - resto2;

        return digito2 == (cnpj[13] - '0');
    }
}
