using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pumox.Application.Companies.Commands;
using Pumox.Common.CQS.Commands;
using Pumox.Core.Companies;
using Pumox.Core.Employees;

namespace Pumox.Application.Companies.CommandsHandlers
{
	public class UpdateCompanyHandler : ICommandHandler<UpdateCompany>
	{
		private readonly ICompanyService _companyService;

		public UpdateCompanyHandler(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		public async Task Handle(UpdateCompany command)
		{
			var employees = new List<Employee>();
			foreach (var employee in command.Employees)
			{
				var birth = DateTime.Parse(employee.DateOfBirth);
				var jobTitle = Enum.Parse<JobTitle>(employee.JobTitle);
				employees.Add(new Employee(employee.Id, employee.FirstName, employee.LastName, birth, jobTitle));
			}

			await _companyService.Update(command.Id, command.Name, command.EstablishmentYear, employees);
		}
	}
}
