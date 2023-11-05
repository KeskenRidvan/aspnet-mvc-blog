using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Web.Mvc.Models
{
	public class Admin
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Admin Adı")]
		[StringLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Admin Soyadı")]
		[StringLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string Surname { get; set; } = string.Empty;

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Admin E-Mail")]
		[EmailAddress(ErrorMessage = "Yanlış bir mail girdiniz.")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Admin Şifre")]
		[PasswordPropertyText]
		public string Password { get; set; } = string.Empty;
	}
}
