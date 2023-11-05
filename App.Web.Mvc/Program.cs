using App.Business;
using App.Business.Services.Abstract;
using App.Business.Services.Concrete;
using App.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Mvc
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DBConStr"));
			});

			builder.Services.AddScoped<IPostService, PostManager>();
			builder.Services.AddScoped<ICategoryService, CategoryManager>();
			builder.Services.AddScoped<IUserService, UserManager>();
			builder.Services.AddScoped<ISettingService, SettingManager>();
			builder.Services.AddScoped<IPageService, PageManager>();

			builder.Services.AddAutoMapper(typeof(MappingProfile));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}