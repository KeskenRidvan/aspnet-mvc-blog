using App.Persistence.Data.Entity;

namespace App.Business.Services.Abstract
{
	public interface IPostCommentService
	{
		PostComment GetById(int id);
		IEnumerable<PostComment> GetAll();
		IEnumerable<PostComment> GetAllByPostId(int postId);
		void Insert(PostComment entity);
		void Update(PostComment entity);
		void DeleteById(int id);
		void SaveChanges();
	}
}
