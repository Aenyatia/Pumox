using Microsoft.EntityFrameworkCore;
using Pumox.Commands;
using Pumox.Domain;
using Pumox.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumox.Services
{
	public class CompanyService
	{
		private readonly ApplicationDbContext _context;

		public CompanyService(ApplicationDbContext context)
		{
			_context = context;

			if (!context.Companies.Any())
			{
				_context.Companies.AddRange(
					new Company
					{
						Name = "Company One",
						EstablishmentYear = 2000,
						Employees = new List<Employee>
						{
							new Employee
							{
								FirstName = "First One",
								LastName = "Last One",
								DateOfBirth = new DateTime(1920, 10, 12),
								JobTitle = JobTitle.Architect
							},
							new Employee
							{
								FirstName = "First Two",
								LastName = "Last Two",
								DateOfBirth = new DateTime(1994, 06, 15),
								JobTitle = JobTitle.Manager
							}
						}
					},
					new Company
					{
						Name = "Company Two",
						EstablishmentYear = 2010,
						Employees = new List<Employee>
						{
							new Employee
							{
								FirstName = "First Three",
								LastName = "Last Three",
								DateOfBirth = new DateTime(1920, 10, 12),
								JobTitle = JobTitle.Administrator
							},
							new Employee
							{
								FirstName = "First Three",
								LastName = "Last Three",
								DateOfBirth = new DateTime(1994, 06, 15),
								JobTitle = JobTitle.Manager
							}
						}
					}
				);
				_context.SaveChanges();
			}
		}

		public void SearchCompany()
		{

		}

		public IEnumerable<Company> Get()
			=> _context.Companies.Include(c => c.Employees).ToList();

		public Company CreateCompany(CreateCompany command)
		{
			var company = new Company
			{
				Name = command.Name,
				EstablishmentYear = command.EstablishmentYear,
				Employees = command.Employees
			};

			_context.Companies.Add(company);
			_context.SaveChanges();

			return company;
		}

		public void UpdateCompany(long companyId, UpdateCompany command)
		{
			var company = _context.Companies.SingleOrDefault(c => c.Id == companyId);

			if (company == null)
				throw new ArgumentException();

			company.Name = command.Name;
			company.EstablishmentYear = command.EstablishmentYear;
			company.Employees = command.Employees;

			_context.SaveChanges();
		}

		public void DeleteCompany(long companyId)
		{
			var company = _context.Companies.SingleOrDefault(c => c.Id == companyId);

			if (company == null)
				throw new ArgumentException();

			_context.Remove(company);
			_context.SaveChanges();
		}
	}
}
