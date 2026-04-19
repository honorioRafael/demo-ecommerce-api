using ECommerce.Application.DTOs.Addresses;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Addresses;

public record GetAddressByIdQuery(Guid Id) : IRequest<ErrorOr<AddressDto>>;
