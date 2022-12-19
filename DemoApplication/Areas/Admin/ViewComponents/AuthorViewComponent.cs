using DemoApplication.Areas.Admin.ViewModels.Author;
using DemoApplication.Areas.Client.ViewModels.Basket;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoApplication.Areas.Admin.ViewComponents
{
    [ViewComponent]
    public class AuthorViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;

        public AuthorViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IViewComponentResult Invoke(UpdateViewModel? viewModels)
        {

           var author = _dataContext.Authors.FirstOrDefault(a=>a.Id==viewModels!.Id);

          
            return View(author);
        }

    }
}
