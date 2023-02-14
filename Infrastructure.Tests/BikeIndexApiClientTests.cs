using RichardSzalay.MockHttp;
using Infrastructure.Core.Services;
using Application.Constants;
using Infrastructure.Core.Options;
using Microsoft.Extensions.Options;
using Application.Dtos.Responses;
using System.Text.Json;
using FluentAssertions;
using System.Net.Mime;
using Infrastructure.Tests.DataMocks;

namespace Infrastructure.Tests
{
    public class BikeIndexApiClientTests
    {
        private MockHttpMessageHandler MockHttp { get; set; }

        public BikeIndexApiClientTests()
        {
            MockHttp = new MockHttpMessageHandler();
        }

        [Fact]
        public async Task Test_SearchBikes_WithOnlyPagination_Returns_BikesCollection()
        {
            // Arrange
            var expectedResult = new Bikes
            {
                BikesCollection = BikeMocks.GetBikeDetailsMock()
            };
            var options = new BikeIndexApiOptions
            {
                BaseAddress = "https://localhost/api/"
            };
            var bikeIndexApiOptions = Options.Create(options);

            MockHttp.When("https://localhost/api/search")
                    .WithQueryString("page=1&per_page=25")
                    .Respond(MediaTypeNames.Application.Json, JsonSerializer.Serialize(expectedResult));

            var client = MockHttp.ToHttpClient();
            var bikeIndexApiClient = new BikeIndexApiClient(client, bikeIndexApiOptions);

            // Action
            var response = await bikeIndexApiClient.SearchBikes(BikeIndexApiPaths.SearchBikes, "page=1&per_page=25");

            // Assert
            var result = JsonSerializer.Deserialize<Bikes>(response);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task Test_SearchBikes_WithFiltersAndPagination_Returns_BikesCollection()
        {
            // Arrange
            var expectedResult = new Bikes
            {
                BikesCollection = BikeMocks.GetBikeDetailsMock().Where(x => x.ManufacturerName == "Panther")
            };
            var options = new BikeIndexApiOptions
            {
                BaseAddress = "https://localhost/api/"
            };
            var bikeIndexApiOptions = Options.Create(options);

            MockHttp.When($"https://localhost/api/{BikeIndexApiPaths.SearchBikes}")
                    .WithQueryString("page=1&per_page=25&manufacturer=Panther")
                    .Respond(MediaTypeNames.Application.Json, JsonSerializer.Serialize(expectedResult));

            var client = MockHttp.ToHttpClient();
            var bikeIndexApiClient = new BikeIndexApiClient(client, bikeIndexApiOptions);

            // Action
            var response = await bikeIndexApiClient.SearchBikes(BikeIndexApiPaths.SearchBikes, "page=1&per_page=25&manufacturer=Panther");

            // Assert
            var result = JsonSerializer.Deserialize<Bikes>(response);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task Test_SearchBikes_With_InvalidBikeIndexApi_Url_Throws_Exception()
        {
            // Arrange
            var expectedResult = new Bikes
            {
                BikesCollection = BikeMocks.GetBikeDetailsMock().Where(x => x.ManufacturerName == "Panther")
            };
            var options = new BikeIndexApiOptions
            {
                BaseAddress = "https://localhost/api/"
            };
            var bikeIndexApiOptions = Options.Create(options);

            MockHttp.When($"https://localhost/api/")
                    .WithQueryString("page=1&per_page=25&manufacturer=Panther")
                    .Respond(MediaTypeNames.Application.Json, JsonSerializer.Serialize(expectedResult));

            var client = MockHttp.ToHttpClient();
            var bikeIndexApiClient = new BikeIndexApiClient(client, bikeIndexApiOptions);

            // Action
            Func<Task> result = async () => await bikeIndexApiClient.SearchBikes(BikeIndexApiPaths.SearchBikes, "page=1&per_page=25&manufacturer=Panther");

            // Assert
            await result.Should().ThrowAsync<HttpRequestException>();
        }
    }
}
