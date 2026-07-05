using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCUniversityApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }

        [Range(150,200,ErrorMessage = "Maximum Value is not between 150 and 200")]
        public int MaxDegree { get; set; }
        
        public int MinDegree { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }
        
    }
}
