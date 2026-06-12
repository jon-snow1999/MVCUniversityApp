using System.ComponentModel.DataAnnotations.Schema;

namespace MVCUniversityApp.Models
{
    public class Trainee: BaseClass
    {
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string Grade { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
