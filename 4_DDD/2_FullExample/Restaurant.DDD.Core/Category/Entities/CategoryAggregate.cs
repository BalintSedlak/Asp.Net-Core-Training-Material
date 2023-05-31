using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.Core.ProductReviews.Entities;

public class CategoryAggregate : AggregateRoot
{
    public Result<CategoryAggregate, DomainError> GetCategoryById(Guid id)
    {

    }
}
