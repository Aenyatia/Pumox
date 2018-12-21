using Pumox.Application.Commands;
using Pumox.Core.Repositories;
using Pumox.Infrastructure.CQS.Commands;
using Pumox.Infrastructure.CQS.Results;
using System.Threading.Tasks;

namespace Pumox.Application.CommandsHandlers
{
	public class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ICommandResult> Handle(UpdateCompanyCommand command)
		{
			//var company = await _unitOfWork.Companies.GetCompanyById(command.Id);
			//if (company == null)
			//	return new CommandResult { Succeeded = false };

			//IList<Employee> employeesList = command.CompanyDto.Employees
			//	.Select(employeeDto => new Employee
			//	{
			//		FirstName = employeeDto.FirstName,
			//		LastName = employeeDto.LastName,
			//		DateOfBirth = employeeDto.DateOfBirth,
			//		JobTitle = employeeDto.JobTitle
			//	})
			//	.ToList();

			//company.Name = command.CompanyDto.Name;
			//company.EstablishmentYear = command.CompanyDto.EstablishmentYear;
			//company.Employees = employeesList;

			//await _unitOfWork.Commit();

			return CommandResult.Ok();
		}
	}
}
