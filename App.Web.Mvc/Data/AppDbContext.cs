using App.Web.Mvc.Data.Entitiy;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Web.Mvc.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
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
