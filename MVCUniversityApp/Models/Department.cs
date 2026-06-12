using System.ComponentModel.DataAnnotations;

namespace MVCUniversityApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public List<Instructor> instructors = new List<Instructor>();


    }
}
