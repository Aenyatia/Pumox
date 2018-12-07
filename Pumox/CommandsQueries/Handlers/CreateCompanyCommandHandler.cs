using Pumox.CommandsQueries.Commands;
using Pumox.CommandsQueries.Core;
using Pumox.CommandsQueries.Core.Command;
using Pumox.Domain;
using System.Threading.Tasks;

namespace Pumox.CommandsQueries.Handlers
{
	public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IResult> Handle(CreateCompanyCommand command)
		{
			var company = new Company
			{
				Name = command.Name,
				EstablishmentYear = command.EstablishmentYear,
				Employees = command.Employees
			};

			_unitOfWork.Companies.Add(company);
			_unitOfWork.Commit();

			await Task.CompletedTask;
			return new Result();
		}
	}
}
