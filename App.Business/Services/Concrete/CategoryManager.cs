using App.Business.Services.Abstract;
using App.Persistence.Data;
using App.Persistence.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace App.Business.Services.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly AppDbContext _context;

		public CategoryManager(AppDbContext context)
		{
			_context = context;

		}
		public void DeleteById(int id)
		{
			var category = _context.Categories.Find(id);
			if (category != null) _context.Categories.Remove(category);
		}

		public IEnumerable<Category> GetAll()
		{
			return _context.Categories.Select(e => e);
		}

		public Category GetById(int id)
		{
			return _context.Categories.Find(id);
		}

		public void Insert(Category entity)
		{
			_context.Categories.Add(entity);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(Category entity)
		{
			if (_context.Categories.Contains(entity)) _context.Categories.Update(entity);
		}

		public List<Post> GetPostsBySearch(string searchString)
		{
			return _context.Posts.Where(p => p.Context.Contains(searchString) || p.Title.Contains(searchString)).Include(p => p.Images).Include(p => p.CategoryPosts).ThenInclude(p => p.Category).ToList();
		}

		public List<CategoryPost> GetPostsByCategoryIndex(int Id)
		{
			return _context.CategoryPosts.Where(p => p.CategoryId == Id).Include(c => c.Post).ThenInclude(c => c.Images).Include(c => c.Category).ToList();
		}
	}
}
