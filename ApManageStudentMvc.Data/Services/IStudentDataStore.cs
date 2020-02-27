using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApManageStudent.Data.Services
{
    public interface IStudentDataStore
    {
        List<Entities.Student> GetStudent();
        Entities.Student GetByID(int id);
        bool Register(Entities.Student student);
        bool Modify(Entities.Student student);
        bool Delete(int id);
    }
}
