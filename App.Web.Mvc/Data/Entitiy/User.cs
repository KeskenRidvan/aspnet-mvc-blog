using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Web.Mvc.Data.Entitiy
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Kullanıcı Adı")]
		[StringLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string Name { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Kullanıcı Soyadı")]
		[StringLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Kullanıcı E-Mail")]
		[EmailAddress(ErrorMessage = "Yanlış bir mail girdiniz.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Kullanıcı Şifresi")]
		[PasswordPropertyText]
		public string Password { get; set; }
	}
}
