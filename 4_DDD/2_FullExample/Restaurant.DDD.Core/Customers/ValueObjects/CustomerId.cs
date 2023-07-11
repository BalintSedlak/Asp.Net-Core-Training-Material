using Restaurant.DDD.Core.Errors;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Monads;

namespace Restaurant.DDD.Core.Products.ValueObjects;

public sealed class CustomerId : AggregateId
{
    public CustomerId(Guid guid): base(guid)
    {
    }

    public static Result<CustomerId, DomainError> Create(Guid guid)
    {
        if (guid == Guid.Empty)
        {
            return DomainErrors.Customer.EmptyGuid;
        }

        return new CustomerId(guid);
    }

    protected override int GetValueHashCode()
    {
        return Id.GetHashCode();
    }

    protected override bool ValueEquals(AggregateId other)
    {
        return other is CustomerId 
            && Id == other.Id;
    }
}
