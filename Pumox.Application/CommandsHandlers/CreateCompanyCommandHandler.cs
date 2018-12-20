using Pumox.Application.Commands;
using Pumox.Core.Domain;
using Pumox.Core.Repositories;
using Pumox.Infrastructure.CQS.Commands;
using Pumox.Infrastructure.CQS.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox.Application.CommandsHandlers
{
	public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ICommandResult> Handle(CreateCompanyCommand command)
		{
			IList<Employee> employeesList = command.CompanyDto.Employees
				.Select(employeeDto => new Employee
				{
					FirstName = employeeDto.FirstName,
					LastName = employeeDto.LastName,
					DateOfBirth = employeeDto.DateOfBirth,
					JobTitle = employeeDto.JobTitle
				})
				.ToList();

			var company = new Company
			{
				Name = command.CompanyDto.Name,
				EstablishmentYear = command.CompanyDto.EstablishmentYear,
				Employees = employeesList
			};

			await _unitOfWork.Companies.Add(company);
			await _unitOfWork.Commit();

			return new CommandResult { Succeeded = true };
		}
	}
}
