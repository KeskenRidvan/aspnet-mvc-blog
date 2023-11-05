using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Persistence.Data.Entity
{
	public class PostImage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[DisplayName("Resim URL")]
		public string ImageUrl { get; set; }

		[NotMapped]
		public IFormFile Image { get; set; } = null!;
		public int PostId { get; set; }
		public Post Post { get; set; }
	}
}
