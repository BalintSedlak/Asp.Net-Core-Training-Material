using Microsoft.EntityFrameworkCore.Infrastructure;
using Restaurant.DDD.Core.CategoryDomain.Errors;
using Restaurant.DDD.SharedKernel;
using System;

namespace Restaurant.DDD.Core.CategoryDomain.ValueObjects;

public class Category : ValueObject<Category>
{
    public string Name { get; init; }
    public string Description { get; init; }

    private Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Result<Category, DomainError> Create(string name, string description)
    {
        if (string.IsNullOrEmpty(name))
        {
            return new Result<Category, DomainError>(DomainErrors.Category.InvalidCategoryName);
        }

        if (string.IsNullOrEmpty(name))
        {
            return new Result<Category, DomainError>(DomainErrors.Category.InvalidCategoryDescription);
        }

        return new Category(name, description);
    }

    protected override bool ValueEquals(Category other)
    {
        return Name.Equals(other.Name);
    }

    protected override int GetValueHashCode()
    {
        return HashCode.Combine(Name);
    }
}
