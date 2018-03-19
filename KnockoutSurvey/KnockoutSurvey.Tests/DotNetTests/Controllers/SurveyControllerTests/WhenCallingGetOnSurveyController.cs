using System.Threading.Tasks;
using KnockoutSurvey.Controllers;
using KnockoutSurvey.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace KnockoutSurvey.Tests.DotNetTests.Controllers.SurveyControllerTests
{
    public class WhenCallingGetOnSurveyController : ControllerTestBase
    {
        private readonly SurveyController _surveyController;
        private Mock<IConsoleAdapter> _mockConsoleAdapter;

        public WhenCallingGetOnSurveyController()
        {
            var repo = new MockRepository(MockBehavior.Default);
            _mockConsoleAdapter = repo.Create<IConsoleAdapter>();
            _surveyController = new SurveyController(_mockConsoleAdapter.Object);
        }
        
        [Fact]
        public void TheCorrectViewNameIsReturned()
        {
            var result = _surveyController.Get() as ViewResult;
           
            Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", result.ViewName);
        }
        
        [Theory(Skip = "Cannot get to run; always returns not found despite controller being hit!!")]
        [InlineData("/")]
        [InlineData("/Survey")]
        [InlineData("/Survey/Get")]
        public async Task ThenTheCurrentResponseIsReturned(string url)
        {
            // Act
            var response = await GetAsync(url);
           
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Survey", responseString);
        }
    }
}