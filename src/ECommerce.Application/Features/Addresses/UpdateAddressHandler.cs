using ECommerce.Application.Commands.Addresses;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Addresses;

public class UpdateAddressHandler(IAddressRepository addressRepository) : IRequestHandler<UpdateAddressCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        Address? address = await addressRepository.GetByIdAsync(request.Id, cancellationToken);
        if (address is null)
            return Error.NotFound(code: "Address.NotFound", description: "Address not found.");

        address.Update(request.Name, request.Street, request.Number, request.Complement, request.Neighborhood, request.City, request.State, request.Country, new ZipCode(request.ZipCode));

        addressRepository.Update(address);
        await addressRepository.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }
}
