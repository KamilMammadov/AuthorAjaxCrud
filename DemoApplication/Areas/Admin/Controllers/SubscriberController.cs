using DemoApplication.Areas.Admin.ViewModels.Subcriber;
using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/subcriber")]
    public class SubscriberController : Controller
    {
        private readonly DataContext _dataContext;

        public SubscriberController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("list",Name ="admin-subcriber-list")]
        public async Task<IActionResult> ListAsync()
        {

            var model = await _dataContext.Subscribers.Select(s => new ListItemViewModel(s.Email, s.CreatedAt)).ToListAsync();

            return View(model);
        }
    }
}
