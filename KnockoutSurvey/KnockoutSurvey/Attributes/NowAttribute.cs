using System;
using System.ComponentModel.DataAnnotations;

namespace KnockoutSurvey.Attributes
{
    public class NowAttribute : ValidationAttribute
    {
        private readonly int _maxOffsetInMinutes;

        public NowAttribute(int maxOffsetInMinutes)
        {
            _maxOffsetInMinutes = maxOffsetInMinutes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var now = value is DateTime ? (DateTime) value : new DateTime();

            if (now < DateTime.Now.AddMinutes(_maxOffsetInMinutes * -1) 
                || now > DateTime.Now.AddMinutes(_maxOffsetInMinutes))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}