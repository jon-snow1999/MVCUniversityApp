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

        public IActionResult addNew()
        {
            return View("New");
        }
        [HttpPost]
        public IActionResult add(Instructor instructor)
        {
            UniContext db = new UniContext();
            Department lastDepartment = db.Departments.OrderBy((department) => department.Id).Last();
            if (instructor.Name != null && instructor.ImageUrl != null && instructor.Salary != null && instructor.Address != null && instructor.DepartmentId != null && instructor.DepartmentId <= lastDepartment.Id)
            {
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction(actionName: "Index", controllerName: "Instructor");
            } else
            {
                return Content("You have added an invalid instructor data");
            }
            
            
        }
    }
}
