using ErrorOr;
using MediatR;

namespace ECommerce.Application.Commands.CartItems;

public record AddItemToCartCommand(Guid UserId, Guid ProductId, int Quantity) : IRequest<ErrorOr<Success>>;
