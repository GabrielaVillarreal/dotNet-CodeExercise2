using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApManageStudent.Controllers
{
    public class StudentController : Controller
    {

        readonly ApManageStudent.DA.IStudentDataStore _studentDataStore;
        readonly ApManageStudent.DA.ICourseDataStore _courseDataStore;
        public StudentController(
          ApManageStudent.DA.IStudentDataStore studentDataStore,
          ApManageStudent.DA.ICourseDataStore courseDataStore)
        {
            _studentDataStore = studentDataStore;
            _courseDataStore = courseDataStore;
        }

        // GET: Student
        public ActionResult StudentsList()
        {
            List<Models.Student> students = _studentDataStore.GetStudent().Select(
              student => new Models.Student()
              {
                  Id = student.Id,
                  TypeStudent = (Models.Enumerators.TypeStudent)student.TypeStudent,
                  Name = student.Name,
                  Gender = (Models.Enumerators.Gender)student.Gender,
                  LastConection = student.ModifyDate
              }).ToList();

            return View(students);
        }

        [HttpGet]
        public ActionResult RegisterStudent()
        {
            Models.Student studentModel = new Models.Student();
            //model.EstadoCivil = Models.Enumeradores.EstadoCivil.Soltero;
            // Enviamos el modelo a la vista
            return View(studentModel);
        }



        [HttpPost]
        public ActionResult RegisterStudent(Models.Student studentModel)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _studentDataStore.Register(new EN.Student
                {
                    TypeStudent = (int)studentModel.TypeStudent,
                    Name = studentModel.Name,
                    Gender = (int)studentModel.Gender,
                    ModifyDate = studentModel.LastConection,

                });

                if (respuesta)
                {
                    return RedirectToAction("StudentsList");
                }
            }
            return View(studentModel);
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var _student = _studentDataStore.GetByID(id);
            Models.Student studentModel = new Models.Student
            {
                Id = _student.Id,
                Name = _student.Name,
                LastConection = _student.ModifyDate


            };

            return View(studentModel);
        }
      
        [HttpPost] 
        public ActionResult DeleteStudent(Models.Student studentModel)
        {
            bool resultado = false;
            if (studentModel.Id > 0)
            {             
                resultado = _studentDataStore.Delete(studentModel.Id);                
            }         

            if (resultado)
            {
                return RedirectToAction("StudentsList");
            }
            return View(studentModel);
        }
        [HttpGet]
        public ActionResult StudentDetail(int id)
        {
           
            var studentEntity = _studentDataStore.GetByID(id);           
            Models.Student studentModel = new Models.Student()
            {
                Id = studentEntity.Id,
                Name = studentEntity.Name,
                TypeStudent = (Models.Enumerators.TypeStudent)studentEntity.TypeStudent,
                Gender = (Models.Enumerators.Gender)studentEntity.Gender,
                LastConection = studentEntity.ModifyDate,               
            };
      
            var coursesEntity = _courseDataStore.GetbyIdstudent(studentModel.Id);
   
            studentModel.Courses= coursesEntity.Select(course => new Models.Course
            {
                Title = course.Title,
                Credits = course.Credits,                
                Grade = (int)course.Grade
               
            }).ToList();
            return View(studentModel);
        }
        
        [HttpGet]
        public ActionResult ModifyStudent(int id)
        {
            Models.Student studentModel = new Models.Student();


            var _student = _studentDataStore.GetByID(id);

            studentModel.Id = _student.Id;
            studentModel.TypeStudent = (Models.Enumerators.TypeStudent)_student.TypeStudent;
            studentModel.Name = _student.Name;
            studentModel.Gender = (Models.Enumerators.Gender)_student.Gender;
            studentModel.LastConection = _student.ModifyDate;


            return View(studentModel);
        }
           
        [HttpPost]
        public ActionResult ModifyStudent(Models.Student studentModel)
        {
            if (ModelState.IsValid)
            {
                var respuesta = _studentDataStore.Modify(new EN.Student()
                {
                    Id = studentModel.Id,
                    TypeStudent = (int)studentModel.TypeStudent,
                    Name = studentModel.Name,
                    Gender = (int)studentModel.Gender,
                    ModifyDate = DateTime.Now   

                });

                if (respuesta)
                {
                    return RedirectToAction("StudentsList");
                }               

            }           
            return View(studentModel);
        }

    }
}