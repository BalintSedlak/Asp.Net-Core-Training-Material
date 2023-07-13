using System.Net;

namespace Restaurant.Docker.Core.Exceptions;

public static class HttpStatusCodeExtension
{
    public static int ConvertToInt(this HttpStatusCode httpStatusCode)
    {
        return (int)httpStatusCode;
    }
}
