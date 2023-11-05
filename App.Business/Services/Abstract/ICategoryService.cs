using App.Persistence.Data.Entity;

namespace App.Business.Services.Abstract
{
	public interface ICategoryService
	{
		Category GetById(int id);
		IEnumerable<Category> GetAll();
		void Insert(Category entity);
		void Update(Category entity);
		void DeleteById(int id);
		void SaveChanges();
		List<Post> GetPostsBySearch(string searchString);
		List<CategoryPost> GetPostsByCategoryIndex(int Id);
	}
}
