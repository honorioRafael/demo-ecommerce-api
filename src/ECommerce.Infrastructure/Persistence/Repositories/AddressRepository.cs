using ECommerce.Application.Interfaces.Security;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Infrastructure.Persistence.Contexts;
using ECommerce.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Repositories;

public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    private readonly ICurrentUserService _currentUserService;

    public AddressRepository(AppDbContext context, ICurrentUserService currentUserService) : base(context)
    {
        _currentUserService = currentUserService;
    }

    public override async Task<List<Address>> GetAllAsync(int pageIndex, int pageSize, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        if (pageIndex < 0) throw new ArgumentOutOfRangeException(nameof(pageIndex));
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));

        var dbSet = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
        return await dbSet
            .Where(x => x.CreatedBy == _currentUserService.UserId)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}
