using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Infrastructure.Persistence.Contexts;
using ECommerce.Infrastructure.Persistence.Repositories.Base;

namespace ECommerce.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }

    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(user, cancellationToken);
        return user;
    }
}
