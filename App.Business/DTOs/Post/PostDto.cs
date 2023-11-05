using App.Persistence.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Business.Dtos.Post
{
	public class PostDto
	{
		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Gönderi Başlığı")]
		[StringLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string PostTitle { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Gönderi İçeriği")]
		[StringLength(1000, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(10, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string PostContext { get; set; }
		public PostImage PostImage { get; set; }
	}
}
