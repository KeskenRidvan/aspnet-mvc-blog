using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class AdminPage : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
