namespace Subscriber.Repository;

public interface IRepository<T>
{
    void Add(T item);
    IReadOnlyCollection<T> GetAll();
}
