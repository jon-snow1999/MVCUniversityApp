using System.ComponentModel.DataAnnotations;

namespace MVCUniversityApp.Models.Attributes
{
    public class LessthanAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int minDegree = (int)value;
            Course? course = validationContext.ObjectInstance as Course;
            if(minDegree < course.MaxDegree)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Minimum degree can't be more than maximum degree");
        }
    }
}
