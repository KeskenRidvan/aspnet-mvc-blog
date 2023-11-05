using App.Persistence.Data;
using App.Persistence.Data.Entity;

namespace App.Business.Services.Concrete
{
	internal class PostManager
	{
		private readonly AppDbContext _context;

		public PostManager(AppDbContext context)
		{
			_context = context;

		}
		public void DeleteById(int id)
		{
			var post = _context.Posts.Find(id);
			if (post != null)
				_context.Posts.Remove(post);
		}

		public IEnumerable<Post> GetAll()
		{
			return _context.Posts.Select(e => e);
		}

		public Post GetById(int id)
		{
			return _context.Posts.Find(id);
		}

		public string GetCategoryName(int id)
		{
			int categoryId = _context.CategoryPosts.FirstOrDefault(p => p.PostId == id).CategoryId;
			return _context.Categories.Find(categoryId).Name;
		}

		public void Insert(Post entity)
		{
			_context.Posts.Add(entity);
		}

		public void Update(Post entity)
		{
			if (_context.Posts.Contains(entity)) _context.Posts.Update(entity);
		}
		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
