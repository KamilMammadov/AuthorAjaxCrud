using DemoApplication.Areas.Client.ViewComponents;
using DemoApplication.Areas.Client.ViewModels.Basket;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("Client")]
    [Route("Basket")]
    public class BasketController : Controller
    {

        private readonly DataContext _datacontext;

        public BasketController(DataContext datacontext)
        {
            _datacontext = datacontext;
        }


  
        [HttpGet("add/{id}",Name ="client-basket-add")]
        public async Task<IActionResult> AddAsync([FromRoute] int id)
        {
            var book = await _datacontext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book is null) return NotFound();

            var booksCookie = HttpContext.Request.Cookies["books"];
            var booksViewModel = new List<BookViewModel>();


            if (booksCookie is null)
            {

                var model = new List<BookViewModel>() {
                    new BookViewModel(book.Id, book.Title, String.Empty, book.Price, 1, book.Price)
                };
                HttpContext.Response.Cookies.Append("books", JsonSerializer.Serialize(model));
            }
            else
            {
                booksViewModel = JsonSerializer.Deserialize<List<BookViewModel>>(booksCookie);

                var cookieModel = booksViewModel.FirstOrDefault(b => b.Id == book.Id);

                if (cookieModel is null)
                {
                    booksViewModel.Add(new BookViewModel(book.Id, book.Title, String.Empty, book.Price, 1, book.Price));
                    HttpContext.Response.Cookies.Append("books", JsonSerializer.Serialize(booksViewModel));
                }
                else
                {
                    cookieModel.Quantity+=1;
                    cookieModel.Total=cookieModel.Price * cookieModel.Quantity;
                    HttpContext.Response.Cookies.Append("books", JsonSerializer.Serialize(booksViewModel));

                }


            }



            return ViewComponent(nameof(ShopCard), booksViewModel);
        }


        [HttpGet("delete/{id}", Name = "client-basket-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {

            var book = await _datacontext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)  return NotFound();

            var booksCookie = HttpContext.Request.Cookies["books"];

            if (booksCookie == null) return NotFound();

            var booksViewModel= JsonSerializer.Deserialize<List<BookViewModel>>(booksCookie);

            booksViewModel.RemoveAll(p => p.Id == id);

            HttpContext.Response.Cookies.Append("books", JsonSerializer.Serialize(booksViewModel));


                       return ViewComponent(nameof(ShopCard), booksViewModel);


        }

    }
}
