using Restaurant.DDD.Core.CategoryDomain.ValueObjects;
using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.Core.CategoryDomain.Entities;

public class CategoryAggregate : AggregateRoot
{
    public Category Category { get; set; }

    public Result<CategoryAggregate, DomainError> GetCategoryById(Guid id)
    {

    }
}
