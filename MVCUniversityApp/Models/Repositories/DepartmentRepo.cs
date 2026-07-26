using MVCUniversityApp.Context;

namespace MVCUniversityApp.Models.Repositories
{
    public class DepartmentRepo : IDepartmentRepository
    {
        private readonly UniContext db;
        public DepartmentRepo(UniContext context)
        {
            this.db = context;
        }
        public void Add(Department entity)
        {
            this.db.Departments.Add(entity);
            
        }

        public void Delete(Department entity)
        {
            this.db.Departments.Remove(entity);
        }
        public void Update(Department entity)
        {
            this.db.Update(entity);
        }

        public List<Department> getAll()
        {
            return this.db.Departments.ToList();
        }

        public Department? getById(int id)
        {
            return this.db.Departments.FirstOrDefault((department) => department.Id == id);
        }

        public void SaveDB()
        {
            this.db.SaveChanges();
        }

        public Department getLastDeparment()
        {
            return this.db.Departments.OrderBy((department) => department.Id).Last();
        }
    }
}
