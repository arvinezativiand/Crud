using Crud.Domain.Entities;
using Crud.Domain.Repository;
using Crud.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Crud.Infrastructure.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly RPouyaDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    public BaseRepository(RPouyaDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        DateTimeOffset time = DateTimeOffset.Now;
        entity.CreatedAt = time;
        entity.UpdatedAt = time;

        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(ulong Id)
    {
        TEntity? entity = await GetByIdAsync(Id);
        if (entity != null)
            _dbSet.Remove(entity);

        await _dbContext.SaveChangesAsync();
        return entity != null;
    }

    public async Task<IEnumerable<TEntity>?> GetAllAsync()
    {
        return await _dbSet.ToListAsync<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(ulong id)
    {
        return await _dbSet.FirstOrDefaultAsync(a => a.Id.Equals(id));
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DateTimeOffset time = DateTimeOffset.Now;
        entity.UpdatedAt = time;

        await _dbContext.SaveChangesAsync();
        return entity;
    }
}
