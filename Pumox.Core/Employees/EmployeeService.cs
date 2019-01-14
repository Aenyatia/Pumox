using Pumox.Core.Extensions;
using System;

namespace Pumox.Core.Employees
{
	public sealed class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeService(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		public async void SetAddress(Guid id, string street, string city)
		{
			var employee = await _employeeRepository.GetOrFail(id);
			var address = Address.Create(street, city);

			employee.SetAddress(address);
		}
	}
}
