namespace Subscriber.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    List<T> _itemList;

    public Repository()
    {
        _itemList= new List<T>();
    }

    public void Add(T item)
    {
        _itemList.Add(item);
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return _itemList;
    }
}
