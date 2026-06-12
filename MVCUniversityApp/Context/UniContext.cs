using Microsoft.EntityFrameworkCore;
using MVCUniversityApp.Models;

namespace MVCUniversityApp.Context
{
    public class UniContext: DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResult> CourseResult { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=UniDBTwo;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Application Name=\"SQL Server Management Studio\";Command Timeout=0");            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseResult>().HasKey((CR) => new {CR.TraineeId, CR.CourseId});
        }
    }
}
