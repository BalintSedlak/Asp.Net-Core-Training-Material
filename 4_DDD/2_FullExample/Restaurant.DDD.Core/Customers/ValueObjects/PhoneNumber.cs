using Restaurant.DDD.SharedKernel.Monads;
using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Guards;

namespace Restaurant.DDD.Core.Customers.ValueObjects;
public sealed class PhoneNumber : ValueObject<PhoneNumber>
{
    private readonly string _phoneNumber;

    private PhoneNumber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
    }

    public static Result<PhoneNumber, DomainError> Create(string phoneNumber)
    {
        return Guard.Against.IsPhoneNumberMatchFormat(phoneNumber).Bind(isValid =>
                    Result<PhoneNumber, DomainError>.Success(
                    new PhoneNumber(phoneNumber))
        );
    }

    protected override int GetValueHashCode()
    {
        return _phoneNumber.GetHashCode();
    }

    protected override bool ValueEquals(PhoneNumber other)
    {
        return _phoneNumber == other._phoneNumber;
    }
}
