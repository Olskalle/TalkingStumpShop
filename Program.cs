using Microsoft.AspNetCore.Authentication.Cookies;
using TalkingStumpShop.Authentication;
using TalkingStumpShop.Services;

namespace TalkingStumpShop
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddDbContext<WebsiteContext>();
			builder.Services.AddDbContext<AuthenticationContext>();
			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			builder.Services.AddScoped<INewsService, NewsService>();
			builder.Services.AddScoped<IProductsService, ProductsService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options => //CookieAuthenticationOptions
			{
				options.LoginPath = new PathString("/Login");
				options.Cookie.Name = "stump_cookie";
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
			});

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}