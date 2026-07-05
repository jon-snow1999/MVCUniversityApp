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
        public IActionResult Delete(int id)
        {
            Course courseFromDB = db.Courses.FirstOrDefault((course) => course.Id == id);
            return View("delete", courseFromDB);
        }
        public IActionResult DeleteCourse(int id, string shoulddelete)
        {
            if(shoulddelete == "y")
            {
                Course? courseFromDB = db.Courses.FirstOrDefault((course) => course.Id == id);
                db.Courses.Remove(courseFromDB);
                db.SaveChanges();
                return RedirectToAction(actionName: "Index", controllerName: "Course");
            } else
            {
                return RedirectToAction(actionName: "Index", controllerName: "Course");
            }
        }

        [HttpPost]
        public IActionResult editCourse(Course courseFromForm)
        {

            //Course corseFromDB = db.Courses.FirstOrDefault((course) => course.Id == courseFromForm.Id);
            if (this.ModelState.IsValid == true)
            {
                try
                {
                    db.Courses.Update(courseFromForm);
                    db.SaveChanges();
                    return RedirectToAction(actionName: "Index", controllerName: "Course");
                } catch (Exception e)
                {
                    this.ModelState.AddModelError("DepartmentId", "You should have entered a correct department");
                    CourseWithDeptList cd = new CourseWithDeptList
                    {
                        course = courseFromForm,
                        departments = db.Departments.ToList()
                    };
                    return View("edit", cd);
                }
               
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
            if (this.ModelState.IsValid == true)
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

        public IActionResult CheckMinDegree(int minDegre)
        {
            if (minDegre>=10 && minDegre <=50) 
            {
                return Json(true);
            }
            return Json("Minimum degree must be between 10 and 50");
        }
        }
    }
