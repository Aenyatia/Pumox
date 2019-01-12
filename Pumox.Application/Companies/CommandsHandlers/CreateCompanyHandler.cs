using Pumox.Application.Companies.Commands;
using Pumox.Common.CQS.Commands;
using Pumox.Core.Companies;
using Pumox.Core.Employees;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Application.Companies.CommandsHandlers
{
	public class CreateCompanyHandler : ICommandHandler<CreateCompany>
	{
		private readonly ICompanyService _companyService;

		public CreateCompanyHandler(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		public async Task Handle(CreateCompany command)
		{
			var employees = new List<Employee>();
			foreach (var employee in command.Employees)
			{
				var birth = DateTime.Parse(employee.DateOfBirth);
				var jobTitle = Enum.Parse<JobTitle>(employee.JobTitle);
				employees.Add(new Employee(Guid.NewGuid(), employee.FirstName, employee.LastName, birth, jobTitle));
			}

			await _companyService.Add(command.Id, command.Name, command.EstablishmentYear, employees);
		}
	}
}
