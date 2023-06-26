using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.Core.CategoryDomain.Errors;

public static class DomainErrors
{
    public static class Category
    {
        public static readonly DomainError InvalidCategoryName = new DomainError("Category.Create.NameIsNull", 422, "The Category name cannot be empty.", "Category.Create: name parameter is null or empty");
        public static readonly DomainError InvalidCategoryDescription = new DomainError("Category.Create.DescriptionIsNull", 422, "The Category description cannot be empty.", "Category.Create: description parameter is null or empty");
    }
}
