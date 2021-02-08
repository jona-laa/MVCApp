using System.ComponentModel.DataAnnotations;

namespace MVCapp.Models
{
    public class Skill
    {
        [Display(Name = "Skill"), Required(ErrorMessage = "Field is required")]
        public string SkillName { get; set; }

        [RegularExpression(@"^(fas)\s(fa-)[a-z]+|^(fab\sfa-)[a-z]+"), Required(ErrorMessage =" Field is required")]
        public string Icon { get; set; }
    }
}
