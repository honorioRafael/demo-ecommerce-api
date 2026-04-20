using ECommerce.Application.Commands.Addresses;
using ECommerce.Application.DTOs.Addresses;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.Addresses;

public class CreateAddressHandler(IAddressRepository addressRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateAddressCommand, ErrorOr<AddressDto>>
{
    public async Task<ErrorOr<AddressDto>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        Address address = new Address(request.Name, request.Street, request.Number, request.Complement, request.Neighborhood, request.City, request.State, request.Country, new ZipCode(request.ZipCode));

        await addressRepository.CreateAsync(address, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return (AddressDto)address;
    }
}
