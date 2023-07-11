using Restaurant.DDD.Core.Errors;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Monads;

namespace Restaurant.DDD.Core.Products.ValueObjects;

public sealed class ProductId : AggregateId
{
    public ProductId(Guid guid): base(guid)
    {
    }

    public static Result<ProductId, DomainError> Create(Guid guid)
    {
        if (guid == Guid.Empty)
        {
            return DomainErrors.Product.EmptyGuid;
        }

        return new ProductId(guid);
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
