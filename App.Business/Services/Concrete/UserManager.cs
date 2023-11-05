using App.Business.Services.Abstract;
using App.Persistence.Data;
using App.Persistence.Data.Entity;

namespace App.Business.Services.Concrete
{
	public class UserManager : IUserService
	{
		private readonly AppDbContext _context;

		public UserManager(AppDbContext context)
		{
			_context = context;

		}
		public void DeleteById(int id)
		{
			var user = _context.Users.Find(id);
			if (user != null)
				_context.Users.Remove(user);
		}

		public IEnumerable<User> GetAll()
		{
			return _context.Users.Select(e => e);
		}

		public User GetById(int id)
		{
			return _context.Users.Find(id);
		}

		public void Insert(User entity)
		{
			_context.Users.Add(entity);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(User entity)
		{
			if (_context.Users.Contains(entity))
				_context.Users.Update(entity);
		}
	}
}
