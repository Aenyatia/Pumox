using Microsoft.EntityFrameworkCore;
using Pumox.Commands;
using Pumox.Domain;
using Pumox.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pumox.Query;

namespace Pumox.Services
{
	public class CompanyService
	{
		private readonly ApplicationDbContext _context;

		public CompanyService(ApplicationDbContext context)
		{
			_context = context;

			if (!_context.Companies.Any())
			{
				_context.AddRange(
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
				_context.SaveChanges();
			}
		}

		public IEnumerable<Company> SearchCompany(SearchCriteria criteria)
		{
			Specifications.Core.Specification<Company> a = Specifications.Core.Specification<Company>.AllTrue;

			//if (!string.IsNullOrWhiteSpace(criteria.Keyword))
			//{
			//	a = a.And(new CompanyName(criteria.Keyword));
			//}

			//if (criteria.DateFrom.HasValue)
			//{
			//	a = a.And(new EmployeeBirthFrom(criteria.DateFrom.Value));
			//}

			//if (criteria.DateTo.HasValue)
			//{
			//	a = a.And(new EmployeeBirthTo(criteria.DateTo.Value));
			//}

			//if (criteria.Titles.Any())
			//{
			//	Specification<Company> or = Specification<Company>.AllFalse;
			//	foreach (var title in criteria.Titles)
			//		or = or.Or(new EmployeeJobTitle(title));
			//	a = a.And(or);
			//}

			Specifications.Core.Specification<Company> x = null;
			x = x.And(a);

			return _context.Companies
				.Include(c => c.Employees)
				.Where(a.ToExpression())
				.ToList();
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

	public class A : Specifications.Core.Specification<Company>
	{
		private readonly DateTime _date;

		public A(DateTime date)
		{
			_date = date;
		}

		public override Expression<Func<Company, bool>> ToExpression()
		{
			return c => c.Employees.Any(e => e.DateOfBirth >= _date);
		}
	}
}
