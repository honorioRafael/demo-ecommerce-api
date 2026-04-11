using ECommerce.Domain.Entities.Base;
using ECommerce.Domain.Interfaces.Repositories.Base;
using ECommerce.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Repositories.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    #region Read
    public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync([id], cancellationToken);
    }

    public virtual async Task<List<TEntity>> GetAllAsync(int pageIndex, int pageSize, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        if (pageIndex < 0) throw new ArgumentOutOfRangeException(nameof(pageIndex));
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));

        var dbSet = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
        return await dbSet.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync(cancellationToken);
    }
    #endregion

    #region Create
    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task<List<TEntity>> CreateBatchAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
        return entities;
    }
    #endregion

    #region Update
    public virtual TEntity Update(TEntity entity)
    {
        _dbSet.Update(entity);
        return entity;
    }

    public virtual List<TEntity> UpdateBatch(List<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
        return entities;
    }
    #endregion

    #region Delete
    public virtual TEntity Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        return entity;
    }

    public virtual List<TEntity> DeleteBatch(List<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
        return entities;
    }
    #endregion

    #region SaveChanges
    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
    #endregion
}