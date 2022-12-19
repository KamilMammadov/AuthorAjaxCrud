using DemoApplication.Areas.Client.ViewModels.Basket;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DemoApplication.Areas.Client.ViewComponents
{
    [ViewComponent]
    public class ShopCard : ViewComponent
    {
        public IViewComponentResult Invoke(List<BookViewModel>? viewModels)
        {
            var cookie = HttpContext.Request.Cookies["products"];
            var cookieViewModel = new List<BookViewModel>();

            if (cookie is not null)
            {
                cookieViewModel = JsonSerializer.Deserialize<List<BookViewModel>>(cookie);
            }
            if (viewModels is not null)
            {
                cookieViewModel = viewModels;
            }
            return View(cookieViewModel);
        }

    }
}
