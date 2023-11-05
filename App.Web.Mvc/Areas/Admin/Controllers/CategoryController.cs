using App.Business.DTOs.Category;
using App.Business.Services.Abstract;
using App.Persistence.Data.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		ICategoryService _categoryService;
		IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var categories = _categoryService.GetAll();
			return View(categories);
		}

		//CREATE
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateOrEditCategoryDto categoryDto)
		{
			if (categoryDto == null) { return RedirectToAction("Index"); }
			var category = _mapper.Map<Category>(categoryDto);

			if (ModelState.IsValid)
			{
				_categoryService.Insert(category);
				_categoryService.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(category);
		}
		//EDIT
		[HttpGet]
		public IActionResult Edit(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			var category = _categoryService.GetById(id);

			if (category == null)
			{ return RedirectToAction("Index"); }

			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (category == null) { return RedirectToAction("Index"); }

			if (ModelState.IsValid)
			{
				_categoryService.Update(category);
				_categoryService.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(category);
		}
		//DELETE
		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			var category = _categoryService.GetById(id);

			if (category == null)
			{ return RedirectToAction("Index"); }

			return View(category);
		}


		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			_categoryService.DeleteById(id);
			_categoryService.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
