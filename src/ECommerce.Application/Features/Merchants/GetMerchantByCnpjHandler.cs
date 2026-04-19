using ECommerce.Application.DTOs.Merchants;
using ECommerce.Application.Queries.Merchants;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Merchants;

public class GetMerchantByCnpjHandler(IMerchantRepository merchantRepository) : IRequestHandler<GetMerchantByCnpjQuery, ErrorOr<MerchantDto>>
{
    public async Task<ErrorOr<MerchantDto>> Handle(GetMerchantByCnpjQuery request, CancellationToken cancellationToken)
    {
        var merchant = await merchantRepository.GetByCnpjAsync(new Cnpj(request.Cnpj), cancellationToken);

        if (merchant is null)
            return Error.NotFound(code: "Merchant.NotFound", description: "Merchant not found.");

        return (MerchantDto)merchant;
    }
}
