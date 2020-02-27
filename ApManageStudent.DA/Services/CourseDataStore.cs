using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApManageStudent.EN;

namespace ApManageStudent.DA
{
    public class CourseDataStore : ICourseDataStore
    {
        private readonly DataBaseContext _db;
        public CourseDataStore(DataBaseContext db)
        {
            _db = db;
        }
        public bool Delete(Course course)
        {
            throw new NotImplementedException();
        }

        public Course GetById(int id)
        {
            return _db.Courses.FirstOrDefault(m => m.CourseID == id);
        }

        public List<Course> GetbyIdstudent(int idStudent)
        {
            return _db.Courses.Where(m => m.StudentID == idStudent).ToList();
        }

        public bool Modify(Course course)
        {
            throw new NotImplementedException();
        }

        public bool Registry(Course course)
        {
            try
            {                
                _db.Courses.Add(course);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
