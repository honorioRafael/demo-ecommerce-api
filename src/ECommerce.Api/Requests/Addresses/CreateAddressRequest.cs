using ECommerce.Application.Commands.Addresses;

namespace ECommerce.Api.Requests.Addresses;

public record CreateAddressRequest(
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
    public CreateAddressCommand ConvertToCommand() =>
        new CreateAddressCommand(Name, Street, Number, Complement, Neighborhood, City, State, Country, ZipCode);
}
