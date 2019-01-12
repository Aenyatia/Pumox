using Microsoft.EntityFrameworkCore;
using Pumox.Core.Companies;
using Pumox.Core.Employees;

namespace Pumox.Infrastructure.EntityFramework
{
	public sealed class ApplicationDbContext : DbContext
	{
		public DbSet<Company> Companies { get; set; }
		public DbSet<Employee> Employees { get; set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}
	}
}
