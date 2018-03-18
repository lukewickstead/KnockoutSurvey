using System;
using System.ComponentModel.DataAnnotations;

namespace KnockoutSurvey.Attributes
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        private readonly DateTime _minDateTime;

        public DateOfBirthAttribute(int maxAge)
        {
            _minDateTime = DateTime.Today.AddYears(maxAge*-1);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateOfBirth = value is DateTime ? (DateTime) value : new DateTime();

            if (dateOfBirth < _minDateTime || dateOfBirth > DateTime.Today)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}