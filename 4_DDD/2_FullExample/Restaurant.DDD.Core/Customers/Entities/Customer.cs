using Restaurant.DDD.Core.Orders.Entities;
using Restaurant.DDD.Core.Products.ValueObjects;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Monads;
using Restaurant.DDD.SharedKernel.ValueObjects;
using System.Reflection.Metadata.Ecma335;
using static Restaurant.DDD.Core.Errors.DomainErrors;

namespace Restaurant.DDD.Core.Customers.Entities;

public sealed class Customer : AggregateRoot<CustomerId>
{
    public CustomerId CustomerId { get; private set; }
    public string CompanyName { get; private set; }
    public string ContactName { get; private set; }
    public string Phone { get; private set; }
    public IReadOnlyCollection<OrderId> Orders => _orders.AsReadOnly();
    
    private readonly List<OrderId> _orders;

    private Customer(Address address, CustomerId customerId, ProductId productId) : base(customerId)
    {
        CustomerId = customerId;

        _orders = new List<OrderId>();

        
    }

    public static async Task<Result<Customer, DomainError>> Create()
    {
        //var result = Address.Create("Street", "City", "State", "Country", "ZipCode")
        //                    .Bind(address => CustomerId.Create(Guid.NewGuid())
        //                    .Bind(customerId => ProductId.Create(new Guid())
        //                    .Bind(productId => Result<Customer, DomainError>
        //                    .Success(new Customer(address, customerId, productId)))));

        var result = Address.Create("Street", "City", "State", "Country", "ZipCode")
                            .Bind(address => CustomerId.Create(Guid.NewGuid())
                            .Bind(customerId => ProductId.Create(Guid.NewGuid())
                            .Bind(productId => Result<Customer, DomainError>
                            .Success(new Customer(address, customerId, productId)))));

        return result;
    }

    public void AddOrder(OrderId orderId)
    {
        _orders.Add(orderId);
    }

    public void RemoveOrder(OrderId orderId)
    {
        _orders.Remove(orderId);
    }
}
