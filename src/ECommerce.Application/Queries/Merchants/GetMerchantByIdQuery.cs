using ECommerce.Application.DTOs.Merchants;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Merchants;

public record GetMerchantByIdQuery(Guid Id) : IRequest<ErrorOr<MerchantDto>>;
