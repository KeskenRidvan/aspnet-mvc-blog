using App.Business.Services.Abstract;
using App.Persistence.Data;
using App.Persistence.Data.Entity;

namespace App.Business.Services.Concrete
{
	public class PageManager : IPageService
	{
		private readonly AppDbContext _context;

		public PageManager(AppDbContext context)
		{
			_context = context;

		}
		public void DeleteById(int id)
		{
			var page = _context.Pages.Find(id);
			if (page != null)
				_context.Pages.Remove(page);
		}

		public IEnumerable<Page> GetAll()
		{
			return _context.Pages.Select(e => e);
		}

		public Page GetById(int id)
		{
			return _context.Pages.Find(id);
		}

		public void Insert(Page entity)
		{
			_context.Pages.Add(entity);
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		public void Update(Page entity)
		{
			if (_context.Pages.Contains(entity)) _context.Pages.Update(entity);
		}
	}
}
