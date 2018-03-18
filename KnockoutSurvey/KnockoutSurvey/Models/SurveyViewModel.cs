using System;
using System.ComponentModel.DataAnnotations;
using KnockoutSurvey.Attributes;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace KnockoutSurvey.Models
{
    public enum Title
    {
        Unknown,
        Miss,
        Mr,
        Mrs,
        Other
    }
    
    public class SurveyViewModel
    {
        [TitleAttribute(ErrorMessage = "Title is required")]
        public Title Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DateOfBirth(maxAge: 125, ErrorMessage = "You cannot be more than 125 years old")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Location { get; set; }

        [Required]
        [NowAttribute(maxOffsetInMinutes:15, ErrorMessage = "Now cannot be out by more than 15 minutes")]
        public DateTime Now { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 25)]
        public string Feedback { get; set; }
    }
}