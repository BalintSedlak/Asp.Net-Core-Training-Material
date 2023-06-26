using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.Core.ProductReviews.Entities;

public class CategoryAggregate : AggregateRoot
{
    public Category Name { get; set; }

    public Result<CategoryAggregate, DomainError> GetCategoryById(Guid id)
    {

    }
}
