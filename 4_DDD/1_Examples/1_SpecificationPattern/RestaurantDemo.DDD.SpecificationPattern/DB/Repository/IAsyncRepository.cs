using RestaurantDemo.DDD.SpecificationPattern.DB.Entities;
using RestaurantDemo.DDD.SpecificationPattern.Specifications;

namespace RestaurantDemo.DDD.SpecificationPattern.DB.Repository;
public interface IAsyncRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<T>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<T>> ListAllAsync(CancellationToken cancellationToken);

    Task<IReadOnlyCollection<T>> ListAllAsync(int perPage, int page, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<T>> GetBySpecificationAsync(Specification<T> specification, CancellationToken cancellationToken);

    Task<T> AddAsync(T entity, CancellationToken cancellationToken);

    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    Task DeleteAsync(T entity, CancellationToken cancellationToken);
}