using Restaurant.DDD.SharedKernel;

namespace Restaurant.DDD.Core.Errors;

public static class DomainErrors
{
    public static class Category
    {
        public static readonly DomainError InvalidCategoryName = new DomainError("Category.Create.NameIsNull", 422, "The Category name cannot be empty.", "Category.Create: name parameter is null or empty");
        public static readonly DomainError InvalidCategoryDescription = new DomainError("Category.Create.DescriptionIsNull", 422, "The Category description cannot be empty.", "Category.Create: description parameter is null or empty");
    }

    public static class Customer
    {
        public static readonly DomainError EmptyGuid = new DomainError("Customer.Create.GuidIsEmpty", 404, "We apologize for the inconvenience, but it seems that our server is currently experiencing some technical difficulties. Please try again later. If the issue persists, kindly contact our support team for further assistance. Thank you for your understanding.", "CustomerId.Create: guid parameter is empty");
        public static readonly DomainError CompanyNameIsEmpty = new DomainError("Customer.Create.CompanyNameIsEmpty", 422, "Invalid phone number format", "Customer.EmailAddress.Create.InvalidEmailAddress: Invalid email format");
        public static readonly DomainError InvalidEmailAddress = new DomainError("Customer.Create.InvalidEmailAddress", 422, "Invalid email format", "Customer.EmailAddress.Create.InvalidEmailAddress: Invalid email format");
        public static readonly DomainError EmailAddressIsEmpty = new DomainError("Customer.Create.EmailAddressIsEmpty", 422, "Invalid email format", "Customer.EmailAddress.Create.InvalidEmailAddress: Invalid email format");
        public static readonly DomainError InvalidPhoneNumber = new DomainError("Customer.Create.InvalidPhoneNumber", 422, "Invalid phone number format", "PhoneNumber.Create.InvalidPhoneNumber: Invalid phone number format");
        public static readonly DomainError PhoneNumberIsEmpty = new DomainError("Customer.Create.PhoneNumberIsEmpty", 422, "Invalid phone number format", "PhoneNumber.Create.InvalidPhoneNumber: Invalid phone number format");
    }

    public static class Order
    {
        public static readonly DomainError EmptyGuid = new DomainError("Order.Create.GuidIsEmpty", 404, "We apologize for the inconvenience, but it seems that our server is currently experiencing some technical difficulties. Please try again later. If the issue persists, kindly contact our support team for further assistance. Thank you for your understanding.", "OrderId.Create: guid parameter is empty");
    }

    public static class Product
    {
        public static readonly DomainError EmptyGuid = new DomainError("Product.Create.GuidIsEmpty", 404, "We apologize for the inconvenience, but it seems that our server is currently experiencing some technical difficulties. Please try again later. If the issue persists, kindly contact our support team for further assistance. Thank you for your understanding.", "ProductId.Create: guid parameter is empty");
    }

    
}