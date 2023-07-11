using Restaurant.DDD.Core.Products.ValueObjects;
using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.Core.Products.Entities;
public sealed class Product : AggregateRoot<ProductId>
{
    public Product(ProductId productId) : base(productId)
    {
        Id = productId;
    }

    public ProductId Id { get; set; }
}
