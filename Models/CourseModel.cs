using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MVCapp.Models
{
    public class Course
    {
        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"^[a-zA-Z]{2}[0-9]{3}[a-zA-Z]{1}")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "Field is required")]
        public string Progression { get; set; }
        
        [Required(ErrorMessage = "Field is required")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Description { get; set; }
        
    }

    public class ViewModel
    {
        public IEnumerable<Course> CoursesList { get; set; }
    }
}