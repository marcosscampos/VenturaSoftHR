﻿using Microsoft.EntityFrameworkCore;
using VenturaSoftHR.Common;
using VenturaSoftHR.Domain.SeedWork.Entities;
using VenturaSoftHR.Domain.SeedWork.Repositories;
using VenturaSoftHR.Domain.SeedWork.Specification;
using VenturaSoftHR.Repository.Context;

namespace VenturaSoftHR.Repository;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> Entity;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        Entity = context.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await Entity.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        Entity.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Entity.OrderBy(x => x.CreationDate).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetByCriteria(Specification<T> specification)
    {
        var jobs = Entity.ToList().AsQueryable().Where(specification.ToExpression());
        return await Task.FromResult(jobs);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await Entity.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        Entity.Update(entity);
        await _context.SaveChangesAsync();
    }
}