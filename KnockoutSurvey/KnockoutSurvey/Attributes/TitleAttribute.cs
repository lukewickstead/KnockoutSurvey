using System.ComponentModel.DataAnnotations;
using KnockoutSurvey.Models;

namespace KnockoutSurvey.Attributes
{
    public class TitleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var title = value is Title ? (Title) value : Title.Unknown;
            return title  == Title.Unknown ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
        }
    }
}