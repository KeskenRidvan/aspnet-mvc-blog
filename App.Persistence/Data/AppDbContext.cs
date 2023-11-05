using App.Persistence.Data.Entity;
using App.Persistence.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Persistence.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CategoryPost>().HasKey(bc => new { bc.CategoryId, bc.PostId });
			modelBuilder.Entity<CategoryPost>().HasOne(bc => bc.Category).WithMany(b => b.CategoryPosts).HasForeignKey(bc => bc.CategoryId);
			modelBuilder.Entity<CategoryPost>().HasOne(bc => bc.Post).WithMany(c => c.CategoryPosts).HasForeignKey(bc => bc.PostId);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}


		public DbSet<Category> Categories { get; set; }
		public DbSet<CategoryPost> CategoryPosts { get; set; }
		public DbSet<Page> Pages { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<PostComment> PostComments { get; set; }
		public DbSet<PostImage> PostImages { get; set; }
		public DbSet<Setting> Settings { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
