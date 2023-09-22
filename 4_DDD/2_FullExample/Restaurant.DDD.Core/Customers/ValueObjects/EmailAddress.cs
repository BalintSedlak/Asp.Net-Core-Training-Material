using Restaurant.DDD.SharedKernel;
using Restaurant.DDD.SharedKernel.Guards;
using Restaurant.DDD.SharedKernel.Monads;

namespace Restaurant.DDD.Core.Customers.ValueObjects;

public sealed class EmailAddress : ValueObject<EmailAddress>
{
    private readonly string _email;

    private EmailAddress(string email)
    {
        _email = email;
    }

    public static Result<EmailAddress, DomainError> Create(string emailAddress)
    {
        return Guard.Against.IsEmailMatchFormat(emailAddress).Bind(isValid =>
                    Result<EmailAddress, DomainError>.Success(
                    new EmailAddress(emailAddress))
        );
    }

    protected override int GetValueHashCode()
    {
        return _email.GetHashCode();
    }

    protected override bool ValueEquals(EmailAddress other)
    {
        return _email == other._email;
    }
}