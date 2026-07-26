using Microsoft.EntityFrameworkCore;
using MVCUniversityApp.Context;
namespace MVCUniversityApp.Models.Repositories
{
    public class InstructorRepo : IRepositery<Instructor>
    {
        private readonly UniContext db;
        public InstructorRepo()
        {
            db = new UniContext();
        }
        public void Add(Instructor entity)
        {
            this.db.Instructors.Add(entity);
            
        }

        public void Delete(Instructor entity)
        {
            this.db.Instructors.Remove(entity);
           
        }
        public void Update(Instructor entity)
        {
            this.db.Update(entity);
        }

        public List<Instructor> getAll()
        {
            return this.db.Instructors.ToList();
        }

        public Instructor? getById(int id)
        {
            return this.db.Instructors.FirstOrDefault(ins => ins.Id == id);
        }

        public void SaveDB()
        {
            this.db.SaveChanges();
        }

       
    }
}
