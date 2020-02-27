using ApManageStudent.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApManageStudent.DA
{
   public  interface IStudentDataStore
    {
        List<Student> GetStudent();
        Student GetByID(int id);
        bool Register(Student student);
        bool Modify(Student student);
        bool Delete(int id);
    }
}
