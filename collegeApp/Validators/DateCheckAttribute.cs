using System.ComponentModel.DataAnnotations;

namespace collegeApp.Validators
{
    public class DateCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date=(DateTime?)value;
            if (date < DateTime.Now)
            {
                return new ValidationResult("Please enter a valid date");
            }

            return ValidationResult.Success;
        }
    }
}
