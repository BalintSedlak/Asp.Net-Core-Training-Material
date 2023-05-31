namespace Restaurant.DDD.SharedKernel;

public interface IAsyncRepository<T> where T : Entity
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken);

    Task<IReadOnlyList<T>> ListAllAsync(int perPage, int page, CancellationToken cancellationToken);

    Task<T> AddAsync(T entity, CancellationToken cancellationToken);

    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    Task DeleteAsync(T entity, CancellationToken cancellationToken);
}