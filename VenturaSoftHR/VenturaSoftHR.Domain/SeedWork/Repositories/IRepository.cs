﻿using VenturaSoftHR.Domain.SeedWork.Specification;

namespace VenturaSoftHR.Domain.SeedWork.Repositories;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetByCriteria(Specification<T> specification);
}