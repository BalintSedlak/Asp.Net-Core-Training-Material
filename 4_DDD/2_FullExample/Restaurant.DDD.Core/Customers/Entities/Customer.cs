using Restaurant.DDD.Core.Customers.ValueObjects;
using Restaurant.DDD.Core.Products.ValueObjects;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Monads;
using Restaurant.DDD.SharedKernel.ValueObjects;

namespace Restaurant.DDD.Core.Customers.Entities;

public sealed class Customer : AggregateRoot<CustomerId>
{
    public CustomerId CustomerId { get; private set; }
    public CompanyContacts CompanyContacts { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<OrderId> Orders => _orders.AsReadOnly();
    
    private readonly List<OrderId> _orders;

    private Customer(CustomerId customerId, CompanyContacts companyContacts, Address address) : base(customerId)
    {
        CustomerId = customerId;
        CompanyContacts = companyContacts;
        Address = address;

        _orders = new List<OrderId>();        
    }

    public static async Task<Result<Customer, DomainError>> Create()
    {
        //return Address.Create("Street", "City", "State", "Country", "ZipCode")
        //                    .Bind(address => CustomerId.Create(Guid.NewGuid())
        //                    .Bind(customerId => ProductId.Create(new Guid())
        //                    .Bind(productId => Result<Customer, DomainError>
        //                    .Success(new Customer(address, customerId, productId)))));

        return Address.Create("Street", "City", "State", "Country", "ZipCode").Bind(address => 
               CustomerId.Create(Guid.NewGuid()).Bind(customerId =>
               EmailAddress.Create("email@address.com").Bind(emailAddress =>
               PhoneNumber.Create("+36204567890").Bind(phoneNumber =>
               CompanyContacts.Create("CompanyName", emailAddress, phoneNumber).Bind(companyContacts => 
               Result<Customer, DomainError>.Success(
                   new Customer(customerId, companyContacts, address)))))));
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
