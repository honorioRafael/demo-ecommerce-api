using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories.Base;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository
{
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
}
