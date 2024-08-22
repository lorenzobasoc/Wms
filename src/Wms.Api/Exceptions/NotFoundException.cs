using System.Net;

namespace Wms.Api.Exceptions;

public class NotFoundException : LocalizedException
{
    public NotFoundException(string errorCode, object errorParams)
            : base(errorCode, errorParams) {
        StatusCode = HttpStatusCode.NotFound;
    }

    public NotFoundException(string errorCode, object errorParams, Exception innerException)
            : base(errorCode, errorParams, innerException) {
        StatusCode = HttpStatusCode.NotFound;
    }
}
