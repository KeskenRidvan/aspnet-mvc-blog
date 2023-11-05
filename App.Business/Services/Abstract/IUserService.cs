using App.Persistence.Data.Entity;

namespace App.Business.Services.Abstract
{
	public interface IUserService
	{
		User GetById(int id);
		IEnumerable<User> GetAll();
		void Insert(User entity);
		void Update(User entity);
		void DeleteById(int id);
		void SaveChanges();
	}
}
