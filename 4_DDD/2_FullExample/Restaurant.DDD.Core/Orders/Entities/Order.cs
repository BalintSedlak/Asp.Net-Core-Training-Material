using OneOf;
using Restaurant.DDD.Core.Products.ValueObjects;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Monads;

namespace Restaurant.DDD.Core.Orders.Entities;

public sealed class Order : AggregateRoot<OrderId>
{
    public List<string> Products { get; }    

    private Order(OrderId orderId, List<string> products) : base(orderId)
    {
        Products = products;
    }

    public static async Task<OneOf<Order, DomainError>> Create()
    {
        var order = OrderId.Create(Guid.NewGuid()).Bind(orderId =>
                    Result<Order, DomainError>.Success(
                    new Order(orderId, new List<string> { "product1", "product2", "product3" })));

        return order.Match<OneOf<Order, DomainError>>(
            onSuccess => onSuccess,
            onError => onError
            );
    }
}
