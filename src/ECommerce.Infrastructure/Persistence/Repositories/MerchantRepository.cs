using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Domain.ValueObjects;
using ECommerce.Infrastructure.Persistence.Contexts;
using ECommerce.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Repositories;

public class MerchantRepository : BaseRepository<Merchant>, IMerchantRepository
{
    public MerchantRepository(AppDbContext context) : base(context) { }

    public async Task<Merchant?> GetByCnpjAsync(Cnpj cnpj, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Cnpj == cnpj, cancellationToken);
    }
}
