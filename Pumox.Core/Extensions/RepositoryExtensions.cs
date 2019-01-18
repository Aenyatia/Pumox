using Pumox.Core.Companies;
using Pumox.Core.Employees;
using System;
using System.Threading.Tasks;
using Pumox.Core.Countries;

namespace Pumox.Core.Extensions
{
	public static class RepositoryExtensions
	{
		public static async Task<Company> GetOrFail(this ICompanyRepository companyRepository, Guid id)
		{
			var company = await companyRepository.GetCompanyById(id);
			if (company == null)
				throw new Exception($"Company with id: '{id}' was not found.");

			return company;
		}

		public static async Task<Employee> GetOrFail(this IEmployeeRepository employeeRepository, Guid id)
		{
			var employee = await employeeRepository.GetEmployeeById(id);
			if (employee == null)
				throw new Exception($"Employee with id: '{id}' was not found.");

			return employee;
		}

		public static async Task<Country> GetOrFail(this ICountryRepository countryRepository, Guid id)
		{
			var country = await countryRepository.GetCountryById(id);
			if (country == null)
				throw new Exception($"Country with id: '{id}' was not found.");

			return country;
		}
	}
}
