using Restaurant.DDD.Core.Errors;
using Restaurant.DDD.SharedKernel.Monads;
using System.Text.RegularExpressions;

namespace Restaurant.DDD.SharedKernel.Guards;

public static class GuardCustomerExtensions
{
    public static Result<string, DomainError> IsPhoneNumberMatchFormat(this IGuardClause guardClause, string phoneNumber)
    {
        // Regular expression for validating Hungarian phone numbers.
        // Assumes that the country code is +36 and the area code can be 1 or 2 digits.
        // The local number can be 6 or 7 digits.
        string pattern = @"^\+36[1-9]\d{0,1}\d{6,7}$";

        if (!Regex.IsMatch(phoneNumber, pattern))
        {
            return DomainErrors.Customer.InvalidPhoneNumber;
        }

        return phoneNumber;
    }

    public static Result<string, DomainError> IsEmailMatchFormat(this IGuardClause guardClause, string emailAddress)
    {
        // Regular expression for validating email.
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        if (!Regex.IsMatch(emailAddress, pattern))
        {
            return DomainErrors.Customer.InvalidEmailAddress;
        }

        return emailAddress;
    }
}
