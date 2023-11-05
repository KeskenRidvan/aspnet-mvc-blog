using App.Business.Services.Abstract;
using App.Persistence.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class AuthController : Controller
	{

		//private readonly AppDbContext _db;
		private readonly IUserService _userService;
		public AuthController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Register()
		{
			User user = new User();

			return View(user);
		}

		[HttpPost]
		public IActionResult Register(User user)
		{
			if (user == null)
			{
				return View();
			}
			if (ModelState.IsValid)
			{
				_userService.Insert(user);
				_userService.SaveChanges();

				return RedirectToAction("Index", "Home");
			}

			return View(user);
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
