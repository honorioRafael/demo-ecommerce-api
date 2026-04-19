using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Merchants;

public record DeleteMerchantCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
