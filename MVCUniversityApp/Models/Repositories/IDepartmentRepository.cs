namespace MVCUniversityApp.Models.Repositories
{
    public interface IDepartmentRepository:IRepositery<Department>
    {
        public Department getLastDeparment();
    }
}
