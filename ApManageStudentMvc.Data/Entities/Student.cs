using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApManageStudent.Data.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Type Student")]
        [Required(ErrorMessage = "The Type Student is required")]

        public int TypeStudent { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "The Name is required")]
        [MaxLength(50)]

        public string Name { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "The Gender is required")]

        public int Gender { get; set; }
        [Display(Name = "Last Conection")]
        public DateTime ModifyDate { get; set; }

    }
}
