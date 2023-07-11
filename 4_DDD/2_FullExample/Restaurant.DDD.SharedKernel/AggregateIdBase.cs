using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.Core.Products.ValueObjects;

public abstract class AggregateId : ValueObject<AggregateId>
{
    public Guid Id { get; set; }

    protected AggregateId(Guid guid)
    {
        Id = guid;
    }
}