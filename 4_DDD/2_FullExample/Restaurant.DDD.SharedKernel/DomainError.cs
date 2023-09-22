namespace Restaurant.DDD.SharedKernel;
public class DomainError : IEquatable<DomainError>
{
    public string ErrorCode { get; }
    public int StatusCode { get; }
    public string UserFriendlyMessage { get; }
    public string LogMessage { get; }

    public DomainError(string errorCode, int statusCode, string userFriendlyMessage, string logMessage)
    {
        ErrorCode = errorCode;
        StatusCode = statusCode;
        UserFriendlyMessage = userFriendlyMessage;
        LogMessage = logMessage;
    }

    public static implicit operator string(DomainError domainError) => domainError.ErrorCode;

    //TODO?
    public bool Equals(DomainError? other)
    {
        throw new NotImplementedException();
    }

}
