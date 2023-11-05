using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Business.Dtos.PostComment
{
	public class PostCommentCreateOrEditDto
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Yorum")]
		[StringLength(500, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string Comment { get; set; }

		public int PostId { get; set; }

		public Persistence.Data.Entity.Post? Post { get; set; }
	}
}
