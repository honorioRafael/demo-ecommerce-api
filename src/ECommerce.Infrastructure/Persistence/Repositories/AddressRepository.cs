using ECommerce.Domain.Entities;
using ECommerce.Domain.Interfaces.Repositories;
using ECommerce.Infrastructure.Persistence.Contexts;
using ECommerce.Infrastructure.Persistence.Repositories.Base;

namespace ECommerce.Infrastructure.Persistence.Repositories;

public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext context) : base(context) { }
}
