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

        public override string ToString()
        {
            return $"I am called {this.Name}, with an id of {this.Id}, I earn ${this.Salary} per month, I live at {this.Address}";
        }

    }
}
