using System.Net;

namespace Kappas.Paypoint.Shared.Exceptions;

public class LocalizedException : Exception
{
    public LocalizedException(string errorCode, object errorParams, Exception innerException = null)
        : base(null, innerException)
    {
        ErrorCode = errorCode;
        ErrorParams = errorParams;
        StatusCode = HttpStatusCode.InternalServerError;
    }

    public string ErrorCode { get; }
    public object ErrorParams { get; }
    public HttpStatusCode StatusCode { get; set; }
}
