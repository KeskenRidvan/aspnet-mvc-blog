using App.Persistence.Data.Entity;

namespace App.Business.Services.Abstract
{
	public interface IPageService
	{
		Page GetById(int id);
		IEnumerable<Page> GetAll();
		void Insert(Page entity);
		void Update(Page entity);
		void DeleteById(int id);
		void SaveChanges();
	}
}
