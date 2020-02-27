using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApManageStudent.Models
{
    public class Enumerators
    {
        public enum TypeStudent
        {
            Kinder = 1,
            Elementary = 2,
            HighSchool = 3,
            University = 4
        }
        public enum Gender
        {
            Male = 1,
            Female = 2

        }
        public enum Grade
        {
            A=1,
            B=2,
            C=3,
            D=4,
            F=5
        }

    }
}