using MVCUniversityApp.Context;

namespace MVCUniversityApp.Models.Repositories
{
    public class CourseRepo : ICourseRepository
    {
        private readonly UniContext db;
        public CourseRepo(UniContext context)
        {
            db = context;
        }
        public void Add(Course entity)
        {
            this.db.Courses.Add(entity);
            
        }

        public void Delete(Course entity)
        {
            this.db.Courses.Remove(entity);
            
        }
        public void Update(Course entity)
        {
            this.db.Update(entity);
        }

        public List<Course> getAll()
        {
            return this.db.Courses.ToList();
        }

        public Course? getById(int id)
        {
           
            return this.db.Courses.FirstOrDefault(course => course.Id == id);
        }

        public void SaveDB()
        {
            this.db.SaveChanges();
        }
    }
}
