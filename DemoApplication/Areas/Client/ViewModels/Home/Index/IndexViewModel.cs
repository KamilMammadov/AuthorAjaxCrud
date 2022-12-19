using DemoApplication.Database.Models;

namespace DemoApplication.Areas.Client.ViewModels.Home.Index
{
    public class IndexViewModel
    {
        public List<BookListItemViewModel> Books { get; set; }

        public List<SiteColor> SiteColors { get; set; }

    }
}
