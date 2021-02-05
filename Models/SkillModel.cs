using System.ComponentModel.DataAnnotations;

namespace MVCapp.Models
{
    public class Skill
    {
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Skill")]
        public string SkillName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Icon { get; set; }
    }
}
