using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pumox.Domain;
using System;
using System.Collections.Generic;

namespace Pumox.Infrastructure.EntityFramework.EntityConfigurations
{
	public class CompanyConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.HasData(
				new Company
				{
					Id = 1,
					Name = "Company One",
					EstablishmentYear = 2000,
					Employees = new List<Employee>
					{
						new Employee
						{
							Id = 1,
							FirstName = "First One",
							LastName = "Last One",
							DateOfBirth = new DateTime(1920, 10, 12),
							JobTitle = JobTitle.Architect
						},
						new Employee
						{
							Id = 2,
							FirstName = "First Two",
							LastName = "Last Two",
							DateOfBirth = new DateTime(1994, 06, 15),
							JobTitle = JobTitle.Manager
						},
						new Employee
						{
							Id = 3,
							FirstName = "First Three",
							LastName = "Last Three",
							DateOfBirth = new DateTime(2000, 10, 30),
							JobTitle = JobTitle.Architect
						}
					}
				},
				new Company
				{
					Id = 2,
					Name = "Company Two",
					EstablishmentYear = 2010,
					Employees = new List<Employee>
					{
						new Employee
						{
							Id = 4,
							FirstName = "First Three",
							LastName = "Last Three",
							DateOfBirth = new DateTime(1920, 10, 12),
							JobTitle = JobTitle.Developer
						},
						new Employee
						{
							Id = 5,
							FirstName = "First Four",
							LastName = "Last Four",
							DateOfBirth = new DateTime(1994, 06, 15),
							JobTitle = JobTitle.Manager
						}
					}
				},
				new Company
				{
					Id = 3,
					Name = "Company Three",
					EstablishmentYear = 2010,
					Employees = new List<Employee>
					{
						new Employee
						{
							Id = 6,
							FirstName = "First Three",
							LastName = "Last Three",
							DateOfBirth = new DateTime(1920, 10, 12),
							JobTitle = JobTitle.Administrator
						}
					}
				});
		}
	}
}
