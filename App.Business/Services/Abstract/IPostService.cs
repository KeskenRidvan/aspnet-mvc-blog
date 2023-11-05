using App.Persistence.Data.Entity;

namespace App.Business.Services.Abstract
{
	public interface IPostService
	{
		Post GetById(int id);
		IEnumerable<Post> GetAll();
		void Insert(Post entity);
		void Update(Post entity);
		void DeleteById(int id);
		string GetCategoryName(int id);
		void SaveChanges();
	}
}
