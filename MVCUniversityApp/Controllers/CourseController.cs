using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVCUniversityApp.Context;
using MVCUniversityApp.Models;
using MVCUniversityApp.ViewModel;
namespace MVCUniversityApp.Controllers
{
    public class CourseController : Controller
    {

        UniContext db = new UniContext();
        public IActionResult Index()
        {
            return View("all", db.Courses.ToList());
        }

        public IActionResult Edit(int id)
        {
            Course courseFromDB = db.Courses.FirstOrDefault((course) => course.Id == id);
            CourseWithDeptList cd = new CourseWithDeptList
            {
                course = courseFromDB,
                departments = db.Departments.ToList()
            };
            if (courseFromDB != null)
            {
                return View("edit", cd);
            }
            return View("edit");
        }

        [HttpPost]
        public IActionResult editCourse(Course courseFromForm)
        {

            //Course corseFromDB = db.Courses.FirstOrDefault((course) => course.Id == courseFromForm.Id);
            if (courseFromForm?.Name != null && courseFromForm?.MaxDegree != null && courseFromForm?.MinDegree != null)
            {
                db.Courses.Update(courseFromForm);
                db.SaveChanges();
                return RedirectToAction(actionName: "Index", controllerName: "Course");
            }
            else
            {
                CourseWithDeptList cd = new CourseWithDeptList
                {
                    course = courseFromForm,
                    departments = db.Departments.ToList()
                };
                return View("edit", cd);
            }

        }

        public IActionResult newPage()
        {
            return View("New", db.Departments.ToList());
        }

        public IActionResult addNewCourse(Course course)
        {
            if (course.Name != null)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction(actionName: "Index", controllerName: "Course");
            }
            else
            {
                return View("New", db.Departments.ToList());
            }

        }
        }
    }
