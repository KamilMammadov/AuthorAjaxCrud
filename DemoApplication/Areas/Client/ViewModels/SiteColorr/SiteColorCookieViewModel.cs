namespace DemoApplication.Areas.Client.ViewModels.SiteColorr
{
    public class SiteColorCookieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SiteColorCookieViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
