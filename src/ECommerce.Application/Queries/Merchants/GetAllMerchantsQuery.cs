using ECommerce.Application.DTOs.Merchants;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Merchants;

public record GetAllMerchantsQuery(int PageIndex, int PageSize) : IRequest<ErrorOr<List<MerchantDto>>>;
