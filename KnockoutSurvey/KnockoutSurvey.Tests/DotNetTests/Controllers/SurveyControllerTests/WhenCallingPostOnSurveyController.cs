using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using KnockoutSurvey.Controllers;
using KnockoutSurvey.Infrastructure;
using KnockoutSurvey.Models;
using KnockoutSurvey.Tests.DotNetTests.Helpers;
using Moq;
using Xunit;

namespace KnockoutSurvey.Tests.DotNetTests.Controllers.SurveyControllerTests
{
    public class WhenCallingPostOnSurveyController : ControllerTestBase
    {
        private const string PostEndPoint = "/Survey/Submit";
        
        [Fact]
        public async Task AndTheSurveyIsValidThenTheResponseHasAStatusCodeOfOk()
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task AndTheSurveyIsValidWithMinimumBoundaryConditionsThenTheResponseHasAStatusCodeOfOk()
        {
            // Arrange
            var survey = new SurveyBuilder()
                .WithMinimumBoundaryValidValues()
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task AndTheSurveyIsValidWithMaximumBoundaryConditionsThenTheResponseHasAStatusCodeOfOk()
        {
            // Arrange
            var survey = new SurveyBuilder()
                .WithMaximumBoundaryValidValues()
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public void AndTheSurveyIsValidThenConsoleIsCalledWithTheDetails()
        {
            // Arrange
            var repo = new MockRepository(MockBehavior.Default);
            var mockConsoleAdapter = repo.Create<IConsoleAdapter>();
            var surveyController = new SurveyController(mockConsoleAdapter.Object);
            
            var survey = SurveBuilderWithValidDefaults()
                .Build();

            // Act
            surveyController.Submit(survey);

            // Assert
            mockConsoleAdapter.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(7));
            mockConsoleAdapter.Verify(x => x.WriteLine("Survey Received:"), Times.Once);
            mockConsoleAdapter.Verify(x => x.WriteLine("  Title: " + survey.Title.ToString()), Times.Once);
            mockConsoleAdapter.Verify(x => x.WriteLine("  Name: " + survey.Name), Times.Once);
            mockConsoleAdapter.Verify(x => x.WriteLine("  Date Of Birth: " + survey.DateOfBirth), Times.Once);
            mockConsoleAdapter.Verify(x => x.WriteLine("  Location: " + survey.Location), Times.Once);
            mockConsoleAdapter.Verify(x => x.WriteLine("  Now: " + survey.Now), Times.Once);
            mockConsoleAdapter.Verify(x => x.WriteLine("  Feedback: " + survey.Feedback), Times.Once);
        }
        
        [Fact]
        public async Task AndTheTitleFieldIsNotProvidedThenTheCorrectValidationMessageIsReturned()
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithTitle(Title.Unknown)
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("Title is required");
        }

        [Theory]
        [InlineData(Title.Miss)]
        [InlineData(Title.Mr)]
        [InlineData(Title.Mrs)]
        [InlineData(Title.Other)]
        public async Task AndTheTitleFieldIsProvidedThenTheResponseHasAStatusCodeOfOk(Title title)
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithTitle(title)
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task AndTheNameFieldIsNotProvidedThenTheCorrectValidationMessageIsReturned()
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithName(string.Empty)
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("The Name field is required");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(51)]
        public async Task AndTheNameFieldIsNotTheCorrectLengthThenTheCorrectValidationMessageIsReturned(int nameLength)
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithName("".StringOfLength(nameLength))
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should()
                .Contain("The field Name must be a string with a minimum length of 3 and a maximum length of 50.");
        }

        [Fact]
        public async Task AndTheDateOfBirthFieldIsMoreThan125YearsAgo()
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithDateOfBirth(DateTime.Now.AddYears(-125).AddDays(-1))
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("You cannot be more than 125 years old");
        }

        [Fact]
        public async Task AndTheDateOfBirthFieldIsGreaterThanToday()
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithDateOfBirth(DateTime.Now.AddDays(1))
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("You cannot be more than 125 years old");
        }

        [Fact]
        public async Task AndTheLocationFieldIsNotProvidedThenTheCorrectValidationMessageIsReturned()
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithLocation(string.Empty)
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("The Location field is required");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(51)]
        public async Task AndTheLocationFieldIsNotTheCorrectLengthThenTheCorrectValidationMessageIsReturned(
            int nameLength)
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithLocation("".StringOfLength(nameLength))
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should()
                .Contain("The field Location must be a string with a minimum length of 3 and a maximum length of 50.");
        }

        [Theory]
        [InlineData(-16)]
        [InlineData(16)]
        public async Task AndTheNowFieldIsOutOfTheValidRange(int nowOffSet)
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithNow(DateTime.Now.AddMinutes(nowOffSet))
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("Now cannot be out by more than 15 minutes");
        }

        [Fact]
        public async Task AndTheFeedbackFieldIsNotProvidedThenTheCorrectValidationMessageIsReturned()
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithFeedback(string.Empty)
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should().Contain("The Feedback field is required");
        }

        [Theory]
        [InlineData(24)]
        [InlineData(501)]
        public async Task AndTheFeedbackFieldIsNotTheCorrectLengthThenTheCorrectValidationMessageIsReturned(
            int nameLength)
        {
            // Arrange
            var survey = SurveBuilderWithValidDefaults()
                .WithFeedback("".StringOfLength(nameLength))
                .Build();

            // Act
            var response = await PostSurvey(survey);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.Should()
                .Contain(
                    "The field Feedback must be a string with a minimum length of 25 and a maximum length of 500.");
        }

        private static SurveyBuilder SurveBuilderWithValidDefaults()
        {
            return new SurveyBuilder()
                .WithDevaultValidValues();
        }

        private async Task<HttpResponseMessage> PostSurvey(SurveyViewModel survey)
        {
            return await PostAsJson(PostEndPoint, survey);
        }
    }
}