using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}