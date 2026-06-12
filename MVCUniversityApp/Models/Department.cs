using System.ComponentModel.DataAnnotations;

namespace MVCUniversityApp.Models
{
    public class Department: BaseClass
    {
        public string Manager { get; set; }

        public List<Instructor> instructors = new List<Instructor>();
        public List<Course> Courses = new List<Course>();



    }
}
