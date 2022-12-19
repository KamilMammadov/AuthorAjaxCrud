using DemoApplication.Areas.Admin.ViewComponents;
using DemoApplication.Areas.Admin.ViewModels.Author;
using DemoApplication.Database;
using DemoApplication.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/author")]
    public class AuthorController : Controller
    {
        private readonly DataContext _dataContext;

        public AuthorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("list", Name = "admin-author-list")]
        public IActionResult List()
        {
            var model = _dataContext.Authors
                .Select(a => new ListItemViewModel(a.Id, a.FirstName, a.LastName))
                .ToList();

            return View(model);
        }
        [HttpPost("add", Name = "admin-author-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            var newmodel = new Author
            {
                FirstName = model.Name,
                LastName = model.LastName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };

            await _dataContext.Authors.AddAsync(newmodel);




            await _dataContext.SaveChangesAsync();

            var id = newmodel.Id;

            return Created("admin-author-list", id);
        }
        [HttpDelete("delete/{id}", Name = "admin-author-delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var model = await _dataContext.Authors.FirstOrDefaultAsync(a => a.Id == id);

            if (model is null)
            {
                return NotFound();
            }


            _dataContext.Authors.Remove(model);
            await _dataContext.SaveChangesAsync();

            return ViewComponent(nameof(AuthorViewComponent), model);
        }


        [HttpGet("update/{id}", Name = "admin-author-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {
            var author = await _dataContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author is null)
            {
                return NotFound();
            }

            var model = new AddViewModel
            {
                Name = author.FirstName,
                LastName = author.LastName
            };

            return ViewComponent(nameof(AuthorViewComponent), model);
        }
        [HttpPost("update/{id}", Name = "admin-author-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, AddViewModel model)
        {
            var author = await _dataContext.Authors.FirstOrDefaultAsync(b => b.Id == id);
            if (author is null)
            {
                return NotFound();
            }


            author.FirstName = model.Name;
            author.LastName = model.LastName;

            await _dataContext.SaveChangesAsync();

            var idview = author.Id;

            return Created("admin-author-list", id);
        }
    }
}
