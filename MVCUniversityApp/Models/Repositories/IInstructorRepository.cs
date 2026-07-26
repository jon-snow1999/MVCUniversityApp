namespace MVCUniversityApp.Models.Repositories
{
    public interface IInstructorRepository:IRepositery<Instructor>
    {
        public IQueryable getAllNonId();
    }
}
