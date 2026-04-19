using ECommerce.Application.Commands.Addresses;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Addresses;

public class DeleteAddressHandler(IAddressRepository addressRepository) : IRequestHandler<DeleteAddressCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        Address? address = await addressRepository.GetByIdAsync(request.Id, cancellationToken);
        if (address is null)
            return Error.NotFound(code: "Address.NotFound", description: "Address not found.");

        addressRepository.Delete(address);
        await addressRepository.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}
