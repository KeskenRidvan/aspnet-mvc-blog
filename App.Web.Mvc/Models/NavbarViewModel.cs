using App.Web.Mvc.Data.Entitiy;

namespace App.Web.Mvc.Models
{
	public class NavbarViewModel
	{
		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<Page> Pages { get; set; }
	}
}
