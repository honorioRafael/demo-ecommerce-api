using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.Merchants;

public record AddUserToMerchantCommand(Guid MerchantId, Guid UserId) : IRequest<ErrorOr<Success>>;