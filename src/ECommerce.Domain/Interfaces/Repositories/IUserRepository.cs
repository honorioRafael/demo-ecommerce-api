using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories.Base;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
}