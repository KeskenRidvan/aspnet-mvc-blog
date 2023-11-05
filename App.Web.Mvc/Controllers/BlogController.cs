using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Search(string query, int page)
		{
			return View();
		}
		[Route("/blog/title-slug")]
		public IActionResult Detail(int blogId)
		{
			return View();
		}
	}
}
