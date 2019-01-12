using Microsoft.EntityFrameworkCore;
using Pumox.Core.Domain;
using System;
using System.Collections.Generic;
using Pumox.Core.Companies;

namespace Pumox.Infrastructure.EntityFramework
{
	public sealed class ApplicationDbContext : DbContext
	{
		public DbSet<Company> Companies { get; set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Company>().HasData(
		//		new Company
		//		{
		//			Id = 1,
		//			Name = "Company1",
		//			EstablishmentYear = 2000,
		//		},
		//		new Company
		//		{
		//			Id = 2,
		//			Name = "Company2",
		//			EstablishmentYear = 2001,
		//			Employees = new List<Employee>
		//			{
		//				new Employee
		//				{
		//					Id = 1,
		//					FirstName = "First1",
		//					LastName = "Last1",
		//					DateOfBirth = new DateTime(1980, 12, 12),
		//					JobTitle = JobTitle.Administrator
		//				},
		//				new Employee
		//				{
		//					Id = 2,
		//					FirstName = "First2",
		//					LastName = "Last2",
		//					DateOfBirth = new DateTime(1990, 10, 07),
		//					JobTitle = JobTitle.Architect
		//				}
		//			}
		//		},
		//		new Company
		//		{
		//			Id = 3,
		//			Name = "Company3",
		//			EstablishmentYear = 2010,
		//			Employees = new List<Employee>
		//			{
		//				new Employee
		//				{
		//					Id = 3,
		//					FirstName = "First1",
		//					LastName = "Last6",
		//					DateOfBirth = new DateTime(2000, 08, 10),
		//					JobTitle = JobTitle.Administrator
		//				},
		//				new Employee
		//				{
		//					Id = 4,
		//					FirstName = "First4",
		//					LastName = "Last5",
		//					DateOfBirth = new DateTime(2004, 01, 17),
		//					JobTitle = JobTitle.Developer
		//				}
		//			}
		//		});
		//}
	}
}
