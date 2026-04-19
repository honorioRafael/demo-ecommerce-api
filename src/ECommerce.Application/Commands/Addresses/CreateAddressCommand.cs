using ECommerce.Application.DTOs.Addresses;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Addresses;

public record CreateAddressCommand(
    string Name,
    string Street,
    string Number,
    string? Complement,
    string Neighborhood,
    string City,
    string State,
    string Country,
    string ZipCode) : IRequest<ErrorOr<AddressDto>>;
