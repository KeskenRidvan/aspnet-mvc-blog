using App.Business.Dtos.Post;
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
		IEnumerable<ViewPostDto> GetAllViewPostDtos();
		CreateOrEditPostDto PopulatePostCategories(CreateOrEditPostDto createOrEditPostDto);
		void InsertCategoryPost(List<int> selectedCategories, Post post);
		void UpdateCategoryPost(List<int> selectedCategories, Post post);
		List<int> GetSelectedCategoryIds(int postId);
	}
}
