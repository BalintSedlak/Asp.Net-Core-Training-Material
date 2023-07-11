using Microsoft.EntityFrameworkCore.Infrastructure;
using Restaurant.DDD.Core.Errors;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Monads;
using System;

namespace Restaurant.DDD.Core.CategoryDomain.ValueObjects;

public class CategoryInfo : ValueObject<CategoryInfo>
{
    public string Name { get; init; }
    public string Description { get; init; }

    private CategoryInfo(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Result<CategoryInfo, DomainError> Create(string name, string description)
    {
        if (string.IsNullOrEmpty(name))
        {
            return new Result<CategoryInfo, DomainError>(DomainErrors.Category.InvalidCategoryName);
        }

        if (string.IsNullOrEmpty(name))
        {
            return new Result<CategoryInfo, DomainError>(DomainErrors.Category.InvalidCategoryDescription);
        }

        return new CategoryInfo(name, description);
    }

    protected override bool ValueEquals(CategoryInfo other)
    {
        return Name.Equals(other.Name);
    }

    protected override int GetValueHashCode()
    {
        return HashCode.Combine(Name);
    }
}
