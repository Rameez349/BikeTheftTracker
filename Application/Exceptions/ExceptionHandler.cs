using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                default:
                    return new ErrorResponse(Convert.ToInt16(System.Net.HttpStatusCode.InternalServerError), exception.Message);
            }
        }
    }
}
