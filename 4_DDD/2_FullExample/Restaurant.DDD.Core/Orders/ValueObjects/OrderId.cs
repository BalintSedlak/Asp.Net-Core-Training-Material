using Restaurant.DDD.Core.Errors;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Monads;

namespace Restaurant.DDD.Core.Products.ValueObjects;

public sealed class OrderId : AggregateId
{
    public OrderId(Guid guid): base(guid)
    {
    }

    public static Result<OrderId, DomainError> Create(Guid guid)
    {
        if (guid == Guid.Empty)
        {
            return DomainErrors.Order.EmptyGuid;
        }

        return new OrderId(guid);
    }

    protected override int GetValueHashCode()
    {
        return Id.GetHashCode();
    }

    protected override bool ValueEquals(AggregateId other)
    {
        return other is ProductId 
            && Id == other.Id;
    }
}
