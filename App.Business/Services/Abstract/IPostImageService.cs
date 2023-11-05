using App.Persistence.Data.Entity;

namespace App.Business.Services.Abstract
{
	public interface IPostImageService
	{
		PostImage GetById(int id);
		PostImage GetByPostId(int id);
		IEnumerable<PostImage> GetAll();
		void Insert(PostImage entity);
		void Update(PostImage entity);
		void DeleteById(int id);
		void SaveChanges();
	}
}
