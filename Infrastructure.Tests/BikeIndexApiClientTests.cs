using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichardSzalay.MockHttp;
using Infrastructure.Core.Services;
using Application.Constants;
using Infrastructure.Core.Options;
using Microsoft.Extensions.Options;
using Application.Dtos.Responses;
using System.Text.Json;
using FluentAssertions;
using System.Net.Mime;

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
                BikesCollection = GetBikeDetailsMock()
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
                BikesCollection = GetBikeDetailsMock().Where(x => x.ManufacturerName == "Panther")
            };
            var options = new BikeIndexApiOptions
            {
                BaseAddress = "https://localhost/api/"
            };
            var bikeIndexApiOptions = Options.Create(options);

            MockHttp.When("https://localhost/api/search")
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

        private IEnumerable<BikeDetails> GetBikeDetailsMock()
       => new List<BikeDetails>()
       {
            new BikeDetails
            {
                Id = 1,
                DateStolen=null,
                Description="stolen bike is in excellent condition",
                FrameColors = new string[] { "grey","blue"},
                FrameModel="2006",
                IsStockImage=false,
                ManufacturerName="Panther"
            },
            new BikeDetails
            {
                 Id = 2,
                DateStolen=null,
                Description="stolen bike is in average condition",
                FrameColors = new string[] { "pink","red"},
                FrameModel="2016",
                IsStockImage=false,
                ManufacturerName="KONA Bikes"
            }
       };
    }
}
