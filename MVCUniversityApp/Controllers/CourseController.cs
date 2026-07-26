using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVCUniversityApp.Context;
using MVCUniversityApp.Models;
using MVCUniversityApp.ViewModel;
using MVCUniversityApp.Models.Repositories;
namespace MVCUniversityApp.Controllers
{
    public class CourseController : Controller
    {
        public readonly CourseRepo courseRepo;
        public readonly DepartmentRepo departmentRepo;
        //public readonly UniContext db;
        public CourseController()
        {
            this.courseRepo = new CourseRepo();
            this.departmentRepo = new DepartmentRepo();
        }
        public IActionResult Index()
        {
            return View("all", this.courseRepo.getAll());
        }

        public IActionResult Edit(int id)
        {
            Course courseFromDB = this.courseRepo.getById(id);
            CourseWithDeptList cd = new CourseWithDeptList
            {
                course = courseFromDB,
                departments = this.departmentRepo.getAll()
            };
            if (courseFromDB != null)
            {
                return View("edit", cd);
            }
            return View("edit");
        }
        public IActionResult Delete(int id)
        {
            Course courseFromDB = this.courseRepo.getById(id);
            return View("delete", courseFromDB);
        }
        [HttpPost]
        public IActionResult DeleteCourse(int id, string shoulddelete)
        {
            if(shoulddelete == "y")
            {
                Course? courseFromDB = this.courseRepo.getById(id);
                this.courseRepo.Delete(courseFromDB);
                this.courseRepo.SaveDB();
                return RedirectToAction(actionName: "Index", controllerName: "Course");
            } else
            {
                return RedirectToAction(actionName: "Index", controllerName: "Course");
            }
        }

        [HttpPost]
        public IActionResult editCourse(Course courseFromForm)
        {

            
            if (this.ModelState.IsValid == true)
            {
                try
                {
                    this.courseRepo.Update(courseFromForm);
                    this.courseRepo.SaveDB();
                    return RedirectToAction(actionName: "Index", controllerName: "Course");
                } catch (Exception e)
                {
                    this.ModelState.AddModelError("DepartmentId", "You should have entered a correct department");
                    CourseWithDeptList cd = new CourseWithDeptList
                    {
                        course = courseFromForm,
                        departments = this.departmentRepo.getAll()
                    };
                    return View("edit", cd);
                }
               
            }
            else
            {
                CourseWithDeptList cd = new CourseWithDeptList
                {
                    course = courseFromForm,
                    departments = this.departmentRepo.getAll()
                };
                return View("edit", cd);
            }

        }

        public IActionResult newPage()
        {
            return View("New", this.departmentRepo.getAll());
        }

        public IActionResult addNewCourse(Course course)
        {
            if (this.ModelState.IsValid == true)
            {
                try
                {
                    this.courseRepo.Add(course);
                    this.courseRepo.SaveDB();
                    return RedirectToAction(actionName: "Index", controllerName: "Course");
                } catch (Exception e)
                {
                    this.ModelState.AddModelError("DepartmentId", "You have chosen a wrong Department");
                    return View("New", this.departmentRepo.getAll());
                }
                
            }
            else
            {
                return View("New", this.departmentRepo.getAll());
            }

        }

        public IActionResult CheckMin(int minDegree, int maxDegree)
        {
            if(minDegree <= maxDegree)
            {
                return Json(true);
            } else
            {
                return Json("Minimum degree can't be more than the maximum degree");
            }
        }
        }
    }
