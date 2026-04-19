using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories.Base;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Interfaces.Repositories;

public interface IMerchantRepository : IBaseRepository<Merchant>
{
    Task<Merchant?> GetByCnpjAsync(Cnpj cnpj, CancellationToken cancellationToken = default);
}
