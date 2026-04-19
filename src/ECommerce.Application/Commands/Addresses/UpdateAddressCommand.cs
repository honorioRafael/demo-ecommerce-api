using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Addresses;

public record UpdateAddressCommand(
    Guid Id,
    string Name,
    string Street,
    string Number,
    string? Complement,
    string Neighborhood,
    string City,
    string State,
    string Country,
    string ZipCode) : IRequest<ErrorOr<Success>>;
