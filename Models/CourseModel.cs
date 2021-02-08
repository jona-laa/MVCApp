using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCapp.Models
{
    public class Course
    {
        [RegularExpression(@"^[a-zA-Z]{2}[0-9]{3}[a-zA-Z]{1}"), Required(ErrorMessage =" Field is required")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "Field is required")]
        public string Progression { get; set; }
        // public List<SelectListItem> Progression { get; } = new List<SelectListItem>
        // {
        //     new SelectListItem { Value = "A", Text = "A" },
        //     new SelectListItem { Value = "B", Text = "B" },
        //     new SelectListItem { Value = "C", Text = "C"  },
        //     new SelectListItem { Value = "D", Text = "D"  },
        //     new SelectListItem { Value = "E", Text = "E"  },
        //     new SelectListItem { Value = "-", Text = "-"  },
        // };
        
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