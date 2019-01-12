using Pumox.Core.Employees;
using Pumox.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Core.Companies
{
	public sealed class CompanyService : ICompanyService
	{
		private readonly ICompanyRepository _companyRepository;

		public CompanyService(ICompanyRepository companyRepository)
		{
			_companyRepository = companyRepository;
		}

		public async Task Add(Guid id, string name, int establishmentYear, IEnumerable<Employee> employees)
		{
			var company = new Company(id, name, establishmentYear);
			company.SetEmployees(employees);

			await _companyRepository.Add(company);
		}

		public async Task Update(Guid id, string name, int establishmentYear, IEnumerable<Employee> employees)
		{
			var company = await _companyRepository.GetOrFail(id);

			company.UpdateCompany(name, establishmentYear);
			company.SetEmployees(employees);

			await _companyRepository.Update(company);
		}

		public async Task Delete(Guid id)
		{
			var company = await _companyRepository.GetOrFail(id);

			await _companyRepository.Remove(company);
		}
	}
}
