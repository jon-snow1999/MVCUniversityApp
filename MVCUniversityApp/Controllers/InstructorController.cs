using Microsoft.AspNetCore.Mvc;
using MVCUniversityApp.Context;
using MVCUniversityApp.Models;

namespace MVCUniversityApp.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult Index()
        {
            UniContext db = new UniContext();

            return View("all", db.Instructors.Where((instructor) => instructor.Id != null));
        }

        public IActionResult Details(int id)
        {
            UniContext db = new UniContext();
            Instructor teacher = db.Instructors.FirstOrDefault((instructor) => instructor.Id == id);
            if(teacher != null)
            {
                return View("Details", teacher);
            } else
            {
                return View("Details", null);
            }
            
        }
    }
}
