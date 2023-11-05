using App.Business.Dtos.PostComment;
using App.Business.Services.Abstract;
using App.Persistence.Data.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PostCommentController : Controller
	{
		IPostCommentService _postCommentService;
		IMapper _mapper;
		public PostCommentController(IPostCommentService postCommentService, IMapper mapper)
		{
			_postCommentService = postCommentService;
			_mapper = mapper;
		}
		public IActionResult Index(int id)
		{
			var comments = _postCommentService.GetAllByPostId(id);
			TempData["postId"] = id;
			return View(comments);
		}
		//CREATE
		[HttpGet]
		public IActionResult Create(int id)
		{
			TempData["postId"] = id;
			PostCommentCreateOrEditDto postComment = new PostCommentCreateOrEditDto() { PostId = id };
			return View(postComment);
		}
		[HttpPost]
		public IActionResult Create(PostCommentCreateOrEditDto postCommentDto)
		{
			if (postCommentDto == null) { return RedirectToAction("Index", new { id = postCommentDto.PostId }); }
			var postComment = _mapper.Map<PostComment>(postCommentDto);
			postComment.Id = 0;
			if (ModelState.IsValid)
			{
				_postCommentService.Insert(postComment);
				_postCommentService.SaveChanges();
				return RedirectToAction("Index", new { id = postCommentDto.PostId });
			}
			return View(postCommentDto);
		}
		//EDIT
		[HttpGet]
		public IActionResult Edit(int id)
		{
			/*TempData["postId"] = id;*/
			var comment = _postCommentService.GetById(id);
			var postCommentDto = _mapper.Map<PostCommentCreateOrEditDto>(comment);
			return View(postCommentDto);
		}
		[HttpPost]
		public IActionResult Edit(PostCommentCreateOrEditDto postCommentDto)
		{
			if (postCommentDto == null) { return RedirectToAction("Index", new { id = postCommentDto.PostId }); }
			var postComment = _mapper.Map<PostComment>(postCommentDto);
			if (ModelState.IsValid)
			{
				_postCommentService.Update(postComment);
				_postCommentService.SaveChanges();
				return RedirectToAction("Index", new { id = postCommentDto.PostId });
			}
			return View(postCommentDto);
		}
		//DELETE
		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (id == 0) { return RedirectToAction("Index"); }
			var postComment = _postCommentService.GetById(id);
			TempData["postId"] = postComment.PostId;
			if (postComment == null)
			{ return RedirectToAction("Index"); }
			return View(postComment);
		}
		[HttpPost]
		public IActionResult Delete(PostComment postComment)
		{
			if (postComment == null) { return RedirectToAction("Index"); }
			_postCommentService.DeleteById(postComment.Id);
			_postCommentService.SaveChanges();
			return RedirectToAction("Index", new { id = TempData["postId"] });
		}
	}
}
