using ECommerce.Application.Commands.Addresses;

namespace ECommerce.Api.Requests.Addresses;

public record UpdateAddressRequest(
    string Name,
    string Street,
    string Number,
    string? Complement,
    string Neighborhood,
    string City,
    string State,
    string Country,
    string ZipCode)
{
    public UpdateAddressCommand ConvertToCommand(Guid id) =>
        new UpdateAddressCommand(id, Name, Street, Number, Complement, Neighborhood, City, State, Country, ZipCode);
}
