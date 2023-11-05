using App.Persistence.Data;
using App.Persistence.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class AuthController : Controller
	{

		private readonly AppDbContext _context;

		public AuthController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Register()
		{
			User user = new User();
			return View();
		}

		[HttpPost]
		public IActionResult Register(User model)
		{
			if (model == null)
				return View(model);

			if (!ModelState.IsValid)
				return View(model);

			_context.Add(model);
			_context.SaveChanges();

			return RedirectToAction(controllerName: "Home", actionName: "Index");
		}

		public IActionResult Login(string redirectUrl)
		{
			return View();
		}
		public IActionResult ForgotPassword()
		{
			return View();
		}
	}
}
