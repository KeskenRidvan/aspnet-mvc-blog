using App.Business.Services.Abstract;
using App.Persistence.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SettingController : Controller
	{
		ISettingService _settingService;
		public SettingController(ISettingService settingService)
		{
			_settingService = settingService;
		}
		public IActionResult Index()
		{
			//logged in user setting get
			int loggedInUserId = 1;
			var settings = _settingService.GetById(loggedInUserId);
			return View(settings);
		}

		//EDIT
		[HttpGet]
		public IActionResult Edit(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			var setting = _settingService.GetById(id);

			if (setting == null)
			{ return RedirectToAction("Index"); }

			return View(setting);
		}

		[HttpPost]
		public IActionResult Edit(Setting setting)
		{
			if (setting == null) { return RedirectToAction("Index"); }

			if (ModelState.IsValid)
			{
				_settingService.Update(setting);
				_settingService.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(setting);
		}

	}
}
