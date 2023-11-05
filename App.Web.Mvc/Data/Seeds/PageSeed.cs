using App.Web.Mvc.Data.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Web.Mvc.Data.Seeds
{
	public class PageSeed : IEntityTypeConfiguration<Page>
	{
		public void Configure(EntityTypeBuilder<Page> builder)
		{
			builder.HasData(
			new Page { Id = 1, Title = "About", Context = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce elementum, enim et dapibus efficitur, augue augue blandit ex, et scelerisque orci felis quis massa. Donec viverra risus augue, ac auctor nisl ultrices id." },
			new Page { Id = 2, Title = "Contact", Context = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce elementum, enim et dapibus efficitur, augue augue blandit ex, et scelerisque orci felis quis massa. Donec viverra risus augue, ac auctor nisl ultrices id." },
			new Page { Id = 3, Title = "Our Team", Context = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce elementum, enim et dapibus efficitur, augue augue blandit ex, et scelerisque orci felis quis massa. Donec viverra risus augue, ac auctor nisl ultrices id." });
		}
	}
}
