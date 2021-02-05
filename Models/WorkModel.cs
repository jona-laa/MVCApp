using System.ComponentModel.DataAnnotations;


namespace MVCapp.Models
{
    public class Work
    {        
       
        [Required(ErrorMessage = "Fyll i fält")]
        public string Company { get; set; }
        
        [Required(ErrorMessage = "Fyll i fält")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fyll i fält")]
        public string Description { get; set; }
    }   
}

