using Microsoft.EntityFrameworkCore;
using MVCUniversityApp.Context;
namespace MVCUniversityApp.Models.Repositories
{
    public class InstructorRepo :IInstructorRepository
    {
        private readonly UniContext db;
        public InstructorRepo(UniContext context)
        {
            db = context;
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

        public IQueryable getAllNonId()
        {
            return this.db.Instructors.Where((instruct) => instruct.Id != null);
        }
    }
}
