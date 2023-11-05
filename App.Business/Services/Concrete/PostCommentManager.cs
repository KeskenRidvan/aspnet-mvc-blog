using App.Business.Services.Abstract;
using App.Persistence.Data;
using App.Persistence.Data.Entity;

namespace App.Business.Services.Concrete
{
	public class PostCommentManager : IPostCommentService
	{
		private readonly AppDbContext _context;

		public PostCommentManager(AppDbContext context)
		{
			_context = context;
		}

		public void DeleteById(int id)
		{
			var postComment = _context.PostComments.Find(id);
			if (postComment != null)
				_context.PostComments.Remove(postComment);
		}

		public IEnumerable<PostComment> GetAll()
		{
			return _context.PostComments.Select(e => e).ToList();
		}

		public PostComment GetById(int id)
		{

			return _context.PostComments.Where(a => a.Id == id).FirstOrDefault();
		}

		public void Insert(PostComment entity)
		{

			_context.PostComments.Add(entity);
		}

		public void Update(PostComment entity)
		{

			if (_context.PostComments.Contains(entity))
				_context.PostComments.Update(entity);
		}
		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public IEnumerable<PostComment> GetAllByPostId(int postId)
		{
			return _context.PostComments.Where(e => e.PostId == postId).ToList();
		}
	}
}
