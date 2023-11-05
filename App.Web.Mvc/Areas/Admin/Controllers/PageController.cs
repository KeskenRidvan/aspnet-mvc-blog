using App.Business.DTOs.Page;
using App.Business.Services.Abstract;
using App.Persistence.Data.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PageController : Controller
	{
		IPageService _pageService;
		IMapper _mapper;

		public PageController(IPageService pageService, IMapper mapper)
		{
			_pageService = pageService;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			var pages = _pageService.GetAll();
			return View(pages);
		}

		//CREATE
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateOrEditPageDto pageDto)
		{
			if (pageDto == null) { return RedirectToAction("Index"); }
			var page = _mapper.Map<Page>(pageDto);

			if (ModelState.IsValid)
			{
				_pageService.Insert(page);
				_pageService.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(page);
		}
		//EDIT
		[HttpGet]
		public IActionResult Edit(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			var page = _pageService.GetById(id);

			if (page == null)
			{ return RedirectToAction("Index"); }

			return View(page);
		}

		[HttpPost]
		public IActionResult Edit(Page page)
		{
			if (page == null) { return RedirectToAction("Index"); }

			if (ModelState.IsValid)
			{
				_pageService.Update(page);
				_pageService.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(page);
		}

		//DELETE
		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			var page = _pageService.GetById(id);

			if (page == null)
			{ return RedirectToAction("Index"); }

			return View(page);
		}


		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			_pageService.DeleteById(id);
			_pageService.SaveChanges();
			return RedirectToAction("Index");

		}

	}
}
