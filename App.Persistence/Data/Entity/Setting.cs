using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Persistence.Data.Entity
{
	public class Setting
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public bool DarkMode { get; set; }

		[DisplayName("Kullanıcı")]
		public int UserId { get; set; }

		public User? User { get; set; }
	}
}
