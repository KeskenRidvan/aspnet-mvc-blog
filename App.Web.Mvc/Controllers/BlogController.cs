using App.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class BlogController : Controller
	{
		private readonly IPostService _postService;

		public BlogController(IPostService postService)
		{

			_postService = postService;
		}

		public IActionResult Search(string query, int page)
		{
			return View();
		}
		[Route("/blog/title-slug")]
		public IActionResult Detail(int id)
		{
			if (id == 0)
				return RedirectToAction(nameof(Index));

			var post = _postService.GetById(id);
			if (post is null)
				return RedirectToAction(nameof(Index));

			ViewBag.CategoryName = _postService.GetCategoryName(id);
			return View(post);

		}
	}
}
