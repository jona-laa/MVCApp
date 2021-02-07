using System.ComponentModel.DataAnnotations;

namespace MVCapp.Models
{
    public class Skill
    {
        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Skill")]
        public string SkillName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"^(fas)\s(fa-)[a-z]+|^(fab\sfa-)[a-z]+")]
        public string Icon { get; set; }
    }
}
