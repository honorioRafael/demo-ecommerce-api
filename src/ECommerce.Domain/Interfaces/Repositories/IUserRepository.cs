using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories.Base;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository
{
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
}
