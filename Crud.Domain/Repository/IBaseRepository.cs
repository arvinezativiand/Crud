namespace Crud.Domain.Repository;

public interface IBaseRepository<TEntity>
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, int chunk = 100);

    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(ulong id);

    Task<TEntity?> GetByIdAsync(ulong id);
    Task<IList<TEntity>?> GetAllAsync();

}

