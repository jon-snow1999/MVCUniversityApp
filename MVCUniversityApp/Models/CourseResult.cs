using System.ComponentModel.DataAnnotations.Schema;

namespace MVCUniversityApp.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course? Course { get; set; }
        public int TraineeId { get; set; }
        [ForeignKey("TraineeId")]
        public virtual Trainee? Trainee { get; set; }


    }
}
