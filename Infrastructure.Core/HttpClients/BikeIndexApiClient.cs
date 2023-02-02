using System.Text.Json;
using Infrastructure.Core.HttpClients;
using Infrastructure.Core.Options;
using Microsoft.Extensions.Options;

namespace Infrastructure.Core.Services
{
    public class BikeIndexApiClient : IBikeIndexApiClient
    {
        private readonly HttpClient _httpClient;

        public BikeIndexApiClient(HttpClient httpClient, IOptions<BikeIndexApiOptions> options)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(options.Value.BaseAddress);
            _httpClient.DefaultRequestHeaders.Clear();
        }

        public async Task<string> SearchBikes(string requestPath, string queryParams)
        {
            var response = await _httpClient.GetAsync($"{requestPath}?{queryParams}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
