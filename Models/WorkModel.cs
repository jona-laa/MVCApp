using System.ComponentModel.DataAnnotations;


namespace MVCapp.Models
{
    public class Work
    {        
       
        [Required(ErrorMessage = "Field is required")]
        public string Company { get; set; }
        
        [Required(ErrorMessage = "Field is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string Description { get; set; }
    }   
}

