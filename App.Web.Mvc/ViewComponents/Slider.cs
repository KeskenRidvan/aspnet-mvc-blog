using App.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc.ViewComponents
{

	public class Slider : ViewComponent
	{
		private readonly AppDbContext _context;

		public Slider(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(_context.Posts.Include(x => x.Images).Include(x => x.CategoryPosts).ThenInclude(cp => cp.Category).ToList());
		}
	}
}
