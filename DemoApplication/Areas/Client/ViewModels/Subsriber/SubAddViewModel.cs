using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Client.ViewModels.Subsriber
{
    public class SubAddViewModel
    {
      

        [Required]
        [EmailAddress]
        public string Email { get; set; }
       
      
        public SubAddViewModel(string email)
        {
      
            Email = email;
      
        }

    }
}
