using System.ComponentModel.DataAnnotations.Schema;

namespace MVCUniversityApp.Models
{
    public class Course: BaseClass
    {
        public int MaxDegree { get; set; }
        public int MinDegree { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        
    }
}
