using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class SiteColor : BaseEntity
    {
      
        public string Name { get; set; }
        public SiteColor(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
