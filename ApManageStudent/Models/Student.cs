using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApManageStudent.Models
{
    public class Student
    {       
        public int Id { get; set; }

        [Display(Name = "Type Student")]
        [Required(ErrorMessage = "The Type Student is required")]
        public Enumerators.TypeStudent TypeStudent { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "The Name is required")]

        public string Name { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "The Gender is required")]

        public Enumerators.Gender Gender { get; set; }
        [Display(Name = "Last Conection")]
        public DateTime LastConection { get; set; }
        public List<Models.Course> Courses{ get; set; }

    }
}