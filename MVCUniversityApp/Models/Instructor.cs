using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCUniversityApp.Models
{
    public class Instructor: BaseClass
    {
        public string ImageUrl { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public List<Course> Courses { get; set; } 

    }
}
