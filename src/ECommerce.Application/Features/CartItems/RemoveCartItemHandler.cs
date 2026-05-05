using ECommerce.Application.Commands.CartItems;
using ECommerce.Domain.Interfaces.Repositories;
using ErrorOr;
using MediatR;

namespace ECommerce.Application.Features.CartItems;

public class RemoveCartItemHandler(IUnitOfWork unitOfWork, ICartItemRepository cartItemRepository) : IRequestHandler<RemoveCartItemCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await cartItemRepository.GetByIdAsync(request.CartItemId, cancellationToken);
        if (cartItem is null)
            return Error.NotFound("CartItem.NotFound", "Item do carrinho não encontrado.");

        if (cartItem.UserId != request.UserId)
            return Error.Forbidden("CartItem.Forbidden", "O item do carrinho não pertence ao usuário logado.");

        cartItemRepository.Delete(cartItem);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}
