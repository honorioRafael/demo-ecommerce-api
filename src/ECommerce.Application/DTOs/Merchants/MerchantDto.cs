using ECommerce.Domain.Entities;

namespace ECommerce.Application.DTOs.Merchants;

public record MerchantDto(
    Guid Id,
    string TradeName,
    string LegalName,
    string Cnpj)
{
    public static implicit operator MerchantDto(Merchant merchant)
    {
        return new MerchantDto(
            merchant.Id,
            merchant.TradeName,
            merchant.LegalName,
            merchant.Cnpj.Value);
    }
}
