using App.Business.Services.Abstract;
using App.Persistence.Data;
using App.Persistence.Data.Entity;

namespace App.Business.Services.Concrete
{
	public class PostImageManager : IPostImageService
	{
		private readonly AppDbContext _context;

		public PostImageManager(AppDbContext context)
		{
			_context = context;

		}
		public void DeleteById(int id)
		{
			var postImage = _context.PostImages.Find(id);
			if (postImage != null)
				_context.PostImages.Remove(postImage);
		}

		public IEnumerable<PostImage> GetAll()
		{
			return _context.PostImages.Select(e => e).ToList();
		}

		public PostImage GetById(int id)
		{

			return _context.PostImages.Where(a => a.Id == id).FirstOrDefault();
		}

		public void Insert(PostImage entity)
		{

			_context.PostImages.Add(entity);
		}

		public void Update(PostImage entity)
		{

			if (_context.PostImages.Contains(entity))
				_context.PostImages.Update(entity);
		}
		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public PostImage GetByPostId(int postId)
		{
			return _context.PostImages.Where(a => a.PostId == postId).FirstOrDefault();
		}
	}
}
