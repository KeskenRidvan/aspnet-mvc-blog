using App.Business.Dtos.Post;
using App.Business.Services.Abstract;
using App.Persistence.Data.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogController : Controller
	{
		IPostService _postService;
		IMapper _mapper;
		public BlogController(IPostService postService, IMapper mapper)
		{
			_postService = postService;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var posts = _postService.GetAllViewPostDtos();
			return View(posts);
		}

		//CREATE
		[HttpGet]
		public IActionResult Create()
		{
			var returnedDto = _postService.PopulatePostCategories(null);
			return View(returnedDto);
		}

		[HttpPost]
		public IActionResult Create(CreateOrEditPostDto postDto)
		{
			if (postDto == null) { return RedirectToAction("Index"); }
			var post = _mapper.Map<Post>(postDto);

			if (ModelState.IsValid)
			{
				_postService.Insert(post);
				_postService.SaveChanges();
				_postService.InsertCategoryPost(postDto.selectedCategoryIds, post);
				_postService.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(_postService.PopulatePostCategories(postDto));
		}

		//Edit
		[HttpGet]
		public IActionResult Edit(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			var post = _postService.GetById(id);

			if (post == null)
			{ return RedirectToAction("Index"); }

			var postDto = _mapper.Map<CreateOrEditPostDto>(post);

			var returnedDto = _postService.PopulatePostCategories(postDto);
			returnedDto.selectedCategoryIds = _postService.GetSelectedCategoryIds(post.Id);
			return View(returnedDto);
		}

		[HttpPost]
		public IActionResult Edit(CreateOrEditPostDto postDto)
		{
			if (postDto == null) { return RedirectToAction("Index"); }
			var post = _mapper.Map<Post>(postDto);

			if (ModelState.IsValid)
			{
				_postService.Update(post);
				_postService.SaveChanges();
				_postService.UpdateCategoryPost(postDto.selectedCategoryIds, post);
				_postService.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(_postService.PopulatePostCategories(postDto));
		}

		//DELETE
		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			var post = _postService.GetById(id);

			if (post == null)
			{ return RedirectToAction("Index"); }

			return View(post);
		}


		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }

			_postService.DeleteById(id);
			_postService.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
