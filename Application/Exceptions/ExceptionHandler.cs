using Application.Dtos.Responses;

namespace Application.Exceptions
{
    public static class ExceptionHandler
    {
        public static ErrorResponse HandleException(Exception exception)
        {
            switch (exception)
            {
                case ArgumentNullException:
                    return new ErrorResponse(Convert.ToInt16(System.Net.HttpStatusCode.BadRequest), exception.Message);
                case HttpRequestException:
                    var requestException = exception as HttpRequestException;
                    return new ErrorResponse(Convert.ToInt16(requestException?.StatusCode), requestException?.Message ?? String.Empty);
                default:
                    return new ErrorResponse(Convert.ToInt16(System.Net.HttpStatusCode.InternalServerError), exception.Message);
            }
        }
    }
}
