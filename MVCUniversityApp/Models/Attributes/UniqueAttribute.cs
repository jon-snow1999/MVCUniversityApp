using System.ComponentModel.DataAnnotations;
using MVCUniversityApp.Context;
namespace MVCUniversityApp.Models.Attributes
{
    public class UniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Course? course = validationContext.ObjectInstance as Course;
            string courseName = value.ToString();
            UniContext db = validationContext.GetRequiredService<UniContext>();
            Course? courseFromDB = db.Courses.FirstOrDefault((c) => c.Name == courseName && c.DepartmentId == course.DepartmentId);
            if (courseFromDB is null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Name already exits");
        }
    }
}
