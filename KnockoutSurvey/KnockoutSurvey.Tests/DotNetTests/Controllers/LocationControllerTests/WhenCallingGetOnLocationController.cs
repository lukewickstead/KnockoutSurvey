using KnockoutSurvey.Controllers;
using KnockoutSurvey.Infrastructure;
using KnockoutSurvey.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Language.Flow;
using Newtonsoft.Json;
using Xunit;

namespace KnockoutSurvey.Tests.DotNetTests.Controllers.LocationControllerTests
{
    public class WhenCallingGetOnLocationController
    {
        private readonly LocationController _locationController;
        private readonly Mock<IWebClientAdapter> _mockWebClientAdapter;

        public WhenCallingGetOnLocationController()
        {
            var repo = new MockRepository(MockBehavior.Default);
            _mockWebClientAdapter = repo.Create<IWebClientAdapter>();

            _locationController =
                new LocationController(
                    new GoogleApisServiceAdapter(_mockWebClientAdapter.Object));
        }

        [Fact]
        public void AndAddressesAreFoundThenTheFirstAddressIsReturned()
        {
            // Arrange
            StubWebClientAdapterWithResult().Returns(ResponseWithResults());

            // Act
            var response = _locationController.Get(1, 2) as JsonResult;

            // Assert
            Assert.NotNull(response);
            Assert.Contains("11 XXX Rd, Bristol BS3 XXX, UK", JsonConvert.SerializeObject(response.Value));
        }

        [Fact]
        public void AndNotAddressesAreFoundThenTheFirstAddressIsReturned()
        {
            // Arrange
            StubWebClientAdapterWithResult().Returns(ResponseWithoutResults());

            // Act
            var result = _locationController.Get(1, 2) as BadRequestObjectResult;

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            Assert.NotNull(result);
            Assert.Equal("Failed getting address", result.Value);
        }

        private ISetup<IWebClientAdapter, string> StubWebClientAdapterWithResult()
        {
            return _mockWebClientAdapter
                .Setup(
                    x => x.DownloadString(
                        "https://maps.googleapis.com/maps/api/geocode/json?latlng=1,2&key=AIzaSyApiY9lI5Q8szDsjvEm2MHrgEIz2EbIQP4"));
        }

        private static string ResponseWithResults()
        {
            return
                "{\"results\" : [ { \"formatted_address\" : \"11 XXX Rd, Bristol BS3 XXX, UK\" } ], \"status\" : \"OK\" }";
        }

        private static string ResponseWithoutResults()
        {
            return
                "{ \"error_message\" : \"Invalid request. Invalid 'latlng' parameter.\", \"results\" : [], \"status\" : \"INVALID_REQUEST\" }";
        }
    }
}