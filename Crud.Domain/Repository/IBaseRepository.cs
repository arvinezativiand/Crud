﻿using Crud.Domain.DTOs;
using Crud.Domain.Entities;

namespace Crud.Domain.Repository;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(ulong Id);
    Task<TEntity?> GetByIdAsync(ulong id);
    Task<PaginationResponse<IEnumerable<TEntity>>> GetAllAsync(int skip, int take);

}

