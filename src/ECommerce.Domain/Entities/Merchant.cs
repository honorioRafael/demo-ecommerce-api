using ECommerce.Domain.Entities.Base;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;

public class Merchant : BaseEntity
{
    public string TradeName { get; private set; } = null!;
    public string LegalName { get; private set; } = null!;
    public Cnpj Cnpj { get; private set; } = null!;

    protected Merchant() { }

    public Merchant(string tradeName, string legalName, Cnpj cnpj)
    {
        TradeName = tradeName;
        LegalName = legalName;
        Cnpj = cnpj;
    }

    public void Update(string tradeName, string legalName, Cnpj cnpj)
    {
        TradeName = tradeName;
        LegalName = legalName;
        Cnpj = cnpj;
    }
}
