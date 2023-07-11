using Restaurant.DDD.Core.Products.ValueObjects;
using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.Core.Orders.Entities;

public sealed class Order : AggregateRoot<OrderId>
{
    private Order(OrderId orderId) : base(orderId)
    {


    }
}
