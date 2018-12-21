using Microsoft.Extensions.Logging;
using Pumox.Application.Commands;
using Pumox.Core.Domain;
using Pumox.Core.Repositories;
using Pumox.Infrastructure.CQS.Commands;
using Pumox.Infrastructure.CQS.Results;
using Pumox.Infrastructure.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox.Application.CommandsHandlers
{
	public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<CreateCompanyCommandHandler> _logger;

		public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateCompanyCommandHandler> logger)
		{
			_unitOfWork = unitOfWork;
			_logger = logger;
		}

		public async Task<ICommandResult> Handle(CreateCompanyCommand command)
		{
			_logger.LogDebug("Creating company...");

			var employees = new List<Employee>();
			var errors = new List<string>();
			foreach (var companyEmployee in command.Employees)
			{
				var result = Employee.Create(companyEmployee.FirstName, companyEmployee.LastName,
					DateTime.Parse(companyEmployee.DateOfBirth), Enum.Parse<JobTitle>(companyEmployee.JobTitle));

				if (result.Success)
					employees.Add(result.Value);

				if (result.Failure)
					errors.AddRange(result.Errors);
			}

			if (!errors.Any())
			{
				var company = new Company(command.Id, command.Name, command.EstablishmentYear, employees);
				var repo = new Fake();

				await repo.Add(company);

				//await _unitOfWork.Companies.Add(company);
				//await _unitOfWork.Commit();

				_logger.LogDebug("Company created.");

				return CommandResult.Ok();
			}

			_logger.LogDebug("Creating failed.");

			return CommandResult.Fail(errors);
		}
	}
}
