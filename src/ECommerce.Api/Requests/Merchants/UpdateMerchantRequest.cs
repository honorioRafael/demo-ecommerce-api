using ECommerce.Application.Commands.Merchants;

namespace ECommerce.Api.Requests.Merchants;

public record UpdateMerchantRequest(string TradeName, string LegalName, string Cnpj)
{
    public UpdateMerchantCommand ConvertToCommand(Guid id) =>
        new UpdateMerchantCommand(id, TradeName, LegalName, Cnpj);
}
