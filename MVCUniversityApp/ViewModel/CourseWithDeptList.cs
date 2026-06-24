using MVCUniversityApp.Models;

namespace MVCUniversityApp.ViewModel
{
    public class CourseWithDeptList
    {
        public Course course { get; set; }
        public List<Department> departments { get; set; }
    }
}
