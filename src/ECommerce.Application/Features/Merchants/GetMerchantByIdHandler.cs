using ECommerce.Application.DTOs.Merchants;
using ECommerce.Application.Queries.Merchants;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Merchants;

public class GetMerchantByIdHandler(IMerchantRepository merchantRepository) : IRequestHandler<GetMerchantByIdQuery, ErrorOr<MerchantDto>>
{
    public async Task<ErrorOr<MerchantDto>> Handle(GetMerchantByIdQuery request, CancellationToken cancellationToken)
    {
        var merchant = await merchantRepository.GetByIdAsync(request.Id, cancellationToken);

        if (merchant is null)
            return Error.NotFound(code: "Merchant.NotFound", description: "Merchant not found.");

        return (MerchantDto)merchant;
    }
}
