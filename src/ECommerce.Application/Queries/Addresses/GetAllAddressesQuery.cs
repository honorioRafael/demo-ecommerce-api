using ECommerce.Application.DTOs.Addresses;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Addresses;

public record GetAllAddressesQuery(int PageIndex, int PageSize) : IRequest<ErrorOr<List<AddressDto>>>;
