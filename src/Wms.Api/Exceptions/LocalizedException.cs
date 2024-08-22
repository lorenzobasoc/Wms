using System.Net;

namespace Wms.Api.Exceptions;

public class LocalizedException(string errorCode, object errorParams, Exception? innerException = null) : Exception(null, innerException)
{
    public string ErrorCode { get; } = errorCode;
    public object ErrorParams { get; } = errorParams;
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
}
