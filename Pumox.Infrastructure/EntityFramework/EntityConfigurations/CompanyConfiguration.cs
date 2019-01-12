using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pumox.Core.Companies;
using Pumox.Core.Employees;

namespace Pumox.Infrastructure.EntityFramework.EntityConfigurations
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.HasKey(c => c.Id);

			builder.HasMany<Employee>();
		}
	}
}
