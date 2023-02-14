using System.Text.Json;
using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Application.Services;
using FluentAssertions;
using Infrastructure.Core.HttpClients;
using Infrastructure.Tests.DataMocks;
using Moq;

namespace Application.Tests
{
    public class BikeServiceTests
    {
        private readonly Mock<IBikeIndexApiClient> _bikeIndexApiClientMock;
        private readonly BikesService _sut;

        public BikeServiceTests()
        {
            _bikeIndexApiClientMock = new Mock<IBikeIndexApiClient>();
            _sut = new BikesService(_bikeIndexApiClientMock.Object);
        }

        [Fact]
        public async Task Test_SearchBikes_WithOnlyPagination_Returns_BikesCollection()
        {
            // Arrange
            var expectedResult = new Bikes
            {
                BikesCollection = BikeMocks.GetBikeDetailsMock()
            };
            _bikeIndexApiClientMock.Setup(x => x.SearchBikes(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(JsonSerializer.Serialize(expectedResult));

            var searchRequest = new SearchRequest()
            {
                Page = 1,
                PerPage = 10,
            };

            // Action
            var result = await _sut.SearchBikes(searchRequest);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async Task Test_SearchBikes_WithPaginationAndFilters_Returns_BikesCollection()
        {
            // Arrange
            var expectedResult = new Bikes
            {
                BikesCollection = BikeMocks.GetBikeDetailsMock().Where(x => x.ManufacturerName == "Panther")
            };
            _bikeIndexApiClientMock.Setup(x => x.SearchBikes(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(JsonSerializer.Serialize(expectedResult));

            var searchRequest = new SearchRequest()
            {
                Page = 1,
                PerPage = 10,
                Manufacturer = "Panther"
            };

            // Action
            var result = await _sut.SearchBikes(searchRequest);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
