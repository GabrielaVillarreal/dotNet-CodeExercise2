using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApManageStudent.EN
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        
        public int StudentID { get; set; }
        [Display(Name = "Tittle")]
        [Required(ErrorMessage = "The Type Student is required")]
        public string Title { get; set; }
        [Display(Name = "Credits")]
        [Required(ErrorMessage = "Credits are required")]
        public int Credits { get; set; }
        [Display(Name = "Grade")]
        [Required(ErrorMessage = "The Grade is required")]
        public int Grade { get; set; }

      
    }
}
