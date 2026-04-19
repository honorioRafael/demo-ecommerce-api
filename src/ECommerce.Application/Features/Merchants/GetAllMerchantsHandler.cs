using ECommerce.Application.DTOs.Merchants;
using ECommerce.Application.Queries.Merchants;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Merchants;

public class GetAllMerchantsHandler(IMerchantRepository merchantRepository) : IRequestHandler<GetAllMerchantsQuery, ErrorOr<List<MerchantDto>>>
{
    public async Task<ErrorOr<List<MerchantDto>>> Handle(GetAllMerchantsQuery request, CancellationToken cancellationToken)
    {
        var merchants = await merchantRepository.GetAllAsync(request.PageIndex, request.PageSize, cancellationToken: cancellationToken);

        return merchants.Select(m => (MerchantDto)m).ToList();
    }
}
