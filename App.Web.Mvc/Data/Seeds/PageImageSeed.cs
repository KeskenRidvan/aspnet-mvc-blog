using App.Web.Mvc.Data.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Web.Mvc.Data.Seeds
{
	public class PostImageSeed : IEntityTypeConfiguration<PostImage>
	{
		public void Configure(EntityTypeBuilder<PostImage> builder)
		{
			builder.HasData(
			new PostImage { Id = 1, PostId = 1, ImageUrl = "../images/slider/slider1.jpg" },
			new PostImage { Id = 2, PostId = 2, ImageUrl = "../images/slider/slider2.jpg" },
			new PostImage { Id = 3, PostId = 3, ImageUrl = "../images/slider/slider3.jpg" }
			);
		}
	}
}
