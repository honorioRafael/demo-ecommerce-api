using ECommerce.Application.Commands.Merchants;

namespace ECommerce.Api.Requests.Merchants;

public record CreateMerchantRequest(string TradeName, string LegalName, string Cnpj)
{
    public CreateMerchantCommand ConvertToCommand(Guid loggedUserId) =>
        new CreateMerchantCommand(TradeName, LegalName, Cnpj, loggedUserId);
}
