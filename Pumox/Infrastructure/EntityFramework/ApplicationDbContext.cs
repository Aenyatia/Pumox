using Microsoft.EntityFrameworkCore;
using Pumox.Domain;

namespace Pumox.Infrastructure.EntityFramework
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Company> Companies { get; set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.ApplyConfiguration(new CompanyConfiguration());
		//}
	}
}
