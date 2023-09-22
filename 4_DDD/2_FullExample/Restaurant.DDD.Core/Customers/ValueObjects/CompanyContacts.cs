using Restaurant.DDD.Core.Products.ValueObjects;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Monads;

namespace Restaurant.DDD.Core.Customers.ValueObjects;
public sealed class CompanyContacts : ValueObject<CompanyContacts>
{
    private readonly string _companyName;
    private readonly EmailAddress _emailAddress;
    private readonly PhoneNumber _phoneNumber;

    private CompanyContacts(string CompanyName, EmailAddress emailAddress, PhoneNumber phoneNumber) 
    {
        _companyName = CompanyName;
        _emailAddress = emailAddress;
        _phoneNumber = phoneNumber;
    }

    public static Result<CompanyContacts, DomainError> Create(string companyName, EmailAddress emailAddress, PhoneNumber phoneNumber)
    {
        if (companyName is null)
        {
            throw new ArgumentNullException(nameof(companyName));
        }

        if (emailAddress is null)
        {
            throw new ArgumentNullException(nameof(emailAddress));
        }

        if (phoneNumber is null)
        {
            throw new ArgumentNullException(nameof(phoneNumber));
        }

        return new CompanyContacts(companyName, emailAddress, phoneNumber);
    }

    protected override int GetValueHashCode()
    {
        return HashCode.Combine(_companyName, _emailAddress, _phoneNumber);
    }

    protected override bool ValueEquals(CompanyContacts other)
    {
        return other is CustomerId && 
               _companyName == other._companyName &&
               _emailAddress == other._emailAddress &&
               _phoneNumber == other._phoneNumber;
    }
}
