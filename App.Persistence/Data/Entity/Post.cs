using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Persistence.Data.Entity
{
	public class Post
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Gönderi Başlığı")]
		[StringLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(3, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string Title { get; set; }

		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[DisplayName("Gönderi İçeriği")]
		[StringLength(1000, ErrorMessage = "{0} {1} karakterden fazla olamaz!")]
		[MinLength(10, ErrorMessage = "{0} en az {1} karakter olabilir!")]
		public string Context { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime Date { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

		public IEnumerable<CategoryPost> CategoryPosts { get; set; }
		public IEnumerable<PostImage> Images { get; set; }
		public IEnumerable<PostComment> Comments { get; set; }
	}
}
