using ECommerce.Domain.Entities.Base;

namespace ECommerce.Domain.Interfaces.Repositories.Base;

public interface IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    #region Read
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(int pageIndex, int pageSize, bool asNoTracking = true, CancellationToken cancellationToken = default);
    #endregion

    #region Create
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<List<TEntity>> CreateBatchAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
    #endregion

    #region Update
    TEntity Update(TEntity entity);
    List<TEntity> UpdateBatch(List<TEntity> entities);
    #endregion

    #region Delete
    TEntity Delete(TEntity entity);
    List<TEntity> DeleteBatch(List<TEntity> entities);
    #endregion
}