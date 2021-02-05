using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MVCapp.Models
{
    public class Course
    {
        [Required(ErrorMessage = "Fyll i fält")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "Fyll i fält")]
        public string Name { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "Max två tecken")]
        public string Progression { get; set; }
        
        [Required(ErrorMessage = "Fyll i fält")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Fyll i fält")]
        public string Description { get; set; }
        
    }

    public class ViewModel
    {
        public IEnumerable<Course> CoursesList { get; set; }
    }
}