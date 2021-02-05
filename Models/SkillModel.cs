using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCapp.Models
{
    public class Skill
    {
        [Required(ErrorMessage = "Fyll i fält")]
        [Display(Name = "Skill")]
        public string SkillName { get; set; }

        [Required(ErrorMessage = "Fyll i fält")]
        public string Icon { get; set; }
    }
}
