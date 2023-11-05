using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Home()
		{
			return View();
		}
	}
}
