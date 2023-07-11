using Restaurant.DDD.Core.Products.ValueObjects;

namespace Restaurant.DDD.SharedKernel;

public abstract class AggregateRoot<T> : Entity where T : AggregateId
{
    public AggregateId IdObject { get; }

    protected AggregateRoot(AggregateId idObject) : base(idObject.Id)
    {
        IdObject = idObject;
    }

    //protected AggregateRoot()
    //{

    //}

    //TODO: DomainEvents

    //private List<DomainEvent> _domainEvents;
    //public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    //protected void AddDomainEvent(DomainEvent eventItem)
    //{
    //    _domainEvents = _domainEvents ?? new List<DomainEvent>();
    //    _domainEvents.Add(eventItem);
    //}

    //public void ClearDomainEvents()
    //{
    //    _domainEvents?.Clear();
    //}
}
