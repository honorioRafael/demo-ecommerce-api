using ECommerce.Application.DTOs.Addresses;
using ECommerce.Application.Queries.Addresses;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Addresses;

public class GetAddressByIdHandler(IAddressRepository addressRepository) : IRequestHandler<GetAddressByIdQuery, ErrorOr<AddressDto>>
{
    public async Task<ErrorOr<AddressDto>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var address = await addressRepository.GetByIdAsync(request.Id, cancellationToken);
        if (address is null)
            return Error.NotFound(code: "Address.NotFound", description: "Address not found.");

        return (AddressDto)address;
    }
}
