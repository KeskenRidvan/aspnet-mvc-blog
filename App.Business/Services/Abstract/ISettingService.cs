using App.Persistence.Data.Entity;

namespace App.Business.Services.Abstract
{
	public interface ISettingService
	{
		Setting GetById(int id);
		IEnumerable<Setting> GetAll();
		void Insert(Setting entity);
		void Update(Setting entity);
		void DeleteById(int id);
		void SaveChanges();
	}
}
