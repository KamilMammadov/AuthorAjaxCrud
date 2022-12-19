using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Admin.ViewModels.Subcriber
{
    public class ListItemViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public DateTime CreadetAt { get; set; }
        public ListItemViewModel( string email, DateTime creadetAt)
        {
      
            Email = email;
            CreadetAt = creadetAt;
        }

    }
}
