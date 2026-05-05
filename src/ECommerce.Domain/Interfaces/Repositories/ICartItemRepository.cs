using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories.Base;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface ICartItemRepository : IBaseRepository<CartItem>
{
    Task<CartItem?> GetByProductIdAsync(Guid userId, Guid productId, CancellationToken cancellationToken = default);
}
