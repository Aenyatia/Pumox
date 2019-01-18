using Pumox.Core.Countries;
using Pumox.Core.Extensions;
using System;

namespace Pumox.Core.Employees
{
	public sealed class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly ICountryRepository _countryRepository;

		public EmployeeService(IEmployeeRepository employeeRepository, ICountryRepository countryRepository)
		{
			_employeeRepository = employeeRepository;
			_countryRepository = countryRepository;
		}

		public async void Create(Guid id, string firstName, string lastName, DateTime dateOfBirth, JobTitle jobTitle)
		{
			var employee = new Employee(id, firstName, lastName, dateOfBirth, jobTitle);
			await _employeeRepository.Add(employee);
		}

		public async void SetAddress(Guid id, Guid countryId, string street, string city)
		{
			var employee = await _employeeRepository.GetOrFail(id);
			var country = await _countryRepository.GetOrFail(countryId);

			var address = Address.Create(street, city, country);

			employee.SetAddress(address);

			await _employeeRepository.Update(employee);
		}
	}
}
