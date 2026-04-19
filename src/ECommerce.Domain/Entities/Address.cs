using ECommerce.Domain.Entities.Base;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;

public class Address : BaseEntity
{
    public string Name { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string Number { get; private set; } = null!;
    public string? Complement { get; private set; }
    public string Neighborhood { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public ZipCode ZipCode { get; private set; } = null!;

    protected Address() { }

    public Address(string name, string street, string number, string? complement, string neighborhood, string city, string state, string country, ZipCode zipCode)
    {
        Name = name;
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public void Update(string name, string street, string number, string? complement, string neighborhood, string city, string state, string country, ZipCode zipCode)
    {
        Name = name;
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }
}
