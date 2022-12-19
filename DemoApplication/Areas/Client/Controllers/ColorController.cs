using DemoApplication.Areas.Client.ViewModels.SiteColorr;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("color")]
    public class ColorController : Controller
    {
       
        private readonly DataContext _dbContext;
        public ColorController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("add/{id}", Name = "client-color-add")]
        public async  Task<IActionResult> AddColorAsync([FromRoute]int id)
        {
            var color = await _dbContext.SiteColors.FirstOrDefaultAsync(b => b.Id == id);

            var colorsCookieValue =  HttpContext.Request.Cookies["sitecolors"];

            if(colorsCookieValue is null)
            {
                var siteColorsCokieeVewModel = new SiteColorCookieViewModel(color!.Id, color.Name);

                HttpContext.Response.Cookies
                    .Append("SiteColors",
                    JsonSerializer
                    .Serialize(siteColorsCokieeVewModel));
            }
            else
            {
                var siteColorsCokieeVewModel = JsonSerializer
                    .Deserialize<SiteColorCookieViewModel>(colorsCookieValue);

                siteColorsCokieeVewModel = new SiteColorCookieViewModel(color!.Id, color.Name);

                HttpContext.Response.Cookies
                  .Append("SiteColors",
                  JsonSerializer
                  .Serialize(siteColorsCokieeVewModel));
            }


            return RedirectToRoute("client-home-index");
        }
    }
}
