using App.Business.Services.Abstract;
using App.Persistence.Data;
using App.Persistence.Data.Entity;

namespace App.Business.Services.Concrete
{
	public class SettingManager : ISettingService
	{
		private readonly AppDbContext _context;

		public SettingManager(AppDbContext context)
		{
			_context = context;

		}
		public void DeleteById(int id)
		{
			var setting = _context.Settings.Find(id);
			if (setting != null)
				_context.Settings.Remove(setting);
		}

		public IEnumerable<Setting> GetAll()
		{
			return _context.Settings.Select(e => e);
		}

		public Setting GetById(int id)
		{
			return _context.Settings.Find(id);
		}

		public void Insert(Setting entity)
		{
			_context.Settings.Add(entity);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(Setting entity)
		{
			if (_context.Settings.Contains(entity))
				_context.Settings.Update(entity);
		}
	}
}
