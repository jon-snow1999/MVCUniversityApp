using System.ComponentModel.DataAnnotations;
using MVCUniversityApp.Context;
namespace MVCUniversityApp.Models
{
    public class UniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Course? course = validationContext.ObjectInstance as Course;
            string courseName = value.ToString();
            UniContext db = new UniContext();
            Course? courseFromDB = db.Courses.FirstOrDefault((c) => c.Name == courseName);
            if(courseFromDB is null)
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult("Name already exits");
        }
    }
}
