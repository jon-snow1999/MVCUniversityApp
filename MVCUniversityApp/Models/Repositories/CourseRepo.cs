using MVCUniversityApp.Context;

namespace MVCUniversityApp.Models.Repositories
{
    public class CourseRepo : IRepositery<Course>
    {
        private readonly UniContext db;
        public CourseRepo()
        {
            db = new UniContext();
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
