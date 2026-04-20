using ECommerce.Application.DTOs.Merchants;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Merchants;

public record CreateMerchantCommand(string TradeName, string LegalName, string Cnpj, Guid LoggedUserId) : IRequest<ErrorOr<MerchantDto>>;
