using Microsoft.EntityFrameworkCore;
using Restaurant.DDD.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.DDD.Infrasturcture.Repository;
public class EfRepository<T> : IAsyncRepository<T> where T : Entity
{
    protected readonly RestaurantContext _context;

    public EfRepository(RestaurantContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        try
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            //TODO
            throw;
        }

        return entity;
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<T>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(int perPage, int page, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().Skip(perPage * (page - 1)).Take(perPage).ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}