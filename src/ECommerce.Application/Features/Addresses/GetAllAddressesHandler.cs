using ECommerce.Application.DTOs.Addresses;
using ECommerce.Application.Queries.Addresses;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Addresses;

public class GetAllAddressesHandler(IAddressRepository addressRepository) : IRequestHandler<GetAllAddressesQuery, ErrorOr<List<AddressDto>>>
{
    public async Task<ErrorOr<List<AddressDto>>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
    {
        var addresses = await addressRepository.GetAllAsync(request.PageIndex, request.PageSize, cancellationToken: cancellationToken);

        return addresses.Select(a => (AddressDto)a).ToList();
    }
}
