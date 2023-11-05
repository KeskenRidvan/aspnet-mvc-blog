using App.Business.Services.Abstract;
using App.Persistence.Data.Entity;
using Microsoft.AspNetCore.Mvc;
namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PostImageController : Controller
	{
		IPostImageService _postImageService;
		public PostImageController(IPostImageService postImageService)
		{
			_postImageService = postImageService;
		}
		public IActionResult Index(int id)
		{
			var postImage = _postImageService.GetByPostId(id);
			TempData["postId"] = id;
			if (postImage == null)
			{
				var newPI = new PostImage();
				newPI.ImageUrl = "";
				return View(newPI);
			}
			return View(postImage);
		}
		//CREATE
		[HttpGet]
		public IActionResult Create(int id)
		{
			var postImage = new PostImage { PostId = id };
			TempData["postId"] = id;
			return View(postImage);
		}
		[HttpPost]
		public ActionResult Create(PostImage model)
		{
			if (model.Image != null)
			{
				string directoryPath = "wwwroot/images/slider";
				Directory.CreateDirectory(directoryPath);
				string filePath = Path.Combine(directoryPath, model.Image.FileName);
				if (Path.Exists(filePath) == false)
				{
					using var stream = System.IO.File.Create(filePath);
					model.Image.CopyTo(stream);
				}
				model.Id = 0;
				model.ImageUrl = filePath.Replace("wwwroot", "..");
				_postImageService.Insert(model);
				_postImageService.SaveChanges();
				return RedirectToAction("Index", new { id = model.PostId });
			}
			return View(model);
		}
		//EDIT
		[HttpGet]
		public IActionResult Edit(int id)
		{
			TempData["postId"] = id;
			var postImage = _postImageService.GetByPostId(id);
			if (postImage != null)
				return View(postImage);
			var postImageNew = new PostImage { PostId = id };
			return View(postImageNew);
		}
		[HttpPost]
		public ActionResult Edit(PostImage model)
		{
			var modelToChange = _postImageService.GetByPostId(model.PostId);
			if (model.Image != null)
			{
				string directoryPath = "wwwroot/images/slider";
				Directory.CreateDirectory(directoryPath);
				string filePath = Path.Combine(directoryPath, model.Image.FileName);
				if (Path.Exists(filePath) == false)
				{
					using var stream = System.IO.File.Create(filePath);
					model.Image.CopyTo(stream);
				}
				modelToChange.ImageUrl = filePath.Replace("wwwroot", "..");
				_postImageService.Update(modelToChange);
				_postImageService.SaveChanges();
				return RedirectToAction("Index", new { id = model.PostId });
			}
			return View(model);
		}
		//EDIT
		[HttpGet]
		public IActionResult Delete(int id)
		{
			TempData["postId"] = id;
			var postImage = _postImageService.GetByPostId(id);
			if (postImage != null)
				return View(postImage);
			var postImageNew = new PostImage { PostId = id };
			return View(postImageNew);
		}
		[HttpPost]
		public ActionResult Delete(PostImage model)
		{
			var modelToDelete = _postImageService.GetByPostId(model.PostId);
			_postImageService.DeleteById(modelToDelete.Id);
			_postImageService.SaveChanges();
			return RedirectToAction("Index", new { id = model.PostId });
		}
	}
}
