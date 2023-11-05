using App.Business.Dtos.Post;
using App.Business.Services.Abstract;
using App.Persistence.Data;
using App.Persistence.Data.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Business.Services.Concrete
{
	public class PostManager : IPostService
	{
		private readonly AppDbContext _context;
		IMapper _mapper;
		public PostManager(AppDbContext db, IMapper mapper)
		{
			_context = db;
			_mapper = mapper;
		}
		public void DeleteById(int id)
		{
			var post = _context.Posts.Find(id);
			if (post != null)
				_context.Posts.Remove(post);
		}

		public IEnumerable<Post> GetAll()
		{
			return _context.Posts.Select(e => e).Include(e => e.CategoryPosts).ThenInclude(e => e.Category).ToList();
		}

		public Post GetById(int id)
		{

			return _context.Posts.Where(a => a.Id == id).Include(a => a.CategoryPosts).FirstOrDefault();
		}

		public string GetCategoryName(int id)
		{
			int categoryId = _context.CategoryPosts.FirstOrDefault(p => p.PostId == id).CategoryId;
			return _context.Categories.Find(categoryId).Name;
		}

		public void Insert(Post entity)
		{
			entity.UserId = 1;
			_context.Posts.Add(entity);
		}

		public void Update(Post entity)
		{
			entity.UserId = 1;
			if (_context.Posts.Contains(entity))
				_context.Posts.Update(entity);
		}
		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public IEnumerable<ViewPostDto> GetAllViewPostDtos()
		{
			var posts = GetAll();

			var postsViewDto = new List<ViewPostDto>();

			foreach (var item in posts)
			{
				postsViewDto.Add(_mapper.Map<ViewPostDto>(item));
			}

			return postsViewDto;
		}

		public CreateOrEditPostDto PopulatePostCategories(CreateOrEditPostDto createOrEditPostDto = null)
		{
			var categories = _context.Categories.Select(e => e).ToList();
			var newPostDto = new CreateOrEditPostDto();

			if (createOrEditPostDto == null)
			{
				newPostDto.Categories = categories;
				return newPostDto;
			}
			else
			{
				createOrEditPostDto.Categories = categories;
				return createOrEditPostDto;
			}
		}

		public void InsertCategoryPost(List<int> selectedCategories, Post post)
		{
			foreach (var categoryId in selectedCategories)
			{
				var categoryPost = new CategoryPost() { PostId = post.Id, CategoryId = categoryId };
				_context.CategoryPosts.Add(categoryPost);
			}
		}
		public void UpdateCategoryPost(List<int> selectedCategories, Post post)
		{
			var oldCategoryPost = _context.CategoryPosts.Where(p => p.PostId == post.Id).ToList();

			foreach (var item in oldCategoryPost)
			{
				_context.CategoryPosts.Remove(item);
				_context.SaveChanges();
			}
			foreach (var item in selectedCategories)
			{
				var newCategoryPost = new CategoryPost { CategoryId = item, PostId = post.Id };
				_context.CategoryPosts.Add(newCategoryPost);
				_context.SaveChanges();
			}
		}
		public List<int> GetSelectedCategoryIds(int postId)
		{
			return _context.CategoryPosts.Where(a => a.PostId == postId).Select(a => a.CategoryId).ToList();
		}
	}
}
