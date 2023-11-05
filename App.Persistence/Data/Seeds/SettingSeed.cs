using App.Persistence.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Data.Seeds
{
	internal class SettingSeed : IEntityTypeConfiguration<Setting>
	{
		public void Configure(EntityTypeBuilder<Setting> builder)
		{
			builder.HasData(
				new Setting { Id = 1, UserId = 1, DarkMode = true },
				new Setting { Id = 2, UserId = 2, DarkMode = false });
		}
	}
}
