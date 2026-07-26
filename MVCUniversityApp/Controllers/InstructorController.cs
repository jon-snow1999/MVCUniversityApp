using Microsoft.AspNetCore.Mvc;
using MVCUniversityApp.Context;
using MVCUniversityApp.Models;
using MVCUniversityApp.Models.Repositories;

namespace MVCUniversityApp.Controllers
{
    public class InstructorController : Controller
    {

        public readonly IInstructorRepository InstructorRepo;
        public readonly IDepartmentRepository DepartmentRepo;

        public InstructorController(IInstructorRepository instructor, IDepartmentRepository department)
        {
            this.InstructorRepo = instructor;
            this.DepartmentRepo = department;
        }
        public IActionResult Index()
        {
          

            return View("all", this.InstructorRepo.getAllNonId());
        }

        public IActionResult Details(int id)
        {
           
            Instructor teacher = this.InstructorRepo.getById(id);
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
            Department lastDepartment = this.DepartmentRepo.getLastDeparment();
            if (instructor.Name != null && instructor.ImageUrl != null && instructor.Salary != null && instructor.Address != null && instructor.DepartmentId != null && instructor.DepartmentId <= lastDepartment.Id)
            {
                this.InstructorRepo.Add(instructor);
                this.InstructorRepo.SaveDB();
                return RedirectToAction(actionName: "Index", controllerName: "Instructor");
            } else
            {
                return Content("You have added an invalid instructor data");
            }
            
            
        }
    }
}
