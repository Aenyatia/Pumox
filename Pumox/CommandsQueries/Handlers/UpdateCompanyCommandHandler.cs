using Pumox.CommandsQueries.Commands;
using Pumox.CommandsQueries.Core;
using Pumox.CommandsQueries.Core.Command;
using Pumox.Domain;
using System.Threading.Tasks;

namespace Pumox.CommandsQueries.Handlers
{
	public class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IResult> Handle(UpdateCompanyCommand command)
		{
			var id = 1;
			var company = _unitOfWork.Companies.GetCompanyById(1);
			if (company == null)
				return new Result();

			company.Name = company.Name;
			company.EstablishmentYear = company.EstablishmentYear;
			company.Employees = company.Employees;

			await Task.CompletedTask;
			_unitOfWork.Commit();

			return new Result();
		}
	}
}
