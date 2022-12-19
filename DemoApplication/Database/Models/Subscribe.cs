using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Subscribe : BaseEntity , IAuditable
    {
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
