using Application.Dtos.Requests;
using Application.Dtos.Responses;

namespace Application.Interfaces
{
    public interface IBikesService
    {
        Task<Bikes> SearchBikes(SearchRequest searchRequest);
    }
}
