using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.CartItems;

public record RemoveCartItemCommand(Guid CartItemId, Guid UserId) : IRequest<ErrorOr<Deleted>>;
