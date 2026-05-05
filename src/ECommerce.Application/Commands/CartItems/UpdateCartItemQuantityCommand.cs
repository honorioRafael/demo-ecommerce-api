using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.CartItems;

public record UpdateCartItemQuantityCommand(Guid CartItemId, Guid UserId, int Quantity) : IRequest<ErrorOr<Success>>;
