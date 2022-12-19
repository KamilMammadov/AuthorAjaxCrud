using DemoApplication.Areas.Client.ViewModels.Subsriber;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplication.Areas.Client.Controllers
{
    [Area("client")]
    [Route("subscriber")]
    public class SubscriberController : Controller
    {
        private readonly DataContext _dataContext;

        public SubscriberController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

      
        [HttpPost("add", Name = "subcriber-add")]
        public async Task<IActionResult> AddAsync([FromBody]SubAddViewModel model)
        {
            var currentEMail = _dataContext.Subscribers.FirstOrDefault(e => e.Email == model.Email);
            if (!ModelState.IsValid || currentEMail is not null)
            {
                return BadRequest();// 400 status code
            }

            if (currentEMail is null)
            {
                _dataContext.Subscribers.Add(new Subscribe
                {
                    Email = model.Email,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });
            }
           await _dataContext.SaveChangesAsync();
            
            return Ok(); //200
        }
    }
}
