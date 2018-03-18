using System;
using KnockoutSurvey.Models;

namespace KnockoutSurvey.Tests.DotNetTests.Helpers
{
    internal class SurveyBuilder
    {
        private Title title;
        private string name;
        private DateTime dateOfBirth;
        private string location;
        private DateTime now;
        private string feedback;

        internal SurveyBuilder WithDevaultValidValues()
        {
            this.title = Title.Mr;
            this.name = "Luke";
            this.dateOfBirth = DateTime.Today.AddYears(-20);
            this.location = "Right here";
            this.now = DateTime.Now;
            this.feedback = "".StringOfLength(25);

            return this;
        }
        
        internal SurveyBuilder WithMinimumBoundaryValidValues()
        {
            this.title = Title.Mr;
            this.name = "".StringOfLength(3);
            this.dateOfBirth = DateTime.Today.AddYears(-125);
            this.location = "".StringOfLength(3);
            this.now = DateTime.Now.AddMinutes(-15).AddSeconds(2); // We should really be using mocking to prevent this type of hack
            this.feedback = "".StringOfLength(25);

            return this;
        }
        
        internal SurveyBuilder WithMaximumBoundaryValidValues()
        {
            this.title = Title.Mr;
            this.name = "".StringOfLength(50);
            this.dateOfBirth = DateTime.Today;
            this.location = "".StringOfLength(50);
            this.now = DateTime.Now.AddMinutes(15).AddSeconds(-2);
            this.feedback = "".StringOfLength(500);

            return this;
        }

        internal SurveyBuilder WithTitle(Title title)
        {
            this.title = title;
            return this;
        }

        internal SurveyBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        internal SurveyBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
            return this;
        }
        
        internal SurveyBuilder WithLocation(string location)
        {
            this.location = location;
            return this;
        }

        internal SurveyBuilder WithNow(DateTime now)
        {
            this.now = now;
            return this;
        }

        internal SurveyBuilder WithFeedback(string feedback)
        {
            this.feedback = feedback;
            return this;
        }

        internal SurveyViewModel Build()
        {
            return new SurveyViewModel()
            {
                Title = this.title,
                Name = this.name,
                DateOfBirth = this.dateOfBirth,
                Location = this.location,
                Now = this.now,
                Feedback = this.feedback,
            };
        }
    }
}