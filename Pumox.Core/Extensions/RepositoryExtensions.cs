using Pumox.Core.Companies;
using Pumox.Core.Employees;
using System;
using System.Threading.Tasks;

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
	}
}
