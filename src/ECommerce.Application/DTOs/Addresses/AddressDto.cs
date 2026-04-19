using ECommerce.Domain.Entities;

namespace ECommerce.Application.DTOs.Addresses;

public record AddressDto(
    Guid Id,
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
    public static implicit operator AddressDto(Address address)
    {
        return new AddressDto(
            address.Id,
            address.Name,
            address.Street,
            address.Number,
            address.Complement,
            address.Neighborhood,
            address.City,
            address.State,
            address.Country,
            address.ZipCode.Value);
    }
}
