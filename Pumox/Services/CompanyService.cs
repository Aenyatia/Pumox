using Pumox.Commands;
using Pumox.Domain;
using Pumox.Infrastructure;
using System;
using System.Linq;

namespace Pumox.Services
{
	public class CompanyService
	{
		private readonly ApplicationDbContext _context;

		public CompanyService(ApplicationDbContext context)
		{
			_context = context;
		}

		public void SearchCompany()
		{

		}

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

			company.Name = company.Name;
			company.EstablishmentYear = company.EstablishmentYear;
			company.Employees = company.Employees;

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
