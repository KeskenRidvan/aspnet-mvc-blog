﻿using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
	public class AdminUser : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
