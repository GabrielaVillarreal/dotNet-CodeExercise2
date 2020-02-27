using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApManageStudent.Controllers
{
    public class CourseController : Controller
    {
        readonly DA.ICourseDataStore _courseDataStore;
        public CourseController(
          DA.ICourseDataStore coursetDataStore)
        {
            _courseDataStore = coursetDataStore;
        }

        // GET: Course
       
        [HttpGet]
        public ActionResult RegisterCourse(int idStudent)
        {
            Models.Course courseModel = new Models.Course();
            courseModel.StudentID = idStudent;
            return View(courseModel);
        }

        [HttpPost]
        public ActionResult RegisterCourse(Models.Course courseModel)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _courseDataStore.Registry(new EN.Course
                {
                    Title = courseModel.Title,
                    Credits = courseModel.Credits,
                    Grade = courseModel.Grade,
                    StudentID = courseModel.StudentID,
                    
                });

                if (respuesta)
                {
                    return RedirectToAction("StudentDetail", "Student", new { id = courseModel.StudentID });
                }
            }
            return View(courseModel);
        }
    }
}