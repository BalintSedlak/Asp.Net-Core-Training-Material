using System.Net;

namespace Restaurant.Docker.Core.Exceptions;

public class ServiceException : Exception
{
    public HttpStatusCode HttpStatusCode { get; private set; }
    public string LogMessage { get; }
    public string UserFriendlyMessage { get; }

    public ServiceException(HttpStatusCode httpStatusCode, string logMessage, string userFriendlyMessage) : base(logMessage)
    {
        HttpStatusCode = httpStatusCode;
        LogMessage = logMessage;
        UserFriendlyMessage = userFriendlyMessage;
    }

    public ServiceException(HttpStatusCode httpStatusCode, string logMessage, string userFriendlyMessage, Exception inner) : base(logMessage, inner)
    {
        HttpStatusCode = httpStatusCode;
        LogMessage = logMessage;
        UserFriendlyMessage = userFriendlyMessage;
    }
}
