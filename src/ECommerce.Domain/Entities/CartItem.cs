using ECommerce.Domain.Entities.Base;
using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid UserId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    #region Navigation Properties
    public Product Product { get; private set; } = null!;
    #endregion

    protected CartItem() { }

    public CartItem(Guid userId, Guid productId, int quantity)
    {
        if (quantity < 1)
            throw new DomainException("O item do carrinho deve ter ao menos um item");

        UserId = userId;
        ProductId = productId;
        Quantity = quantity;
    }

    public void AddQuantity(int quantity)
    {
        if (quantity < 1)
            throw new DomainException("A quantidade a ser adicionada deve ser maior que zero");

        Quantity += quantity;
    }

    public void ChangeQuantity(int quantity)
    {
        if (quantity < 1)
            throw new DomainException("A quantidade deve ser maior que zero");

        Quantity = quantity;
    }
}
