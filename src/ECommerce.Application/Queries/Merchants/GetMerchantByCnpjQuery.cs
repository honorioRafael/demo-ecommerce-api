using ECommerce.Application.DTOs.Merchants;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Queries.Merchants;

public record GetMerchantByCnpjQuery(string Cnpj) : IRequest<ErrorOr<MerchantDto>>;
