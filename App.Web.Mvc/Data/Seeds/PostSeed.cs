using App.Web.Mvc.Data.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Web.Mvc.Data.Seeds
{
	public class PostSeed : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.HasData(
			new Post
			{
				Id = 1,
				Title = "Lorem ipsum dolor sit amet.",
				Context = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce elementum, enim et dapibus efficitur, augue augue blandit ex, et scelerisque orci felis quis massa. Donec viverra risus augue, ac auctor nisl ultrices id. Aliquam luctus mauris vitae laoreet ullamcorper. Mauris suscipit nisl sapien, sed auctor arcu feugiat vel. Integer rhoncus, diam sed consectetur dignissim, elit nibh eleifend eros, et eleifend risus augue id ante. Aenean eu risus scelerisque, mollis nulla at, finibus felis. Nulla blandit ipsum eget leo eleifend lobortis. Nulla in fringilla sem. Phasellus accumsan vitae tortor non tincidunt. Sed convallis, augue sit amet aliquet tempor, eros eros fringilla libero, ultrices placerat urna augue eu nisl. Praesent suscipit viverra nulla, sed condimentum ante iaculis eget. Nam auctor faucibus metus, non gravida leo pellentesque et.",
				UserId = 1,
				Date = new DateTime(2023, 12, 11)
			},
					new Post
					{
						Id = 2,
						Title = "Consectetur adipiscing.",
						Context = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin vulputate id nisi tristique ullamcorper. Vestibulum aliquam ipsum ac diam lacinia, vitae posuere urna efficitur. Cras tempus quam ut condimentum iaculis. Donec euismod enim et tristique feugiat. Suspendisse non malesuada eros. Nulla id enim sit amet orci fringilla interdum. Etiam ultricies pharetra elit, eget vulputate odio. Fusce facilisis in lacus id lacinia. In ex lacus, convallis nec sapien non, placerat consectetur ipsum. Quisque cursus ligula id ullamcorper sagittis. Vivamus ultricies mollis augue. Nunc vel erat vitae purus vestibulum egestas.",
						UserId = 2,
						Date = new DateTime(2020, 8, 11)
					},
					new Post
					{
						Id = 3,
						Title = "Consectetur adipiscing.",
						Context = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin vulputate id nisi tristique ullamcorper. Vestibulum aliquam ipsum ac diam lacinia, vitae posuere urna efficitur. Cras tempus quam ut condimentum iaculis. Donec euismod enim et tristique feugiat. Suspendisse non malesuada eros. Nulla id enim sit amet orci fringilla interdum. Etiam ultricies pharetra elit, eget vulputate odio. Fusce facilisis in lacus id lacinia. In ex lacus, convallis nec sapien non, placerat consectetur ipsum. Quisque cursus ligula id ullamcorper sagittis. Vivamus ultricies mollis augue. Nunc vel erat vitae purus vestibulum egestas.",
						UserId = 3,
						Date = new DateTime(2010, 7, 15)
					}

			);

		}
	}
}
