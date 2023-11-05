using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Business.DTOs.Page
{
	public class ViewPageDto
	{
		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Sayfa Başlığı")]
		[StringLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string PageTitle { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Sayfa İçeriği")]
		[StringLength(1000, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(10, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string PageContext { get; set; }
	}
}
