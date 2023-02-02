using System;
namespace Application.Dtos.Responses
{
    public record ErrorResponse(int StatusCode, string Message);
}
