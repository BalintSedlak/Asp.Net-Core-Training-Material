using Restaurant.DDD.SharedKernel.Monads;

namespace Restaurant.DDD.SharedKernel.Guards;

public static partial class GuardClauseExtensions
{
    public static Result<string, DomainError> NullOrEmpty(this IGuardClause guardClause, string input, DomainError domainError)
    {
        if (string.IsNullOrEmpty(input))
        {
            return domainError;
        }

        return input;
    }

    public static Result<string, DomainError> LengthGreaterThan(this IGuardClause guardClause, string input, int maxLength, DomainError domainError)
    {
        if (input.Length > maxLength)
        {
            return domainError;
        }

        return input;
    }
}
