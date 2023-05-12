using System.Net;

namespace Seba.Finapp.Core.Exceptions;

public static class HttpStatusCodeExtension
{
    public static int ConvertToInt(this HttpStatusCode httpStatusCode)
    {
        return (int)httpStatusCode;
    }
}
