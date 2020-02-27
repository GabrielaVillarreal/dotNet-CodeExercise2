using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApManageStudent.EN;

namespace ApManageStudent.DA
{
    public class StudentDataStore : IStudentDataStore
    {
        private readonly DataBaseContext _db;
        public StudentDataStore(DataBaseContext db)
        {
            _db = db;
        }
        public bool Delete(int id)
        {
            try
            {
                var student = _db.Students.FirstOrDefault(p => p.Id == id);
                if (student != null)
                {
                    _db.Students.Remove(student);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Student GetByID(int id)
        {
            return _db.Students.FirstOrDefault(p => p.Id == id);
        }

        public List<Student> GetStudent()
        {
            return _db.Students.ToList();
        }

        public bool Modify(Student student)
        {
            try
            {
                var entry = _db.Entry(student);
                entry.State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Register(Student student)
        {
            try
            {
                student.ModifyDate = DateTime.Now;
                _db.Students.Add(student);
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
