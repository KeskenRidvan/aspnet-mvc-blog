using App.Business.Dtos.User;
using App.Business.Services.Abstract;
using App.Persistence.Data.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		IUserService _userService;
		IMapper _mapper;

		public UserController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var users = _userService.GetAll();
			return View(users);
		}

		//CREATE
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateOrEditUserDto userDto)
		{
			if (userDto == null) { return RedirectToAction("Index"); }
			var user = _mapper.Map<User>(userDto);

			if (ModelState.IsValid)
			{
				_userService.Insert(user);
				_userService.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(user);
		}
		//EDIT
		[HttpGet]
		public IActionResult Edit(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			var user = _userService.GetById(id);

			if (user == null)
			{ return RedirectToAction("Index"); }

			return View(user);
		}

		[HttpPost]
		public IActionResult Edit(User user)
		{
			if (user == null) { return RedirectToAction("Index"); }

			if (ModelState.IsValid)
			{
				_userService.Update(user);
				_userService.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(user);
		}

		//DELETE
		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			var user = _userService.GetById(id);

			if (user == null)
			{ return RedirectToAction("Index"); }

			return View(user);
		}


		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			_userService.DeleteById(id);
			_userService.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
