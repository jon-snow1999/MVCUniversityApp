using Microsoft.AspNetCore.Mvc;
using MVCUniversityApp.Context;

namespace MVCUniversityApp.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult Index()
        {
            UniContext db = new UniContext();

            return View("all", db.Instructors.Where((instructor) => instructor.Id != null));
        }

        public IActionResult Details(int Id)
        {
            
            return View("Details");
        }
    }
}
