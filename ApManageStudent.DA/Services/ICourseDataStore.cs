using ApManageStudent.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApManageStudent.DA
{
    public interface ICourseDataStore
    {
        List<Course> GetbyIdstudent(int idStudent);
        bool Registry(Course course);
        bool Modify(Course course);
        bool Delete(Course course);
        Course GetById(int id);
    }
}
