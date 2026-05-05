using ECommerce.Application.Commands.CartItems;

namespace ECommerce.Api.Requests.CartItems;

public record AddItemToCartRequest(Guid ProductId, int Quantity)
{
    public AddItemToCartCommand ConvertToCommand(Guid loggedUserId) =>
        new AddItemToCartCommand(loggedUserId, ProductId, Quantity);
}
