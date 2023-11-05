using App.Web.Mvc.Data.Entitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Web.Mvc.Data.Seeds
{
	public class UserSeed : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasData(
			new User { Id = 1, Name = "Selami", Surname = "Şahin", Email = "selamisahin@gmail.com", Password = "selami123" },
			new User { Id = 2, Name = "Cengiz", Surname = "Kurtoğlu", Email = "cengizkurtoglu@gmail.com", Password = "cengiz123" },
			new User { Id = 3, Name = "Müslüm", Surname = "Gürses", Email = "muslumgurses@gmail.com", Password = "muslum123" }
			);
		}
	}
}
