using Microsoft.EntityFrameworkCore;
using TalkingStumpShop.Authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TalkingStumpShop.Authentication
{
	public class AuthenticationContext : DbContext
	{
		public AuthenticationContext()
		{
			Database.EnsureCreated();
		}

		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase("InMemory");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(u =>
			{
				u.HasKey(x => x.Id);
				u.Property(x => x.Id).ValueGeneratedOnAdd();
				u.Property(x => x.Login).IsRequired();
				u.Property(x => x.Password).IsRequired();
			});
        }
	}
}
