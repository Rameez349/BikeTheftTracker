using System.Text.Json;
using Application.Constants;
using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Extensions;
using Application.Interfaces;

namespace Application.Services
{
    public class BikesService : IBikesService
    {
        private readonly IBikeIndexApiClient _bikeIndexApiClient;

        public BikesService(IBikeIndexApiClient bikeIndexApiClient)
        {
            _bikeIndexApiClient = bikeIndexApiClient;
        }

        public async Task<Bikes> SearchBikes(SearchRequest searchRequest)
        {
            string queryString = searchRequest.MapObjectToQueryString();

            var result = await _bikeIndexApiClient.SearchBikes(BikeIndexApiPaths.SearchBikes, queryString);

            return JsonSerializer.Deserialize<Bikes>(result);
        }
    }
}
