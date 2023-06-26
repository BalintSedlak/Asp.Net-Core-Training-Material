using Microsoft.EntityFrameworkCore;
using RestaurantDemo.DDD.SpecificationPattern.DB.Entities;
using RestaurantDemo.DDD.SpecificationPattern.Specifications;

namespace RestaurantDemo.DDD.SpecificationPattern.DB.Repository;

public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
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

    public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<T>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
    }

    public async Task<IReadOnlyCollection<T>> ListAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<T>> ListAllAsync(int perPage, int page, CancellationToken cancellationToken)
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

    public async Task<IReadOnlyCollection<T>> GetBySpecificationAsync(Specification<T> specification, CancellationToken cancellationToken)
    {
        IQueryable<T> result = await ApplySpecification(specification);
        return result.ToList();
    }

    private async Task<IQueryable<T>> ApplySpecification(
        Specification<T> specification)
    {
        return SpecificationEvaluator.GetQuery(
            _context.Set<T>(),
            specification);
    }

    
}