using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Merchants;

public record UpdateMerchantCommand(
    Guid Id,
    string TradeName,
    string LegalName,
    string Cnpj) : IRequest<ErrorOr<Success>>;
