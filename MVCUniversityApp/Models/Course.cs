using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MVCUniversityApp.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCUniversityApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Unique]
        [Required]
        [MinLength(5, ErrorMessage = "course name must be at least 5 characters long")]
        public string Name { get; set; }
        [Range(50,100,ErrorMessage = "Maximum Value is not between 50 and 100")]
        public int MaxDegree { get; set; }
        [Remote(action:"CheckMin", controller:"Course", AdditionalFields = "MaxDegree")]
        [Lessthan]
        public int MinDegree { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }
        
    }
}
